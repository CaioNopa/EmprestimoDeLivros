using System.ComponentModel.DataAnnotations;

namespace EmprestimoDeLivros.Models
{
    public class EmprestimoModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Campo Vazio")]
        public string Recebedor { get; set; }


        [Required(ErrorMessage = "Campo Vazio")]
        public string Fornecedor { get; set; }


        [Required(ErrorMessage = "Campo Vazio")]
        public string LivroEmprestado { get; set; }
       
        public DateTime DataUltimaAtualização { get; set; } = DateTime.Now;
    }
}
