using System;
using System.ComponentModel.DataAnnotations;

namespace CasaDeShow.Models
{
    public class Casadeshow
    {
        
        public int Id { get; set; }
        // [Required(ErrorMessage="Campo nome da casa de show necessário.")]
        [Required(ErrorMessage="Campo nome da casa de show necessário."), StringLength(50),Display(Name = "Nome da casa de show")]
        public string Nome { get; set; }
        [Required(ErrorMessage="Campo endereço da casa de show necessário."),Display(Name="Endereço da casa de show")]
        public string Endereco { get; set; }
    }
}