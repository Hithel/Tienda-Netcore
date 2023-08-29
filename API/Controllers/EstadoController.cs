using core.Interfaces;
using Microsoft.AspNetCore.Mvc;
using core.Entities;

namespace API.Controllers;

public class EstadoController : BaseApiController
{
    private readonly IUnitOfWork unitofwork;

    public EstadoController(IUnitOfWork unitOfWork)
    {
        this.unitofwork = unitOfWork;
    }
    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]

    public async Task<ActionResult<IEnumerable<Estado>>> Get()
    {
        var estados = await unitofwork.Estados.GetAllAsync();
        return Ok(estados);
    }

    [HttpGet("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]

    public async Task<ActionResult> Get(int id)
    {
        var estados = await unitofwork.Estados.GetByIdAsync(id);
        return Ok(estados);
    }

    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]

    public async Task<ActionResult<Estado>> Post(Estado estado)
    {
        unitofwork.Estados.Add(estado);
        await unitofwork.SaveAsync();
        if(estado == null)
        {
            return BadRequest();
        }
        return CreatedAtAction(nameof(Post), new {id = estado.Id}, estado);
    }

}