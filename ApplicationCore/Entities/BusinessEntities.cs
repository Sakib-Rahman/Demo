using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationCore.Entities
{
    [Table("BusinessEntities")]
    public class BusinessEntities
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Int64 BusinessId { get; set; }
        [MaxLength(50)][Required(ErrorMessage = "Code is required")]
        [RegularExpression(@"^[a-zA-Z][a-zA-Z0-9]*$", ErrorMessage = "The field Code must be alpha numeric")]
        public string Code { get; set; }
        [MaxLength(100), MinLength(10)]
        [EmailAddress(ErrorMessage = "Please provide valid email address")]
        public string Email { get; set; }
        [MaxLength(50)]
        [RegularExpression(@"^[a-zA-Z''-'\s]{1,40}$", ErrorMessage = "The field Name must be alphabets")]
        public string Name { get; set; }
        //According to resource(Mock-UI)        
        public int MarkupPlan { get; set; }
        [MaxLength]
        public string Street { get; set; }
        [MaxLength(150)]
        public string City { get; set; }
        [MaxLength(150)]
        public string State { get; set; }
        [MaxLength(50)]
        public string Zip { get; set; }
        [MaxLength(50)]
        public string Country { get; set; }
        [MaxLength(150)]
        [RegularExpression("^[0-9]*$", ErrorMessage = "The field Mobile must be a number")]
        public string Mobile { get; set; }
        [MaxLength(50)]
        public string Phone { get; set; }
        [MaxLength]
        public string ContactPerson { get; set; }
        [MaxLength(50)]
        public string ReferredBy { get; set; }
        [MaxLength]
        public string Logo { get; set; }
        public int Status { get; set; }
        [Required(ErrorMessage = "Balance is required")]
        [RegularExpression(@"\d+(\.\d{2,18})?", ErrorMessage = "The field Balance must be a number")]
        public decimal Balance { get; set; }
        [MaxLength(50)]
        public string LoginUrl { get; set; }
        [MaxLength(50)]
        public string SMTPServer { get; set; }
        [MaxLength(50)]
        public string SecurityCode { get; set; }
        //[Required]
        public int SMTPPort { get; set; }
        [MaxLength(50)]
        public string SMTPUsername { get; set; }
        [MaxLength(50)]
        public string SMTPPassword { get; set; }
        [Required]
        public bool Deleted { get; set; }
        public DateTime? CreatedOnUtc { get; set; }
        public DateTime? UpdatedOnUtc { get; set; }

        [RegularExpression(@"\d+(\.\d{2,18})?", ErrorMessage = "The field Current Balance must be a number")]
        public decimal CurrentBalance { get; set; }

    }
}
