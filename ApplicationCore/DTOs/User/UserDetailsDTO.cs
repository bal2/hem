using System;
using HADU.hem.ApplicationCore.Entities;

namespace HADU.hem.ApplicationCore.DTOs.Users
{
    public class UserDetailsDTO
    {
        public long UserId { get; set; }
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
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }

        public UserDetailsDTO()
        {

        }

        public UserDetailsDTO(User u)
        {
            UserId = u.UserId;
            Email = u.Email;
            Nickname = u.Nickname;
            PasswordHash = u.PasswordHash;
            FirstName = u.FirstName;
            LastName = u.LastName;
            BirthDate = u.BirthDate;
            Phone = u.Phone;
            Address = u.Address;
            Address2 = u.Address2;
            Zip = u.Zip;
            City = u.City;
            GuardianName = u.GuardianName;
            GuardianPhone = u.GuardianPhone;
            AccessLevel = u.AccessLevel;
            CreatedAt = u.CreatedAt;
            UpdatedAt = u.UpdatedAt;
        }
    }
}