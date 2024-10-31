namespace TestTask.Domain.Models.Pagination
{
    /// <summary>
    /// The PaginationParameters.
    /// </summary>
    public class PaginationParameters
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="PaginationParameters"/> class.
        /// </summary>
        public PaginationParameters() { }

        /// <summary>
        /// Initializes a new instance of the <see cref="PaginationParameters"/> class.
        /// </summary>
        /// <param name="page">The page.</param>
        /// <param name="size">The size.</param>
        public PaginationParameters(int page, int size)
        {
            Page = page;
            Size = size;
        }

        /// <summary>
        /// Gets or sets the page.
        /// </summary>
        /// <value>
        /// The page.
        /// </value>
        public int Page { get; set; }

        /// <summary>
        /// Gets or sets the size.
        /// </summary>
        /// <value>
        /// The size.
        /// </value>
        public int Size { get; set; }

        /// <summary>
        /// Gets the skip.
        /// </summary>
        /// <value>
        /// The skip.
        /// </value>
        public int Skip => (Page - 1) * Size;
    }
}
