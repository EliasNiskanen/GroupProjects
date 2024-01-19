using System.ComponentModel.DataAnnotations;

namespace PeopleLib
{
    public class RentalInstrumentPicture
    {
        [Key]
        public int IdRentalInstrumentPicture { get; set; }
        public string? Picture { get; set; }
        public int IdRentalInstrument { get; set; }
    }
}
