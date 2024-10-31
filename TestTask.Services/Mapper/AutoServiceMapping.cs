namespace TestTask.Services.Mapper
{
    using AutoMapper;
    using TestTask.Domain.Models;
    using TestTask.Infrastructure.Dto.Account;
    using TestTask.Infrastructure.Dto.Support;

    /// <summary>
    /// The AutoServiceMapping.
    /// </summary>
    /// <seealso cref="AutoMapper.Profile" />
    public class AutoServiceMapping : Profile
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="AutoServiceMapping"/> class.
        /// </summary>
        public AutoServiceMapping()
        {
            InitCountry();
            InitProvince();
            InitAccount();
        }

        private void InitCountry()
        {
            CreateMap<CountryModel, CountryDto>()
                .ReverseMap();
        }

        private void InitProvince()
        {
            CreateMap<ProvinceModel, ProvinceDto>()
                .ReverseMap();
        }

        private void InitAccount()
        {
            CreateMap<AccountModel, AccountDto>()
                .ReverseMap();
        }
    }
}