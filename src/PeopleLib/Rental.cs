using System.ComponentModel.DataAnnotations;

namespace PeopleLib
{
    public class Rental
    {
        [Key]
        public int IdRental { get; set; }


        public DateTime Rentalstart { get; set; }

        public DateTime Rentalend { get; set; }
        public string? RentalText { get; set; }
        public int IdRentalinstrument { get; set; }
        public int? IdRenter { get; set; }

        public int? IdCustomer { get; set; }

    }
}
