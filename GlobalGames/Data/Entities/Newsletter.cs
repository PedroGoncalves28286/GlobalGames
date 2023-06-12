using System.ComponentModel.DataAnnotations;

namespace GlobalGames.Data.Entities
{
    public class Newsletter
    {
        public int Id { get; set; }

        public string Email { get; set; }
    }
}