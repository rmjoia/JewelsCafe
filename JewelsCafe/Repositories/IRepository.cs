using System;
namespace JewelsCafe.Repositories
{
	public interface IRepository<T>  where T : class
	{
		T Add(T item);
		IEnumerable<T> Add(List<T> items);
		T GetById(Guid id);
        IEnumerable<T> GetByIds(List<Guid> ids);
        IEnumerable<T> GetAll();
		T Update(T item);
		void Delete(Guid id);
        public void Clear();
    }
}

