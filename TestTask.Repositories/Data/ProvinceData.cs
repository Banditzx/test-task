namespace TestTask.Repositories.Data
{
    using TestTask.Domain.Entities;

    /// <summary>
    /// The ProvinceData.
    /// </summary>
    public static class ProvinceData
    {
        /// <summary>
        /// The value.
        /// </summary>
        public static List<ProvinceEntity> Value = new List<ProvinceEntity>
        {
            new ProvinceEntity { Id = 1, CountryId = 1, Name = "Новый Южный Уэльс" },
            new ProvinceEntity { Id = 2, CountryId = 1, Name = "Виктория" },
            new ProvinceEntity { Id = 3, CountryId = 1, Name = "Квинсленд" },
            new ProvinceEntity { Id = 4, CountryId = 2, Name = "Вена" },
            new ProvinceEntity { Id = 5, CountryId = 2, Name = "Штирия" },
            new ProvinceEntity { Id = 6, CountryId = 2, Name = "Тироль" },
            new ProvinceEntity { Id = 7, CountryId = 3, Name = "Баку" },
            new ProvinceEntity { Id = 8, CountryId = 3, Name = "Гянджа" },
            new ProvinceEntity { Id = 9, CountryId = 3, Name = "Сумгаит" },
            new ProvinceEntity { Id = 10, CountryId = 4, Name = "Тирана" },
            new ProvinceEntity { Id = 11, CountryId = 4, Name = "Дуррес" },
            new ProvinceEntity { Id = 12, CountryId = 4, Name = "Влёра" },
            new ProvinceEntity { Id = 13, CountryId = 5, Name = "Алжир" },
            new ProvinceEntity { Id = 14, CountryId = 5, Name = "Оран" },
            new ProvinceEntity { Id = 15, CountryId = 5, Name = "Константина" },
            new ProvinceEntity { Id = 16, CountryId = 6, Name = "Луанда" },
            new ProvinceEntity { Id = 17, CountryId = 6, Name = "Бенгела" },
            new ProvinceEntity { Id = 18, CountryId = 6, Name = "Лубанго" },
            new ProvinceEntity { Id = 19, CountryId = 7, Name = "Андорра-ла-Велья" },
            new ProvinceEntity { Id = 20, CountryId = 7, Name = "Эскальдес" },
            new ProvinceEntity { Id = 21, CountryId = 8, Name = "Сент-Джонс" },
            new ProvinceEntity { Id = 22, CountryId = 8, Name = "Поттерс" },
            new ProvinceEntity { Id = 23, CountryId = 9, Name = "Буэнос-Айрес" },
            new ProvinceEntity { Id = 24, CountryId = 9, Name = "Кордова" },
            new ProvinceEntity { Id = 25, CountryId = 9, Name = "Мендоса" },
            new ProvinceEntity { Id = 26, CountryId = 10, Name = "Ереван" },
            new ProvinceEntity { Id = 27, CountryId = 10, Name = "Гюмри" },
            new ProvinceEntity { Id = 28, CountryId = 10, Name = "Ванадзор" },
            new ProvinceEntity { Id = 29, CountryId = 11, Name = "Кабул" },
            new ProvinceEntity { Id = 30, CountryId = 11, Name = "Кандагар" },
            new ProvinceEntity { Id = 31, CountryId = 11, Name = "Герат" },
            new ProvinceEntity { Id = 32, CountryId = 12, Name = "Нассау" },
            new ProvinceEntity { Id = 33, CountryId = 12, Name = "Фрипорт" },
            new ProvinceEntity { Id = 34, CountryId = 12, Name = "Марафон" },
            new ProvinceEntity { Id = 35, CountryId = 13, Name = "Дакка" },
            new ProvinceEntity { Id = 36, CountryId = 13, Name = "Читтагонг" },
            new ProvinceEntity { Id = 37, CountryId = 13, Name = "Кхулна" },
            new ProvinceEntity { Id = 38, CountryId = 14, Name = "Бриджтаун" },
            new ProvinceEntity { Id = 39, CountryId = 15, Name = "Манама" },
            new ProvinceEntity { Id = 40, CountryId = 15, Name = "Риффа" },
            new ProvinceEntity { Id = 41, CountryId = 16, Name = "Бельмопан" },
            new ProvinceEntity { Id = 42, CountryId = 16, Name = "Сан-Игнасио" },
            new ProvinceEntity { Id = 43, CountryId = 17, Name = "Минск" },
            new ProvinceEntity { Id = 44, CountryId = 17, Name = "Гомель" },
            new ProvinceEntity { Id = 45, CountryId = 18, Name = "Брюссель" },
            new ProvinceEntity { Id = 46, CountryId = 18, Name = "Антверпен" },
            new ProvinceEntity { Id = 47, CountryId = 18, Name = "Гент" },
            new ProvinceEntity { Id = 48, CountryId = 19, Name = "Порто-Ново" },
            new ProvinceEntity { Id = 49, CountryId = 19, Name = "Котону" },
            new ProvinceEntity { Id = 50, CountryId = 20, Name = "София" },
            new ProvinceEntity { Id = 51, CountryId = 20, Name = "Пловдив" },
            new ProvinceEntity { Id = 52, CountryId = 20, Name = "Варна" },
        };

        /// <summary>
        /// Gets the brand.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns>CountryEntity.</returns>
        public static ProvinceEntity GetBrand(int id)
        {
            return Value.Find(x => x.Id == id);
        }
    }
}