using System;
using JewelsCafe.Models;
using Microsoft.Extensions.Logging;

namespace JewelsCafe.Repositories
{
    public class GenericRepository<T> : IRepository<IFood> where T : IFood
    {
        private readonly string error = $"An exception ocurred while {0} a {nameof(T)}: {1}";
        private readonly ILogger<T> _logger;
        private List<IFood> _repo;

        public GenericRepository(ILogger<T> logger)
        {
            _repo = new();
            _logger = logger;
        }
        
        public IFood Add(IFood item)
        {
            try
            {
                _repo.Add(item);
            }
            catch (Exception ex)
            {
                _logger.LogError(error, "Adding", ex.Message);
                
                throw;
            }

            return item;
        }

        public IEnumerable<IFood> Add(List<IFood> items)
        {
            try
            {
                _repo.AddRange(items);
            }
            catch (Exception ex)
            {
                _logger.LogError(error, "Adding", ex.Message);
                throw;
            }

            return items;
        }

        public void Delete(Guid id)
        {
            var item = _repo.FirstOrDefault(b => b.Id == id);
            if (item == null)
            {
                throw new ArgumentException($"Invalid Id: {id}");
            }

            try
            {
                _repo.Remove(item);
            }
            catch (Exception ex)
            {
                _logger.LogError(error, "Removing", ex.Message);
                throw;
            }
        }

        public IEnumerable<IFood> GetAll()
        {
            return _repo.Select(b => b);
        }

        public IFood GetById(Guid id)
        {
            var item = _repo.FirstOrDefault(b => b.Id == id);

            try
            {
                return item;
            }
            catch (Exception ex)
            {
                _logger.LogError(error, "Getting By Id", ex.Message);
                throw;
            }
        }

        public IEnumerable<IFood> GetByIds(List<Guid> ids)
        {
            throw new NotImplementedException();
        }

        public IFood Update(IFood item)
        {
            throw new NotImplementedException();
        }
    }
}

