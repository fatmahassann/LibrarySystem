using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace LibrarySystem.Domain.Entities
{
    public class Member
    {
        public Guid Id { get; private set; } = Guid.NewGuid();
        public string FullName { get; private set; }
        public string Email { get; private set; }
        public string? PhoneNumber { get; private set; }
        public string? Address { get; private set; }

        public DateTime JoinDate { get; private set; } = DateTime.UtcNow;
        public bool IsActive { get; private set; } = true;
        public bool IsDeleted { get; private set; } = false;


        public Member(string fullName , string email , string? phoneNumber , string? address)
        {
            if (string.IsNullOrWhiteSpace(fullName))
                throw new ArgumentException("Full name can not be empty!");

            if (string.IsNullOrWhiteSpace(email))
                throw new ArgumentException("email can not be empty!");

            FullName = fullName;
            Email = email;
            PhoneNumber = phoneNumber;
            Address = address;

           
            
        }
        public void Update(string fullName, string email, string? phoneNumber , string? address) 
        {
            if (IsDeleted)
                throw new InvalidOperationException("Deleted member cannot be modified");
            
            if (string.IsNullOrWhiteSpace(fullName))
                throw new ArgumentException("Full name can not be empty!");

            if (string.IsNullOrWhiteSpace(email))
                throw new ArgumentException("email can not be empty!");

            FullName = fullName;
            Email = email;
            PhoneNumber = phoneNumber;
            Address = address;
        }

        public void Activate()
        {
            if (IsDeleted)
                throw new InvalidOperationException("Deleted member cannot be modified");
            if (IsActive)
                throw new InvalidOperationException("The member is already active");

            IsActive = true;
        }

        public void Deactivate() 
        {
            if (IsDeleted)
                throw new InvalidOperationException("Deleted member cannot be modified");
            if (!IsActive)
                throw new InvalidOperationException("The member is already not active");

            IsActive = false;

        }




        public void Delete()
        {

            if (IsDeleted)
                throw new InvalidOperationException("Member is already deleted.");

            IsDeleted = true;
        }








    }

    

}
