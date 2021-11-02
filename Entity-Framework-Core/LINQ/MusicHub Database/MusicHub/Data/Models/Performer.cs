using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace MusicHub.Data.Models
{
    public class Performer
    {
        public int Id { get; set; }

        [MaxLength(20)]
        [Required]
        public string FirstName { get; set; }

        [MaxLength(20)]
        [Required]
        public string LastName { get; set; }

        [Required]
        public int Age { get; set; }

        [Required] 
        public decimal NetWorth { get; set; }

        [NotMapped]
        public ICollection<SongPerformer> PerformerSongs { get; set; }

    }
}
