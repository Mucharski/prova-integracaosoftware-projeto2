using Dapper;
using Microsoft.Data.Sqlite;
using Prova1BIMIntegracaoSoftwareProjeto1.Repositories.Interfaces;
using Prova1BIMIntegracaoSoftwareProjeto2.Entities;

namespace Prova1BIMIntegracaoSoftwareProjeto1.Repositories;

public class GenericRepository : IGenericRepository
{
    private readonly SqliteConnection _connection = new("Data Source=C:\\Users\\igorm\\Documents\\Dev\\Prova1BIMIntegracaoSoftwareProjeto1\\databaseProva.db");

    public async Task Create(List<FolhaCalculada> folhas)
    {
        await _connection.OpenAsync();

        foreach (var folha in folhas)
        {
            await _connection.QueryAsync(
                "INSERT INTO folhaProcessada (mes, ano, horas, valor, bruto, irrf, inss, fgts, liquido)" +
                "VALUES (@mes, @ano, @horas, @valor, @bruto, @irff, @inss, @fgts, @liquido)"
                , new
                {
                    mes = folha.Mes,
                    ano = folha.Ano,
                    horas = folha.Horas,
                    valor = folha.Valor,
                    bruto = folha.Bruto,
                    irff = folha.Irrf,
                    inss = folha.Inss,
                    fgts = folha.Fgts,
                    liquido = folha.Liquido
                });
        }
    }
    
    public async Task<List<FolhaCalculada>> Read()
    {
        await _connection.OpenAsync();

        return (await _connection.QueryAsync<FolhaCalculada>("SELECT * FROM folhaProcessada")).ToList();
    }

}