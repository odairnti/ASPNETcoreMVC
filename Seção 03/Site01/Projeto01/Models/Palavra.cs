﻿using Site01.Library.Validation;
using System.ComponentModel.DataAnnotations;

namespace Site01.Models
{
    public class Palavra
    {
        public int ID { get; set; }
        [Required(ErrorMessage = "Campo 'Palavra' é Obrigatório")]
        [MaxLength(50, ErrorMessage = "Campo 'Palavra' suporta até 50 caracteres")]
        [UnicoNomePalavra]
        public string Descricao { get; set; }
        public byte? Nivel { get; set; } //1-facil 2-Medio 3-Dificil


    }
}
