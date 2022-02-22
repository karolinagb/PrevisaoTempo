using Microsoft.EntityFrameworkCore;
using PrevisaoTempo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PrevisaoTempo.Repositories
{
    public class PrevisaoClimaRepository : Repository<PrevisaoClima>
    {
        public PrevisaoClimaRepository(ClimaTempoSimplesContext context) : base(context) { }

        public async Task<List<PrevisaoClima>> ObterCidadesMaisQuentes(int quantidadeLinhas)
        {
            return await _context.PrevisaoClimas.Include(x => x.Cidade).ThenInclude(x => x.Estado)
                .Where(x => x.DataPrevisao == DateTime.Now.Date)
                .OrderByDescending(x => x.TemperaturaMaxima).Take(quantidadeLinhas).AsNoTracking().ToListAsync();
        }

        public async Task<List<PrevisaoClima>> ObterCidadesMaisFrias(int quantidadeLinhas)
        {
            return await _context.PrevisaoClimas.Include(x => x.Cidade).ThenInclude(x => x.Estado)
                .Where(x => x.DataPrevisao == DateTime.Now.Date)
                .OrderBy(x => x.TemperaturaMinima).Take(quantidadeLinhas).AsNoTracking().ToListAsync();
        }
    }
}
