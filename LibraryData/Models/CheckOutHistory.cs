using System;
using System.ComponentModel.DataAnnotations;

namespace LibraryData.Models
{
    public class CheckOutHistory
    {
        public int Id { get; set; }
        [Required]
        public LibraryAsset LibraryAsset { get; set; }
        [Required]
        public LibraryCard LibraryCard { get; set; }
        [Required]
        public DateTime ? CheckedIn { get; set; }
        [Required]
        public DateTime CheckedOut { get; set; }

    }
}
