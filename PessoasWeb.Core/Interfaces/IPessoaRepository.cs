using PessoasWeb.Core.Entities;

namespace PessoasWeb.Core.Interfaces
{
    public interface IPessoaRepository
    {
        Task<IEnumerable<Pessoa>> GetPessoasAsync();
        Task<Pessoa> GetPessoasByNomeAsync(string nome);

        Task AddPessoaAsync(Pessoa pessoa);
        Task UpdatePessoaAsync(Pessoa pessoa);
        Task RemovePessoaAsync(int id);
    }
}
