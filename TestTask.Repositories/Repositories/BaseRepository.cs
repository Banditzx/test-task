namespace TestTask.Repositories.Repositories
{
    using AutoMapper;
    using Microsoft.EntityFrameworkCore;
    using System.Linq.Expressions;

    /// <summary>
    /// The BaseRepository.
    /// </summary>
    public class BaseRepository
    {
        protected readonly StoreEntities _storeEntities;
        protected readonly IMapper _mapper;

        /// <summary>
        /// Initializes a new instance of the <see cref="BaseRepository"/> class.
        /// </summary>
        /// <param name="storeEntities">The store entities.</param>
        public BaseRepository(StoreEntities storeEntities, IMapper mapper)
        {
            _storeEntities = storeEntities;
            _mapper = mapper;
        }
    }

    /// <summary>
    /// The BaseRepository.
    /// </summary>
    public class BaseRepository<T> where T : class
    {
        protected readonly StoreEntities _storeEntities;
        protected readonly IMapper _mapper;

        /// <summary>
        /// Initializes a new instance of the <see cref="BaseRepository"/> class.
        /// </summary>
        /// <param name="storeEntities">The store entities.</param>
        public BaseRepository(StoreEntities storeEntities, IMapper mapper)
        {
            _storeEntities = storeEntities;
            _mapper = mapper;
        }

        /// <summary>
        /// Gets all.
        /// </summary>
        /// <returns>
        /// list.
        /// </returns>
        public IQueryable<T> GetAll()
        {
            return _storeEntities.Set<T>();
        }

        /// <summary>
        /// Gets all by.
        /// </summary>
        /// <param name="predicate">The predicate.</param>
        /// <returns>
        /// list.
        /// </returns>
        public IQueryable<T> GetAllBy(Expression<Func<T, bool>> predicate)
        {
            return _storeEntities.Set<T>().Where(predicate);
        }

        /// <summary>
        /// Gets the by.
        /// </summary>
        /// <param name="predicate">The predicate.</param>
        /// <returns>
        /// T.
        /// </returns>
        public IQueryable<T> GetBy(Expression<Func<T, bool>> predicate)
        {
            return _storeEntities.Set<T>().Where(predicate);
        }

        /// <summary>
        /// Gets the by identifier asynchronous.
        /// </summary>
        /// <param name="predicate">The predicate.</param>
        /// <returns>
        /// T.
        /// </returns>
        public async Task<T> GetByAsync(Expression<Func<T, bool>> predicate)
        {
            return await _storeEntities.Set<T>().Where(predicate).FirstOrDefaultAsync();
        }

        /// <summary>
        /// Gets the count.
        /// </summary>
        /// <returns>
        /// int.
        /// </returns>
        public async Task<int> GetCount()
        {
            return await _storeEntities.Set<T>().CountAsync();
        }

        /// <summary>
        /// Creates the specified data.
        /// </summary>
        /// <param name="data">The data.</param>
        /// <returns>T.</returns>
        public async Task<T> Create(T data)
        {
            var entityEntry = await _storeEntities.Set<T>().AddAsync(data);
            await SaveChangesAsync();
            return entityEntry.Entity;
        }

        /// <summary>
        /// Creates the range.
        /// </summary>
        /// <param name="data">The data.</param>
        /// <returns>IEnumerable T.</returns>
        public async Task<IEnumerable<T>> CreateRange(IEnumerable<T> data)
        {
            await _storeEntities.Set<T>().AddRangeAsync(data);
            await SaveChangesAsync();
            return data;
        }

        /// <summary>
        /// Updates the specified data.
        /// </summary>
        /// <param name="data">The data.</param>
        /// <returns>T.</returns>
        public async Task<T> Update(T data)
        {
            var entityEntry = _storeEntities.Set<T>().Update(data);
            await SaveChangesAsync();
            return entityEntry.Entity;
        }

        /// <summary>
        /// Updates the range.
        /// </summary>
        /// <param name="data">The data.</param>
        /// <returns>IEnumerable T.</returns>
        public async Task<IEnumerable<T>> UpdateRange(IEnumerable<T> data)
        {
            _storeEntities.Set<T>().UpdateRange(data);
            await SaveChangesAsync();
            return data;
        }

        /// <summary>
        /// Deletes the specified data.
        /// </summary>
        /// <param name="data">The data.</param>
        /// <returns>int.</returns>
        public async Task<int> Delete(T data)
        {
            _storeEntities.Set<T>().Remove(data);
            return await SaveChangesAsync();
        }

        /// <summary>
        /// Deletes the range.
        /// </summary>
        /// <param name="data">The data.</param>
        /// <returns>int.</returns>
        public async Task<int> DeleteRange(IEnumerable<T> data)
        {
            _storeEntities.Set<T>().RemoveRange(data);
            return await SaveChangesAsync();
        }

        /// <summary>
        /// Saves the changes.
        /// </summary>
        /// <returns>int.</returns>
        public async Task<int> SaveChangesAsync()
        {
            return await _storeEntities.SaveChangesAsync();
        }
    }
}
