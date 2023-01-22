using System;
using JewelsCafe.Models;

namespace JewelsCafe.Repositories
{
    public class BeverageRepository : IRepository<Beverege>
    {
        private List<Beverege> _repo;

        public BeverageRepository()
        {
            _repo = new();
        }

        public Beverege Add(Beverege item)
        {
            try
            {
                _repo.Add(item);
            }
            catch (Exception ex)
            {
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

