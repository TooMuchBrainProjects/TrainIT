using System.Linq.Expressions;
using Domain.Repsoitories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Domain.Repsoitories.Implementations;

public class ARepository<TEntity> : IRepository<TEntity> where TEntity : class {
    protected DbContext _context;
    protected DbSet<TEntity> _table;
    protected ARepository(DbContext context) {
        _context = context;
        _table = context.Set<TEntity>();
    }

    public TEntity Create(TEntity t)
    {
        _table.Add(t);
        _context.SaveChanges();
        return t;
    }

    public List<TEntity> CreateRange(List<TEntity> list)
    {
        _table.AddRange(list);
        _context.SaveChanges();
        return list;
    }

    public void Update(TEntity t)
    {
        _context.ChangeTracker.Clear();
        _table.Update(t);
        _context.SaveChanges();
    }

    public void UpdateRange(List<TEntity> list)
    {
        _context.ChangeTracker.Clear();
        _table.UpdateRange(list);
        _context.SaveChanges();
    }

    public TEntity? Read(int id) => _table.Find(id);

    public List<TEntity> Read(Expression<Func<TEntity, bool>> filter) => _table.Where(filter).ToList();

    public List<TEntity> Read(int start, int count) =>
        _table.Skip(start)
            .Take(count)
            .ToList();

    public List<TEntity> ReadAll() => _table.ToList();

    public void Delete(TEntity t)
    {
        _table.Remove(t);
        _context.SaveChanges();
    }
    
}