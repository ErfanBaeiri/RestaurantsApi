using Celestial.Entities.Common;
using System.ComponentModel.DataAnnotations;

namespace Celestial.Entities.User
{
    public class User : BaseEntity
    {
        #region Ctor
        public User()
        {
            IsActive = true;
        }
        #endregion

        #region Properties
        [Required]
        [StringLength(100)]
        public string UserName { get; set; }
        [Required]
        [StringLength(500)]
        public string PasswordHash { get; set; }
        [Required]
        [StringLength(100)]
        public string FullName { get; set; }
        public int Age { get; set; }
        public GenderType Gender { get; set; }
        public bool IsActive { get; set; }
        public DateTimeOffset LastLoginDate { get; set; }
        // Foreign Key
        public int? RoleId { get; set; }
        #endregion




        #region Relation
        public Role? Role { get; set; }
        public ICollection<Post.Post>? Posts { get; set; }
        #endregion
    }

    public enum GenderType
    {
        [Display(Name = "مرد")]
        Male = 1,
        [Display(Name = "زن")]
        Female = 2
    }
}
