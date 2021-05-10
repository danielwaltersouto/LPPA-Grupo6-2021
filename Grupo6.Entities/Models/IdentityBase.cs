using System.ComponentModel.DataAnnotations;

namespace Grupo6.Entities.Models
{
    public class IdentityBase
    {
        [Key]
        public int Id { get; set; }
    }
}