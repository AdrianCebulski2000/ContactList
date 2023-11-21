using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ContactListAPI.Models
{
    public class ContactDetail
    {
        [Key]
        public int ContactId { get; set; }

        [Column(TypeName ="nvarchar(30)")]
        public string Name { get; set; } = null!;

        [Column(TypeName = "nvarchar(30)")]
        public string Surname { get; set; } = null!;

        [Column(TypeName = "nvarchar(100)")]
        public string Email { get; set; } = null!;

        [Column(TypeName = "nvarchar(100)")]
        public string Password { get; set; } = null!;

        [Column(TypeName = "nvarchar(30)")]
        public string Category { get; set; } = null!;
        [Column(TypeName = "nvarchar(9)")]
        public string PhoneNumber { get; set; } = null!;
    }
}
