using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ConsoleAppDatabase;

namespace ConsoleAppDatabase.Entities
{
    public class ContactsRoles

    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(50)]
        
        public string FirstName { get; set; } = null!;

        public virtual ICollection<UserInfo> UserInfos { get; set; } = new HashSet<UserInfo>();

    }
    
    public class UserInfo
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [StringLength(50)]
        public string FirstName { get; set; } = null!;
        [Required]
        [StringLength(50)]
        public string LastName { get; set; } = null!;

        [Required]
        [ForeignKey(nameof(Role))]
        public int RoleId { get; set;}
        public virtual ContactsRoles Role { get; set; } = null!;
        public virtual UserInfoContact ContactInfo { get; set; } = null!;
    }


    public class UserInfoContact
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(50)]
        public string PhoneNumber { get; set; } = null!;

        [Required]
        [StringLength(50)]
        public string Email { get; set; } = null!;

        [Required]
        [ForeignKey(nameof(UserInfo))]
        public int UserInfoId { get; set; }
        public virtual UserInfo UserInfo { get; set; } = null!;
    }
    public class UserInfoAddress
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [StringLength(50)]
        public string City { get; set; } = null!;
        [Required]
        [StringLength(50)]
        public string StreetName { get; set; } = null!;
        [Required]
        [StringLength(50)]
        public string PostalCode { get; set; } = null!;

        [Required]
        [StringLength(50)]
        public virtual UserInfo UserInfo { get; set;} = null!;
    }
    public class User
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [StringLength(50)]
        [ForeignKey(nameof(UserInfo))]
        public int UserInfoId { get; set; }
        public virtual UserInfo UserInfo { get; set;} = null!;
    }

}
