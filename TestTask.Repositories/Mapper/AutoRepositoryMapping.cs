namespace TestTask.Repositories.Mapper
{
    using AutoMapper;
    using TestTask.Domain.Entities;
    using TestTask.Domain.Models;

    /// <summary>
    /// The AutoRepositoryMapping.
    /// </summary>
    /// <seealso cref="AutoMapper.Profile" />
    public class AutoRepositoryMapping : Profile
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="AutoRepositoryMapping"/> class.
        /// </summary>
        public AutoRepositoryMapping()
        {
            InitCountry();
            InitProvince();
            InitAccount();
        }

        private void InitCountry()
        {
            CreateMap<CountryEntity, CountryModel>()
                .ReverseMap();
        }

        private void InitProvince()
        {
            CreateMap<ProvinceEntity, ProvinceModel>()
                .ReverseMap();
        }

        private void InitAccount()
        {
            CreateMap<AccountEntity, AccountModel>()
                .ReverseMap();
        }
    }
}
