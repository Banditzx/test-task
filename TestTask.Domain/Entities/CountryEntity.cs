namespace TestTask.Domain.Entities
{
    /// <summary>
    /// The CountryEntity.
    /// </summary>
    /// <seealso cref="TestTask.Domain.Entities.BaseEntity" />
    public class CountryEntity : BaseEntity
    {
        /// <summary>
        /// Gets or sets the name.
        /// </summary>
        /// <value>
        /// The name.
        /// </value>
        public string Name { get; set; }

        public virtual ICollection<ProvinceEntity> Provinces { get; set; }
    }
}