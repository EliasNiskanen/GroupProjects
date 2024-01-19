using System.ComponentModel.DataAnnotations;

namespace PeopleLib
{
    public class Renter
    {
        [Key]
        public int IdRenter { get; set; }
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
        [Required]
        public string NickName { get; set; }
        public string? Locality { get; set; } //Paikkakunta
        public string? Presentation { get; set; }
        public byte[]? Picture { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        public string Password { get; set; }

    }
}
