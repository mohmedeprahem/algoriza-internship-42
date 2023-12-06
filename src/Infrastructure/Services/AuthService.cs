﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.Dtos;
using Application.Dtos.Authentications;
using Application.Interfaces.Repositories;
using Application.Interfaces.Services;
using Application.Repositories;
using Application.Services;
using AutoMapper;
using Core.enums;
using Core.Models;
using Infrastructure.Helpers;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Infrastructure.Services
{
    public class AuthService : IAuthService
    {
        private readonly IMapper _mapper;
        private readonly IAuthRepository _authRepository;
        private readonly IFileService _fileService;
        private readonly ISpecializationRepository _specializationRepository;

        public AuthService(
            IMapper mapper,
            IAuthRepository authRepository,
            IFileService fileService,
            ISpecializationRepository specializationRepository
        )
        {
            this._mapper = mapper;
            this._authRepository = authRepository;
            this._fileService = fileService;
            this._specializationRepository = specializationRepository;
        }

        public async Task<IdentityResult> RegisterPatient(RegisterDto model)
        {
            string imageName = string.Empty;
            string savePath = string.Empty;
            ApplicationUser user = _mapper.Map<ApplicationUser>(model);

            if (model.Image != null)
            {
                savePath = Path.Combine(Directory.GetCurrentDirectory(), "../../uploads");
                imageName = await _fileService.UploadFile(model.Image, savePath);
                user.Image = imageName;
            }

            IdentityResult result = await _authRepository.Register(
                user,
                model.Password,
                RolesEnum.Patient.ToString()
            );

            if (!result.Succeeded)
            {
                string imagePath = Path.Combine(savePath, imageName);
                if (File.Exists(imagePath))
                {
                    File.Delete(imagePath);
                }
            }

            return result;
        }

        public async Task<IdentityResult> RegisterDoctor(DoctorDto model)
        {
            string savePath = string.Empty;
            string imageName = string.Empty;
            try
            {
                ApplicationUser user = _mapper.Map<ApplicationUser>(model);

                // save image
                savePath = Path.Combine(Directory.GetCurrentDirectory(), "../../uploads");
                imageName = await _fileService.UploadFile(model.Image, savePath);
                user.Image = imageName;

                // Check if specialty exists
                Specialization specialization =
                    await _specializationRepository.GetSpecializationByTitle(model.Specialize);

                if (specialization == null)
                {
                    return IdentityResult.Failed(
                        new IdentityError
                        {
                            Code = "Specialization",
                            Description = "The specified specialization was not found.",
                        }
                    );
                }

                user.SpecializationId = specialization.Id;

                // Save user
                IdentityResult result = await _authRepository.Register(
                    user,
                    model.Password,
                    RolesEnum.Doctor.ToString()
                );

                if (!result.Succeeded)
                {
                    string imagePath = Path.Combine(savePath, imageName);
                    if (File.Exists(imagePath))
                    {
                        File.Delete(imagePath);
                    }
                }

                return result;
            }
            catch (Exception ex)
            {
                string imagePath = Path.Combine(savePath, imageName);
                if (File.Exists(imagePath))
                {
                    File.Delete(imagePath);
                }

                throw new Exception(ex.Message);
            }
        }

        public async Task<AuthenticationResult> Login(LoginDto model)
        {
            AuthenticationResult authResult = await _authRepository.Login(
                model.Email,
                model.Password
            );

            return authResult;
        }
    }
}
