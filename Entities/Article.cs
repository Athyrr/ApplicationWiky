using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class Article
    {
        [Key]
        public int Id { get; set; }

        //Unique
        public string? Theme { get; set; }

        [Required]
        [StringLength(30)]
        public string? Author { get; set; }

        public DateTime CreatedAt { get; set; }
        
        public DateTime EditedAt { get; set; }
        public string? Content { get; set; }
        public List<Comment>? Comments { get; set; }

    }
}
