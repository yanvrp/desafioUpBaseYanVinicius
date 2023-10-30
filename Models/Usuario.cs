using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace api_ead.Models
{
    [Table("tbUsuario")]
    public class Usuario
    {
        [Key]
        public int idUsuario { get; set; }
        public string? nomeCompleto { get; set; }
        public string? userName { get; set; }
        public string? email { get; set; }
        public string? senha { get; set; }

        public char? tipoCadastro { get; set; }

        public Usuario() { }

    }
}
