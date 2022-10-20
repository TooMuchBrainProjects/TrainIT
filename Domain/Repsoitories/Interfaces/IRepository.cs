using System.Linq.Expressions;

namespace Domain.Repsoitories.Interfaces;

public interface IRepository<TEntity> where TEntity :
    class {
    
// Anlegen einer Entitaet
    TEntity Create(TEntity t);
    
// Anlegen mehrerer Entitaeten
    List<TEntity> CreateRange(List<TEntity> list); 
    
// Aendern einer Entitaet
    void Update(TEntity t);
    
// Aendern mehrerer Entitaeten
    void UpdateRange(List<TEntity> list);
    
    TEntity? Read(int id);
    
    List<TEntity> Read(Expression<Func<TEntity, bool>> filter);
    
    List<TEntity> Read(int start, int count);
    
    List<TEntity> ReadAll();
    
    void Delete (TEntity t);
}
