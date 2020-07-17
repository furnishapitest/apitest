using EuroFurnish.ApplicationCore.Entities.Base;
using Microsoft.AspNetCore.Identity;
using System;

namespace EuroFurnish.ApplicationCore.Entities
{
    public class AppUser : IdentityUser<long>, IAuditEntity,IEntity
    {
        public string Name { get; set; }
        public string LastName { get; set; }
        public string FullName => Name + " " + LastName;
        public DateTime CreatedDate { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public bool IsDeleted { get; set; }
        public bool IsActive { get; set; }
        public string RefreshToken { get; set; }
        public DateTime RefreshTokenEndDate { get; set; }
       
    }
}
