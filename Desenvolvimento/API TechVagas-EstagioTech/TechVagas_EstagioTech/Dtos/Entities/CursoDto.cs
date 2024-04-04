﻿using System.ComponentModel.DataAnnotations;

namespace TechVagas_EstagioTech.Dtos.Entities
{
	public class CursoDto
	{
        [Key]
        public int Id { get; set; }

		[Required(ErrorMessage = "E necessário o nome do curso")]
		[MinLength(3)]
		[MaxLength(150)]
		public string nomeCurso { get; set; }

        [Required(ErrorMessage = "E necessário o turno do curso")]
        [MinLength(3)]
        [MaxLength(100)]
        public string? turnoCurso { get; set; }
    }
}
