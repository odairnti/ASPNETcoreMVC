using Microsoft.AspNetCore.Connections.Features;
using Site01.Database;
using Site01.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Site01.Library.Validation
{
    public class UnicoNomePalavraAttribute : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            Palavra palavra = validationContext.ObjectInstance as Palavra;

            var _db = (DatabaseContext)validationContext.GetService(typeof(DatabaseContext));

            var palavraBanco = _db.palavras.Where(a => a.Descricao == palavra.Descricao && a.ID != palavra.ID).FirstOrDefault();

            if (palavraBanco == null)
            {
                return ValidationResult.Success;
            } else
            {
                return new ValidationResult("A Palavra '"+palavra.Descricao+ "' já se encontra cadastrada na base de dados.");
            }


        }

    }
}
