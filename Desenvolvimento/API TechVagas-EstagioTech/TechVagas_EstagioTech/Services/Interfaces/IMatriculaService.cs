﻿using TechVagas_EstagioTech.Dtos.Entities;

namespace TechVagas_EstagioTech.Services.Interfaces
{
    public interface IMatriculaService
    {
        Task<IEnumerable<MatriculaDto>> BuscarTodasMatriculas();
        Task<MatriculaDto> BuscarPorId(int id);
        Task Adicionar(MatriculaDto matriculaDto);
        Task Atualizar(MatriculaDto matriculaDto);
        Task Apagar(int id);
    }
}
