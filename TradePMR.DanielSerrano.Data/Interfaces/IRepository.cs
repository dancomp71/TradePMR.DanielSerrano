using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace TradePMR.DanielSerrano.Data.Interfaces
{
    public interface IRepository<TEntity>
    {
        /// <summary>
        /// get all entities
        /// </summary>
        IEnumerable<TEntity> GetAll();

        /// <summary>
        /// get an entity by id
        /// </summary>
        TEntity GetById(int id);

        /// <summary>
        /// add an entity
        /// </summary>
        TEntity Add(TEntity account);

        /// <summary>
        /// update an existing entity
        /// </summary>
        TEntity Update(TEntity account);

        /// <summary>
        /// delete an existing entity
        /// </summary>
        TEntity Delete(int id);

        /// <summary>
        /// handle parameter validation
        /// </summary>
        IEnumerable<ValidationResult> Validate(TEntity entity);
    }
}
