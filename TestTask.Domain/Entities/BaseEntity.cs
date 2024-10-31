namespace TestTask.Domain.Entities
{
    using System.ComponentModel.DataAnnotations;

    /// <summary>
    /// The base entity
    /// </summary>
    public abstract class BaseEntity
    {
        /// <summary>
        /// Gets or sets the identifier.
        /// </summary>
        /// <value>
        /// The identifier.
        /// </value>
        [Key]
        [Required]
        public int Id { get; set; }
    }
}