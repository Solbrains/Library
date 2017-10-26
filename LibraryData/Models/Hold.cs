using System;
using System.ComponentModel.DataAnnotations;

namespace LibraryData.Models
{
    public class Hold
    {
        public int Id { get; set; }
        [Required]
        public virtual LibraryAsset LibraryAsset { get; set; }
        [Required]
        public virtual LibraryCard LibraryCard { get; set; }

        public DateTime HoldPlaced { get; set; }


    }
}
