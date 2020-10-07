using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;




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
