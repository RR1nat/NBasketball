using System;
using System.ComponentModel.DataAnnotations;

namespace NBasketball.Models
{
    public class Player
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Имя обязательно")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Позиция обязательна")]
        public string Position { get; set; }
        [Required(ErrorMessage = "Команда обязательна")]
        public int TeamId { get; set; }
        public Team Team { get; set; } // Навигационное свойство, не требует заполнения в форме
        public string ImagePath { get; set; } // Необязательное поле
        [Required(ErrorMessage = "Дата добавления обязательна")]
        public DateTime DateAdded { get; set; }
    }
}