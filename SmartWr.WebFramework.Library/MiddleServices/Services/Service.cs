using SmartWr.WebFramework.Library.MiddleServices.Enumerations;
using SmartWr.WebFramework.Library.MiddleServices.Interfaces.Data;
using SmartWr.WebFramework.Library.MiddleServices.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace SmartWr.WebFramework.Library.MiddleServices.Services
{
    public class Service<TEntity> : IService<TEntity>, IDataErrorInfo where TEntity : BaseEntity
    {
        public IUnitOfWork UnitOfWork { get; private set; }
        private readonly IRepository<TEntity> _repository;
        private bool _disposed;
        protected Dictionary<String, String> _errors = new Dictionary<String, String>();
        public Service(IUnitOfWork unitOfWork)
        {
            UnitOfWork = unitOfWork;
            _repository = UnitOfWork.Repository<TEntity>();
        }

        public List<TEntity> GetAll()
        {
            return _repository.GetAll();
        }

        public PaginatedList<TEntity> GetAll(int pageIndex, int pageSize)
        {
            return _repository.GetAll(pageIndex, pageSize);
        }

        public PaginatedList<TEntity> GetAll(int pageIndex, int pageSize, Expression<Func<TEntity, int>> keySelector, OrderBy orderBy = OrderBy.Ascending)
        {
            return _repository.GetAll(pageIndex, pageSize, keySelector, orderBy);
        }

        public PaginatedList<TEntity> GetAll(int pageIndex, int pageSize, Expression<Func<TEntity, int>> keySelector, Expression<Func<TEntity, bool>> predicate, OrderBy orderBy, params Expression<Func<TEntity, object>>[] includeProperties)
        {
            return _repository.GetAll(pageIndex, pageSize, keySelector, predicate, orderBy, includeProperties);
        }

        public TEntity GetById(int id)
        {
            return _repository.GetSingle(id);
        }

        public void Add(TEntity entity)
        {
            _repository.Insert(entity);
            UnitOfWork.SaveChanges();
        }

        public void Update(TEntity entity)
        {
            _repository.Update(entity);
            UnitOfWork.SaveChanges();
        }

        public void Delete(TEntity entity)
        {
            _repository.Delete(entity);
            UnitOfWork.SaveChanges();
        }

        public Task<List<TEntity>> GetAllAsync()
        {
            return _repository.GetAllAsync();
        }

        public Task<PaginatedList<TEntity>> GetAllAsync(int pageIndex, int pageSize)
        {
            return _repository.GetAllAsync(pageIndex, pageSize);
        }

        public Task<PaginatedList<TEntity>> GetAllAsync(int pageIndex, int pageSize, Expression<Func<TEntity, int>> keySelector, OrderBy orderBy = OrderBy.Ascending)
        {
            return _repository.GetAllAsync(pageIndex, pageSize, keySelector, orderBy);
        }

        public Task<PaginatedList<TEntity>> GetAllAsync(int pageIndex, int pageSize, Expression<Func<TEntity, int>> keySelector, Expression<Func<TEntity, bool>> predicate, OrderBy orderBy, params Expression<Func<TEntity, object>>[] includeProperties)
        {
            return _repository.GetAllAsync(pageIndex, pageSize, keySelector, predicate, orderBy, includeProperties);
        }

        public Task<TEntity> GetByIdAsync(int id)
        {
            return _repository.GetSingleAsync(id);
        }

        public Task AddAsync(TEntity entity)
        {
            _repository.Insert(entity);
            //return Task.FromResult<object>(null);
            return UnitOfWork.SaveChangesAsync();
        }

        public Task UpdateAsync(TEntity entity)
        {
            _repository.Update(entity);
            //return Task.FromResult<object>(null);
            return UnitOfWork.SaveChangesAsync();
        }

        public Task DeleteAsync(TEntity entity)
        {
            _repository.Delete(entity);
            //return Task.FromResult<object>(null); 
            return UnitOfWork.SaveChangesAsync();
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        public virtual void Dispose(bool disposing)
        {
            if (!_disposed && disposing)
            {
                UnitOfWork.Dispose();
            }
            _disposed = true;
        }


        public TEntity FirstOrDefault(Func<TEntity, bool> predicate)
        {
            return _repository.GetAll().FirstOrDefault(predicate);
        }


        public string Error
        {
            get
            {
                if (_errors.Count > 0)
                {
                    return _errors.FirstOrDefault().Value;
                }
                return String.Empty;
            }
        }

        public string this[string columnName]
        {
            get
            {
                if (_errors.ContainsKey(columnName))
                {
                    return _errors[columnName];
                }

                return String.Empty;
            }
        }

        public Boolean HasError
        {
            get
            {
                if (_errors.Count > 0)
                {
                    return true;
                }

                return false;
            }
        }
    }
}
