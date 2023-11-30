﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace Core.Models
{
    public class ApplicationUser : IdentityUser
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Gender { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string? Image { get; set; }
        public int? SpecializationId { get; set; }
        public Specialization Specialization { get; set; }
        public ExaminationPrice Price { get; set; }
        public UserBookingTracking AprovedBookingCount { get; set; }
        public ICollection<Appointment> Appointments { get; set; }
        public ICollection<Booking> DoctorBookings { get; set; }
        public ICollection<Booking> PatientBookings { get; set; }
    }
}
