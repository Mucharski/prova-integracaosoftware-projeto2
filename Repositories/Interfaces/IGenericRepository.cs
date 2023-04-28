using Prova1BIMIntegracaoSoftwareProjeto2.Entities;

namespace Prova1BIMIntegracaoSoftwareProjeto1.Repositories.Interfaces;

public interface IGenericRepository
{
    public Task Create(List<FolhaCalculada> folhas);
    public Task<List<FolhaCalculada>> Read();
}