using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BookStoreMvcUI.Models
{
    [Table("Book")]
    public class Book
    {
        public int Id { get; set; }

        [DisplayName("Kitap Adı")]
        [Required(ErrorMessage = "Kitap Adı boş bırakılamaz.")]
        [MaxLength(40)]
        public string? BookName { get; set; }

        [DisplayName("Yazar Adı")]
        [Required(ErrorMessage = "Yazar Adı boş bırakılamaz.")]
        [MaxLength(40)]
        public string? AuthorName { get; set; }

        [DisplayName("Fiyat")]
        [Required(ErrorMessage = "Fiyat boş bırakılamaz.")]
        public double Price { get; set; }

        [DisplayName("Kitap Kapağı")]
        public string? Image { get; set; }

        [DisplayName("Tür ID")]
        [Required(ErrorMessage = "Tür ID boş bırakılamaz.")]
        public int GenreId { get; set; }
        
        public Genre Genre { get; set; }

        public List<OrderDetail> OrderDetail { get; set; }

        public List<CartDetail> CartDetail { get; set; }

        [NotMapped]
        public string GenreName { get; set; }
    }
}
