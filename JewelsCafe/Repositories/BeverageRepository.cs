using System;
using JewelsCafe.Models;
using Microsoft.Extensions.Logging;

namespace JewelsCafe.Repositories
{
    public class BeverageRepository : IRepository<Beverege>
    {
        private readonly string error = "An exception ocurred while {0} a Beverege: {1}";
        private readonly ILogger<BeverageRepository> _logger;
        private List<Beverege> _repo;

        public BeverageRepository(ILogger<BeverageRepository> logger)
        {
            _repo = new();
            _logger = logger;
        }
        
        public Beverege Add(Beverege item)
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

        public IEnumerable<Beverege> Add(List<Beverege> items)
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

        public IEnumerable<Beverege> GetAll()
        {
            return _repo.Select(b => b);
        }

        public Beverege GetById(Guid id)
        {
            var item = _repo.FirstOrDefault(b => b.Id == id);

            if (item == null)
            {
                throw new ArgumentException($"Invalid Id: {id}");
            }

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

        public IEnumerable<Beverege> GetByIds(List<Guid> ids)
        {
            throw new NotImplementedException();
        }

        public Beverege Update(Beverege item)
        {
            throw new NotImplementedException();
        }
    }
}

