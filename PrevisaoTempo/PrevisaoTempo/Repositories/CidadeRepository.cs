using PrevisaoTempo.Models;

namespace PrevisaoTempo.Repositories
{
    public class CidadeRepository : Repository<Cidade>
    {
        public CidadeRepository(ClimaTempoSimplesContext context) : base(context) { }
    }
}
