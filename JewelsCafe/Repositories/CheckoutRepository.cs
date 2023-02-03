using JewelsCafe.Models;
using Microsoft.Extensions.Logging;

namespace JewelsCafe.Repositories
{
    public class CheckoutRepository : IRepository<Checkout>
    {
        private readonly string error = $"An exception ocurred while {0} a {nameof(Checkout)}: {1}";

        private readonly ILogger<CheckoutRepository> _logger;

        private List<Checkout> _repo;

        public CheckoutRepository(ILogger<CheckoutRepository> logger)
        {
            _logger = logger;
            _repo = new();
        }

        public Checkout Add(Checkout item)
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

        public IEnumerable<Checkout> Add(List<Checkout> items)
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

        public void Clear()
        {
            _repo.Clear();
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

        public IEnumerable<Checkout> GetAll()
        {
            return _repo.Select(b => b);
        }

        public Checkout GetById(Guid id)
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

        public IEnumerable<Checkout> GetByIds(List<Guid> ids)
        {
            throw new NotImplementedException();
        }

        public Checkout Update(Checkout item)
        {
            throw new NotImplementedException();
        }
    }
}
