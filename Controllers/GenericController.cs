using Microsoft.AspNetCore.Mvc;
using Prova1BIMIntegracaoSoftwareProjeto1.Repositories.Interfaces;
using Prova1BIMIntegracaoSoftwareProjeto2.Entities;

namespace Prova1BIMIntegracaoSoftwareProjeto1.Controllers;

[ApiController]
[Route("[controller]")]
public class GenericController : ControllerBase
{
    private readonly IGenericRepository _repository;

    public GenericController(IGenericRepository repository)
    {
        _repository = repository;
    }
    
    [HttpPost]
    [Route("SaveFolhas")]
    public async Task<IActionResult> SaveFolhas([FromBody] List<FolhaCalculada> folhas)
    {
        await _repository.Create(folhas);
        return Ok();
    }
    
    [HttpGet]
    [Route("Read")]
    public async Task<IActionResult> Read()
    {
        var folhas = await _repository.Read();
        return Ok(folhas);
    }
    
}