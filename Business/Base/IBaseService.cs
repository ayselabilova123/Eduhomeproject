using DAL.Entity;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Business.Base
{
    public interface IBaseService<TEntity>
         where TEntity : class, IEntity, new()
    {

        Task<IEntity> Get(int? id);
        Task<List<TEntity>> GetAll();
        Task Create(TEntity entity);
        Task Update(int id, TEntity entity);
        Task Delete(int? id);
    }
}
