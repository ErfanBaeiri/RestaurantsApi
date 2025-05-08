using Celestial.Entities.Common;
using System.ComponentModel.DataAnnotations;

namespace Celestial.Entities.User
{
    public class Role : BaseEntity
    {
        #region Properties
        [Required]
        [StringLength(50)]
        public string Name { get; set; }
        [Required]
        [StringLength(100)]
        public string Description { get; set; }
        #endregion

        #region Relation
        //public ICollection<User> Users { get; set; }
        #endregion
    }
}
