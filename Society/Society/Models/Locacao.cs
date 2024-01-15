namespace Society.Models
{
    public class Locacao
    {
        public int Id { get; set; }

        public Quadra Quadra { get; set; }

        public Cliente Cliente { get; set; }

        public DateTime Inicio { get; set; }

        public DateTime Fim { get; set; }
    }
}
