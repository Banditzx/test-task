namespace TestTask.Domain.Entities
{
    /// <summary>
    /// The ProvinceEntity.
    /// </summary>
    /// <seealso cref="TestTask.Domain.Entities.BaseEntity" />
    public class ProvinceEntity : BaseEntity
    {
        /// <summary>
        /// Gets or sets the country identifier.
        /// </summary>
        /// <value>
        /// The country identifier.
        /// </value>
        public int CountryId { get; set; }

        /// <summary>
        /// Gets or sets the name.
        /// </summary>
        /// <value>
        /// The name.
        /// </value>
        public string Name { get; set; }

        public virtual CountryEntity Country { get; set; }
    }
}