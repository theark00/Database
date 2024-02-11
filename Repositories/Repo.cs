using Microsoft.EntityFrameworkCore.Query.SqlExpressions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using static ConsoleAppDatabase.Program;



namespace ConsoleAppDatabase.Repositories
{
    public class Repo<TEntity> where TEntity : class
    {
        private readonly ContactDbContext _context;

        public Repo(ContactDbContext context)
        {
            _context = context;
        }



        public TEntity Create(TEntity entity)
        {
            _context.Set<TEntity>().Add(entity);
            _context.SaveChanges();
            return entity;
        }

        public IEnumerable <TEntity> GetAll()
        {
            return _context.Set<TEntity>().ToList();
           
        }

        public TEntity Update(Expression<Func<TEntity, bool>> expression, TEntity entity)
        {
            var Update = _context.Set<TEntity>().FirstOrDefault(expression);
            _context.Entry(Update!).CurrentValues.SetValues(entity);
            return Update!;

        }

        public void Delete(Expression<Func<TEntity, bool>> expression)
        {
            var entity = _context.Set<TEntity>().FirstOrDefault(expression);
            _context.Remove(entity!);
            _context.SaveChanges();
        }

    }
}
