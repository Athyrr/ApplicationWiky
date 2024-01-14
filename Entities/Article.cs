using Microsoft.AspNetCore.Mvc;
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

        //Creer l'action du controller !!!

        //Unique
        [Remote("IsThemeUnique", "Article", ErrorMessage = "Le thème doit être unique.")]
        public string? Theme { get; set; }

        [Required(ErrorMessage = "Champ requis")]
        [StringLength(30,ErrorMessage ="Le nom de l'auteur ne doit pas excéder 30 caratères !")]
        public string? Author { get; set; }

        public DateTime CreatedAt { get; set; }
        
        public DateTime EditedAt { get; set; }
        public string? Content { get; set; }
        public List<Comment>? Comments { get; set; }

    }
}
