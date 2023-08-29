using core.Interfaces;
using Microsoft.AspNetCore.Mvc;
using core.Entities;
using AutoMapper;
using API.Dtos;

namespace API.Controllers;

public class EstadoController : BaseApiController
{
    private readonly IUnitOfWork unitofwork;
    private readonly IMapper mapper;

    public EstadoController(IUnitOfWork unitofwork, IMapper mapper)
    {
        this.unitofwork = unitofwork;
        this.mapper = mapper;
    }
    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]

    public async Task<ActionResult<IEnumerable<EstadoDto>>> Get()
    {
        var estados = await unitofwork.Estados.GetAllAsync();
        return mapper.Map<List<EstadoDto>>(estados);
    }

    [HttpGet("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]

    public async Task<ActionResult<EstadoDto>> Get(int id)
    {
        var estados = await unitofwork.Estados.GetByIdAsync(id);
        if(estados == null){
            return NotFound();
        }
        return this.mapper.Map<EstadoDto>(estados);
    }

    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]

    public async Task<ActionResult<Estado>> Post(EstadoDto estadoDto)
    {
        var estado = this.mapper.Map<Estado>(estadoDto);
        unitofwork.Estados.Add(estado);
        await unitofwork.SaveAsync();
        if(estado == null)
        {
            return BadRequest();
        }
        return CreatedAtAction(nameof(Post), new {id = estado.Id}, estado);
    }

}