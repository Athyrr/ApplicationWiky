using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entities
{
    public class Comment
    {
        public int Id { get; set; }
        [Required]
        [StringLength(30)]
        public string? Author { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime EditedAt { get; set; }
        [StringLength(100)]
        public string? Content { get; set; }
        [ForeignKey("Id")]

        //[Remote("","",ErrorMessage = "L'article doit être unique")]
        public Article? Article { get; set; }
    }
}