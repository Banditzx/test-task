namespace TestTask.Repositories.Mapper
{
    using AutoMapper;
    using TestTask.Domain.Entities;
    using TestTask.Domain.Models;
    using TestTask.Domain.Models.Pagination;

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

            CreateMap<PaginatedResult<CountryEntity>, PaginatedResult<CountryModel>>()
                .ReverseMap();
        }

        private void InitProvince()
        {
            CreateMap<ProvinceEntity, ProvinceModel>()
                .ReverseMap();

            CreateMap<PaginatedResult<ProvinceEntity>, PaginatedResult<ProvinceModel>>()
                .ReverseMap();
        }

        private void InitAccount()
        {
            CreateMap<AccountEntity, AccountModel>()
                .ReverseMap();
        }
    }
}
