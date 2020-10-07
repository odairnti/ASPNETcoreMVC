using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Site01.Models
{
    public class Contato
    {
        [Required(ErrorMessage = "Campo 'Nome' é Obrigatório")]
        [MaxLength(50,ErrorMessage = "Campo 'Nome' suporta até 50 caracteres")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "Campo 'e-mail' é obrigatório")]
        [MaxLength(40, ErrorMessage = "Campo 'e-mail' suporta até 40 caracteres")]
        [EmailAddress(ErrorMessage = "Campo 'e-mail' é inválido!")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Campo 'Assunto' é Obrigatório")]
        [MaxLength(70,ErrorMessage = "Campo 'assnto' suporta até 70 caracteres")]
        public string Assunto { get; set; }

        [Required(ErrorMessage = "Campo 'Mensagem' é Obrigatório")]
        [MaxLength(1000, ErrorMessage = "Campo 'e-mail' suporta até 1000 caracteres")]
        public string Mensagem { get; set; }

    }
}
