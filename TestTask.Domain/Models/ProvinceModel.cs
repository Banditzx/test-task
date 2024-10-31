namespace TestTask.Domain.Models
{
    /// <summary>
    /// The ProvinceModel.
    /// </summary>
    /// <seealso cref="TestTask.Domain.Models.BaseModel" />
    public class ProvinceModel : BaseModel
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
    }
}