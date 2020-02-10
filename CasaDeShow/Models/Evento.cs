namespace CasaDeShow.Models
{
    public class Evento
    {
        public int Id { get; set; }
        public string NomeEvento { get; set; }
        public int Capacidade { get; set; }
        public System.DateTime Data { get; set; }
        public double ValorIngresso { get; set; }
        public string GeneroMusica { get; set; }
    }
}