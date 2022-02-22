using Microsoft.EntityFrameworkCore;
using PrevisaoTempo.Models;
using PrevisaoTempo.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace PrevisaoTempo.Repositories
{
    public class Repository<T> : IRepository<T> where T : class //T (tipo genérico) só pode ser uma classe
    {
        protected ClimaTempoSimplesContext _context;

        public Repository(ClimaTempoSimplesContext context)
        {
            _context = context;
        }

        public void Add(T entity)
        {
            _context.Add(entity);
            _context.SaveChanges();
        }

        public void Delete(T entity)
        {
            throw new NotImplementedException();
        }

        public async Task<List<T>> Get()
        {
            return await _context.Set<T>().AsNoTracking().ToListAsync();
        }

        public async Task<T> GetById(Expression<Func<T, bool>> predicate)
        {
            return await _context.Set<T>().FirstAsync<T>(predicate);
        }

        public void Update(T entity)
        {
            _context.Set<T>().Update(entity);
        }
    }
}
