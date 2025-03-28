namespace NBasketball.Models
{
    public class Favorite
    {
        public int Id { get; set; }
        public int PlayerId { get; set; }

        public virtual Player Player { get; set; } // Связь с игроком
    }
}