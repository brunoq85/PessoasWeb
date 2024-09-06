using Dapper;
using Microsoft.Data.SqlClient;
using Microsoft.Identity.Client;
using PessoasWeb.Core.Entities;
using PessoasWeb.Core.Interfaces;
using PessoasWeb.Infra.Data.Context;

namespace PessoasWeb.Infra.Data
{
    public class PessoaRepository : IPessoaRepository
    {
        private readonly AppDbContext _appDbContext;
        private readonly DapperDbContext _dapperDbContext;

        public PessoaRepository(AppDbContext appDbContext, DapperDbContext dapperDbContext)
        {
            _appDbContext = appDbContext;
            _dapperDbContext = dapperDbContext;
        }

        public async Task<IEnumerable<Pessoa>> GetPessoasAsync()
        {
            using(var connection = new SqlConnection(_dapperDbContext.GetConnection().ConnectionString))
            {
                var query = "SELECT * FROM Pessoas";

                var result = await connection.QueryAsync<Pessoa>(query);

                return result.ToList();
            }
        }

        public async Task<Pessoa> GetPessoasByNomeAsync(string nome)
        {
            using (var connection = new SqlConnection(_dapperDbContext.GetConnection().ConnectionString))
            {
                var param = new DynamicParameters();

                var query = "SELECT * FROM Pessoas WHERE Nome = @Nome";

                param.Add("@Nome", nome);

                var result = await connection.QueryFirstOrDefaultAsync<Pessoa>(query, param);

                return result;
            }
        }

        public   async Task AddPessoaAsync(Pessoa pessoa)
        {
            _appDbContext.Pessoas.Add(pessoa);
            await _appDbContext.SaveChangesAsync();
        }

        public async Task UpdatePessoaAsync(Pessoa pessoa)
        {
            _appDbContext.Pessoas.Update(pessoa);
            await _appDbContext.SaveChangesAsync();
        }

        public async Task RemovePessoaAsync(int id)
        {
            var pessoa = await _appDbContext.Pessoas.FindAsync(id);

            if (pessoa != null)
            {
                _appDbContext.Pessoas.Remove(pessoa);
                await _appDbContext.SaveChangesAsync();
            }
        }
    }
}
