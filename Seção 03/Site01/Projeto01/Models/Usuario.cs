using System.ComponentModel.DataAnnotations;




namespace Site01.Models
{
    public class Usuario
    {

        [Required(ErrorMessage = "Campo 'e-mail' é Obrigatório")]
        public string Email { get; set; }
        [Required(ErrorMessage = "Campo 'Senha' é Obrigatório")]
        public string Senha { get; set; }

    }
}
