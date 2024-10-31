namespace TestTask.Domain.Models.Pagination
{
    using System;
    using System.Collections.Generic;

    /// <summary>
    /// The PaginatedResult.
    /// </summary>
    /// <typeparam name="TEntity">The type of the entity.</typeparam>
    public class PaginatedResult<TEntity>
    {
        public PaginatedResult()
        {
        }

        /// <summary>
        /// Gets or sets the total items.
        /// </summary>
        /// <value>
        /// The total items.
        /// </value>
        public long TotalItems { get; set; }

        /// <summary>
        /// Gets or sets the pagination with sort.
        /// </summary>
        /// <value>
        /// The pagination with sort.
        /// </value>
        public PaginationParameters PaginationParameters { get; set; }

        /// <summary>
        /// Gets or sets the items.
        /// </summary>
        /// <value>
        /// The items.
        /// </value>
        public IEnumerable<TEntity> Items { get; set; }

        /// <summary>
        /// Gets the total pages.
        /// </summary>
        /// <value>
        /// The total pages.
        /// </value>
        public int TotalPages => (int)Math.Ceiling((double)TotalItems / PaginationParameters.Size);

        /// <summary>
        /// Gets a value indicating whether this instance is last.
        /// </summary>
        /// <value>
        ///   <c>true</c> if this instance is last; otherwise, <c>false</c>.
        /// </value>
        public bool IsLast => TotalPages <= PaginationParameters.Page;

        /// <summary>
        /// Gets a value indicating whether this instance is first.
        /// </summary>
        /// <value>
        ///   <c>true</c> if this instance is first; otherwise, <c>false</c>.
        /// </value>
        public bool IsFirst => PaginationParameters.Page == 1;
    }
}
