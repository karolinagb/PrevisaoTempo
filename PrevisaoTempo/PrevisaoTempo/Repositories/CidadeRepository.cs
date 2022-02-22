using Microsoft.EntityFrameworkCore;
using PrevisaoTempo.Models;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace PrevisaoTempo.Repositories
{
    public class CidadeRepository : Repository<Cidade>
    {
        public CidadeRepository(ClimaTempoSimplesContext context) : base(context) { }

        public async Task<Cidade> ObterCidadeEPrevisoes(int idCidade)
        {
            return await _context.Cidades.Include(x => x.PrevisaoClimas.Where(x => x.DataPrevisao.Date >= 
            DateTime.Now.Date && x.DataPrevisao.Date <= DateTime.Now.Date.AddDays(6)).OrderBy(x => x.DataPrevisao))
                .FirstOrDefaultAsync(x => x.Id == idCidade);
        }
    }
}
