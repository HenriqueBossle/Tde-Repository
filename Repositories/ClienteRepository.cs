
using Microsoft.EntityFrameworkCore;

public class ClienteRepository : IClientesRepository
{
    private readonly AppDbContext _context;
    public ClienteRepository(AppDbContext context)
    {
        _context = context;
    }
    public async Task AdicionarCliente(Cliente cliente)
    {
        await _context.Clientes.AddAsync(cliente);
        await _context.SaveChangesAsync();

    }

    public async Task<Cliente> AtualizaCliente(int id, Cliente clienteAtualizado)
    {
        var cliente = await _context.Clientes.FindAsync(id);
        if(cliente == null)
        {
           return cliente;
        }

        cliente.Nome = clienteAtualizado.Nome;
        cliente.Email = clienteAtualizado.Email;
        cliente.Telefone = clienteAtualizado.Telefone;

        await _context.SaveChangesAsync();
        return cliente;
    }

    public async Task<Cliente> DeletaCliente(int id)
    {
        var cliente = await _context.Clientes.FindAsync(id);
        if(cliente == null)
        {
           return cliente;
        }
        _context.Clientes.Remove(cliente);
        await _context.SaveChangesAsync();
        return cliente;

    }

    public async Task<Cliente> GetCliente(int id)
    {
        return await _context.Clientes.FindAsync(id);
    }

    public async Task<List<Cliente>> GetTodosClientes()
    {
        return await _context.Clientes.ToListAsync();

    }
}