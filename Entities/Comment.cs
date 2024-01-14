using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entities
{
    public class Comment
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Champ requis")]
        [StringLength(30, ErrorMessage = "Le nom de l'auteur ne doit pas excéder 30 caratères !")]
        public string? Author { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime EditedAt { get; set; }

        [StringLength(100, ErrorMessage = "Le contenu ne doit pas excéder 100 caratères !")]
        public string? Content { get; set; }

        [ForeignKey("Article")]
        public int ArticleId { get; set; }

        //[Remote("","",ErrorMessage = "L'article doit être unique")]
        public Article? Article { get; set; }
    }
}