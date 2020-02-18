using Microsoft.AspNetCore.Identity;

namespace CasaDeShow.Models
{
    public class Compra
    {
        public int Id { get; set; }
        public int QtdIngresso { get; set; }
        public IdentityUser IdentityUser { get; set; }
    }
}