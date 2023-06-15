namespace GlobalGames.Data.Entities
{
    public class Budget
    {
        public int Id { get; set; }

        public string Nome { get; set; }

        public string Email { get; set; }

        public string Mensagem { get; set; }

        public User user { get; set; }
    }
}
