using System;
using HADU.hem.ApplicationCore.Entities;

namespace HADU.hem.ApplicationCore.DTOs.Users {
    public class UserCreateDTO {
        public string Email { get; set; }
        public string Nickname { get; set; }
        public string PasswordHash { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime BirthDate { get; set; }
        public string Phone { get; set; }
        public string Address { get; set; }
        public string Address2 { get; set; }
        public string Zip { get; set; }
        public string City { get; set; }
        public string GuardianName { get; set; }
        public string GuardianPhone { get; set; }
        public AccessLevel AccessLevel { get; set; }
    }
}