using System.ComponentModel.DataAnnotations;

namespace CasaDeShow.Models
{
    public class Evento
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Campo nome do evento necessário.", AllowEmptyStrings = false)]
        public string NomeEvento { get; set; }

        [Range(1, 200000, ErrorMessage = "Campo capacidade necessário.")]
        public int Capacidade { get; set; }

        [Required(ErrorMessage = "Campo Data com hora do evento necessário.")]
        [DisplayFormat(DataFormatString= "{0:dd/MM/yyyy HH:mm}")]
        public System.DateTime Data { get; set; }

        [Required(ErrorMessage = "Campo valor do ingresso necessário.")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:###,##0.00}")]

        public double ValorIngresso { get; set; }
        [Required(ErrorMessage = "Campo gênero da música necessário.")]

        public string GeneroMusica { get; set; }
    }
}