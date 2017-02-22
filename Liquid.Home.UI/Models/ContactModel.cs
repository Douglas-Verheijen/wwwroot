using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Liquid.Home.UI.Models
{
    public class ContactModel
    {
        [Required]
        public virtual string Name { get; set; }

        [Required]
        [DisplayName("Email Address")]
        [DataType(DataType.EmailAddress)]
        public virtual string EmailAddress { get; set; }
        
        [Required]
        [DisplayName("Phone Number")]
        [DataType(DataType.PhoneNumber)]
        public virtual string PhoneNumber { get; set; }

        [Required]
        public virtual string Message { get; set; }
    }
}