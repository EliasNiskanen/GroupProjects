using System.ComponentModel.DataAnnotations;

namespace PeopleLib
{
    public class RentalInstrument
    {
        [Key]
        public int IdRentalInstrument { get; set; }

        public int IdRenter { get; set; }

        public string? Type { get; set; }
        public string? Model{ get; set; }
       
        public double? Price { get; set; }
        public string? InstrumentInfo { get; set; }

        public string? ModelYear { get; set; }
        public byte[]? Picture { get; set; }

        public bool? Lainattu { get; set; } = false;

        public bool? Lainauspyynto { get; set; } = false;
    }
}
