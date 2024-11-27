public interface IClientesRepository
{
    public Task<List<Cliente>> GetTodosClientes();
    public Task<Cliente> GetCliente(int id);
    public Task AdicionarCliente(Cliente cliente);
    public Task<Cliente> AtualizaCliente(int id, Cliente clienteAtualizado);
    public Task<Cliente> DeletaCliente(int id);
}