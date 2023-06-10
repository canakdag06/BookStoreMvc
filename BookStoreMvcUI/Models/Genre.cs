using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace BookStoreMvcUI.Models
{
    [Table("Genre")]
    public class Genre
    {
        public int Id { get; set; }

        [DisplayName("Tür Adı")]
        [Required(ErrorMessage = "Tür Adı boş bırakılamaz.")]
        [MaxLength(40)]
        public string GenreName { get; set; }

        public List<Book> Books { get; set; }   
        // GenreController Save()'de burayı not required yapamadığım için IsNullorEmpty metodu kullandım.
    }
}
