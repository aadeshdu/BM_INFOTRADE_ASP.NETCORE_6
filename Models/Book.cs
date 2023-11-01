using System.ComponentModel.DataAnnotations;

namespace BM_INFOTRADE_ASP.NETCORE_6.Models
{
    public class Book
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [Display(Name = "Book_Author")]
        public string Author { get; set; }
        [Required]
        [Display(Name = "Book_Title")]
        public string Title { get; set; }
        [Required]
        [Display(Name = "Publication_Year")]
        public DateTime Publication_Year { get; set; }
    }
}
