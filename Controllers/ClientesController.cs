using Microsoft.AspNetCore.Mvc;
[ApiController]
[Route("[controller]")]
public class ClientesController : ControllerBase
{
    private readonly IClientesRepository _repository;
    public ClientesController(IClientesRepository repository)
    {
        _repository = repository;
    }

    [HttpGet]
    public async Task<ActionResult<List<Cliente>>> Get()
    {
        var clientes = await _repository.GetTodosClientes();
        return Ok(clientes);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<Cliente>> Get(int id)
    {
        var cliente = await _repository.GetCliente(id);
        if(cliente == null)
        {
           return NotFound();
        }
        return Ok(cliente);
    }

    [HttpPost]
    public async Task<ActionResult> Post(Cliente cliente)
    {
        await _repository.AdicionarCliente(cliente);
        return Created();
    }

    [HttpPut("{id}")]
    public ActionResult Put(int id, Cliente clienteAtualizado)
    {
        var cliente = _repository.AtualizaCliente(id, clienteAtualizado);
        if(cliente == null)
        {
            return NotFound();
        }
        
        return Ok();
    }

    [HttpDelete("{id}")]
    public ActionResult Delete(int id)
    {
        var clienteParaRemover = _repository.DeletaCliente(id);
        if(clienteParaRemover == null)
        {
            return NotFound();
        }
        
        return Ok();
    }


}