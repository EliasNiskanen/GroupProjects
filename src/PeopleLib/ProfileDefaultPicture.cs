using System.ComponentModel.DataAnnotations;

namespace PeopleLib
{
    public class ProfileDefaultPicture
    {
        [Key]
        public int Id { get; set; }
        public byte[]? Picture { get; set; }
    }
}
