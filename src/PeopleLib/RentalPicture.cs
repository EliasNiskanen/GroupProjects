using System.ComponentModel.DataAnnotations;

namespace PeopleLib
{
    public class RentalPicture
    {
        [Key]
        public int IdRentalPicture { get; set; }
        public byte[]? Picture { get; set; }
        public int IdRental { get; set; }
    }
}
