namespace TestTask.Infrastructure.Extensions
{
    using System.Linq;
    using System.Threading.Tasks;
    using TestTask.Domain.Models.Pagination;

    /// <summary>
    /// The PaginationExtentions.
    /// </summary>
    public static class PaginationExtentions
    {
        /// <summary>
        /// Paginateds the specified pagination parameters.
        /// </summary>
        /// <typeparam name="TEntity">The type of the entity.</typeparam>
        /// <param name="source">The source.</param>
        /// <param name="paginationParameters">The pagination parameters.</param>
        /// <returns>PaginatedResult TEntity.</returns>
        public static Task<PaginatedResult<TEntity>> Paginated<TEntity>(this IQueryable<TEntity> source, PaginationParameters paginationParameters)
        {
            var totalItems = source.Count();
            var items = source
                .Skip(paginationParameters.Skip)
                .Take(paginationParameters.Size)
                .ToList();

            return Task.FromResult(new PaginatedResult<TEntity>
            {
                PaginationParameters = paginationParameters,
                Items = items,
                TotalItems = totalItems,
            });
        }

        /// <summary>
        /// Paginateds the specified pagination parameters.
        /// </summary>
        /// <typeparam name="TEntity">The type of the entity.</typeparam>
        /// <param name="source">The source.</param>
        /// <param name="paginationParameters">The pagination parameters.</param>
        /// <returns>PaginatedResult TEntity.</returns>
        public static PaginatedResult<TEntity> Paginated<TEntity>(this IEnumerable<TEntity> source, PaginationParameters paginationParameters)
        {
            var totalItems = source.Count();
            var items = source
                .Skip(paginationParameters.Skip)
                .Take(paginationParameters.Size)
                .ToList();

            return new PaginatedResult<TEntity>
            {
                PaginationParameters = paginationParameters,
                Items = items,
                TotalItems = totalItems,
            };
        }
    }
}
