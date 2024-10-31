using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace TestTask.Api.Migrations
{
    /// <inheritdoc />
    public partial class Init : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Countries",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Countries", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Provinces",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CountryId = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Provinces", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Provinces_Countries_CountryId",
                        column: x => x.CountryId,
                        principalTable: "Countries",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Accounts",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CountryId = table.Column<int>(type: "int", nullable: false),
                    ProvinceId = table.Column<int>(type: "int", nullable: false),
                    PremiumType = table.Column<int>(type: "int", nullable: false),
                    CreatedAt = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Accounts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Accounts_Countries_CountryId",
                        column: x => x.CountryId,
                        principalTable: "Countries",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Accounts_Provinces_ProvinceId",
                        column: x => x.ProvinceId,
                        principalTable: "Provinces",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "Countries",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Австралия" },
                    { 2, "Австрия" },
                    { 3, "Азербайджан" },
                    { 4, "Албания" },
                    { 5, "Алжир" },
                    { 6, "Ангола" },
                    { 7, "Андорра" },
                    { 8, "Антигуа и Барбуда" },
                    { 9, "Аргентина" },
                    { 10, "Армения" },
                    { 11, "Афганистан" },
                    { 12, "Багамы" },
                    { 13, "Бангладеш" },
                    { 14, "Барбадос" },
                    { 15, "Бахрейн" },
                    { 16, "Белиз" },
                    { 17, "Белоруссия" },
                    { 18, "Бельгия" },
                    { 19, "Бенин" },
                    { 20, "Болгария" },
                    { 21, "Боливия" },
                    { 22, "Босния и Герцеговина" },
                    { 23, "Ботсвана" },
                    { 24, "Бразилия" },
                    { 25, "Бруней" },
                    { 26, "Буркина-Фасо" },
                    { 27, "Бурунди" },
                    { 28, "Бутан" },
                    { 29, "Вануату" },
                    { 30, "Ватикан" },
                    { 31, "Великобритания" },
                    { 32, "Венгрия" },
                    { 33, "Венесуэла" },
                    { 34, "Восточный Тимор" },
                    { 35, "Вьетнам" },
                    { 36, "Габон" },
                    { 37, "Гаити" },
                    { 38, "Гайана" },
                    { 39, "Гамбия" },
                    { 40, "Гана" },
                    { 41, "Гватемала" },
                    { 42, "Гвинея" },
                    { 43, "Гвинея-Бисау" },
                    { 44, "Германия" },
                    { 45, "Гондурас" },
                    { 46, "Гренада" },
                    { 47, "Греция" },
                    { 48, "Грузия" },
                    { 49, "Дания" },
                    { 50, "Джибути" },
                    { 51, "Доминика" },
                    { 52, "Доминиканская Республика" },
                    { 53, "Египет" },
                    { 54, "Замбия" },
                    { 55, "Зимбабве" },
                    { 56, "Израиль" },
                    { 57, "Индия" },
                    { 58, "Индонезия" },
                    { 59, "Иордания" },
                    { 60, "Ирак" },
                    { 61, "Иран" },
                    { 62, "Ирландия" },
                    { 63, "Исландия" },
                    { 64, "Испания" },
                    { 65, "Италия" },
                    { 66, "Йемен" },
                    { 67, "Кабо-Верде" },
                    { 68, "Казахстан" },
                    { 69, "Камбоджа" },
                    { 70, "Камерун" },
                    { 71, "Канада" },
                    { 72, "Катар" },
                    { 73, "Кения" },
                    { 74, "Кипр" },
                    { 75, "Киргизия" },
                    { 76, "Кирибати" },
                    { 77, "Китай" },
                    { 78, "Колумбия" },
                    { 79, "Коморы" },
                    { 80, "Конго" },
                    { 81, "Конго, Демократическая Республика" },
                    { 82, "Коста-Рика" },
                    { 83, "Кот-д'Ивуар" },
                    { 84, "Куба" },
                    { 85, "Кувейт" },
                    { 86, "Лаос" },
                    { 87, "Латвия" },
                    { 88, "Лесото" },
                    { 89, "Либерия" },
                    { 90, "Ливан" },
                    { 91, "Ливия" },
                    { 92, "Литва" },
                    { 93, "Лихтенштейн" },
                    { 94, "Люксембург" },
                    { 95, "Маврикий" },
                    { 96, "Мавритания" },
                    { 97, "Мадагаскар" },
                    { 98, "Малави" },
                    { 99, "Малайзия" },
                    { 100, "Мали" },
                    { 101, "Мальдивы" },
                    { 102, "Мальта" },
                    { 103, "Марокко" },
                    { 104, "Маршалловы Острова" },
                    { 105, "Мексика" },
                    { 106, "Микронезия" },
                    { 107, "Мозамбик" },
                    { 108, "Молдова" },
                    { 109, "Монако" },
                    { 110, "Монголия" },
                    { 111, "Мьянма" },
                    { 112, "Намибия" },
                    { 113, "Науру" },
                    { 114, "Непал" },
                    { 115, "Нигер" },
                    { 116, "Нигерия" },
                    { 117, "Нидерланды" },
                    { 118, "Никарагуа" },
                    { 119, "Новая Зеландия" },
                    { 120, "Норвегия" },
                    { 121, "Объединенные Арабские Эмираты" },
                    { 122, "Оман" },
                    { 123, "Пакистан" },
                    { 124, "Палау" },
                    { 125, "Панама" },
                    { 126, "Папуа — Новая Гвинея" },
                    { 127, "Парагвай" },
                    { 128, "Перу" },
                    { 129, "Польша" },
                    { 130, "Португалия" },
                    { 131, "Россия" },
                    { 132, "Руанда" },
                    { 133, "Румыния" },
                    { 134, "Сальвадор" },
                    { 135, "Самоа" },
                    { 136, "Сан-Марино" },
                    { 137, "Саудовская Аравия" },
                    { 138, "Северная Македония" },
                    { 139, "Сейшелы" },
                    { 140, "Сенегал" },
                    { 141, "Сент-Винсент и Гренадины" },
                    { 142, "Сент-Китс и Невис" },
                    { 143, "Сент-Люсия" },
                    { 144, "Сербия" },
                    { 145, "Сингапур" },
                    { 146, "Сирия" },
                    { 147, "Словакия" },
                    { 148, "Словения" },
                    { 149, "Соломоновы Острова" },
                    { 150, "Сомали" },
                    { 151, "Судан" },
                    { 152, "Суринам" },
                    { 153, "США" },
                    { 154, "Сьерра-Леоне" },
                    { 155, "Таджикистан" },
                    { 156, "Таиланд" },
                    { 157, "Танзания" },
                    { 158, "Того" },
                    { 159, "Тонга" },
                    { 160, "Тринидад и Тобаго" },
                    { 161, "Тувалу" },
                    { 162, "Тунис" },
                    { 163, "Туркмения" },
                    { 164, "Турция" },
                    { 165, "Уганда" },
                    { 166, "Узбекистан" },
                    { 167, "Украина" },
                    { 168, "Уругвай" },
                    { 169, "Фиджи" },
                    { 170, "Филиппины" },
                    { 171, "Финляндия" },
                    { 172, "Франция" },
                    { 173, "Хорватия" },
                    { 174, "Центральноафриканская Республика" },
                    { 175, "Чад" },
                    { 176, "Черногория" },
                    { 177, "Чехия" },
                    { 178, "Чили" },
                    { 179, "Швейцария" },
                    { 180, "Швеция" },
                    { 181, "Шри-Ланка" },
                    { 182, "Эквадор" },
                    { 183, "Экваториальная Гвинея" },
                    { 184, "Эритрея" },
                    { 185, "Эсватини" },
                    { 186, "Эстония" },
                    { 187, "Эфиопия" },
                    { 188, "Южная Корея" },
                    { 189, "Южно-Африканская Республика" },
                    { 190, "Южный Судан" },
                    { 191, "Ямайка" },
                    { 192, "Япония" }
                });

            migrationBuilder.InsertData(
                table: "Provinces",
                columns: new[] { "Id", "CountryId", "Name" },
                values: new object[,]
                {
                    { 1, 1, "Новый Южный Уэльс" },
                    { 2, 1, "Виктория" },
                    { 3, 1, "Квинсленд" },
                    { 4, 2, "Вена" },
                    { 5, 2, "Штирия" },
                    { 6, 2, "Тироль" },
                    { 7, 3, "Баку" },
                    { 8, 3, "Гянджа" },
                    { 9, 3, "Сумгаит" },
                    { 10, 4, "Тирана" },
                    { 11, 4, "Дуррес" },
                    { 12, 4, "Влёра" },
                    { 13, 5, "Алжир" },
                    { 14, 5, "Оран" },
                    { 15, 5, "Константина" },
                    { 16, 6, "Луанда" },
                    { 17, 6, "Бенгела" },
                    { 18, 6, "Лубанго" },
                    { 19, 7, "Андорра-ла-Велья" },
                    { 20, 7, "Эскальдес" },
                    { 21, 8, "Сент-Джонс" },
                    { 22, 8, "Поттерс" },
                    { 23, 9, "Буэнос-Айрес" },
                    { 24, 9, "Кордова" },
                    { 25, 9, "Мендоса" },
                    { 26, 10, "Ереван" },
                    { 27, 10, "Гюмри" },
                    { 28, 10, "Ванадзор" },
                    { 29, 11, "Кабул" },
                    { 30, 11, "Кандагар" },
                    { 31, 11, "Герат" },
                    { 32, 12, "Нассау" },
                    { 33, 12, "Фрипорт" },
                    { 34, 12, "Марафон" },
                    { 35, 13, "Дакка" },
                    { 36, 13, "Читтагонг" },
                    { 37, 13, "Кхулна" },
                    { 38, 14, "Бриджтаун" },
                    { 39, 15, "Манама" },
                    { 40, 15, "Риффа" },
                    { 41, 16, "Бельмопан" },
                    { 42, 16, "Сан-Игнасио" },
                    { 43, 17, "Минск" },
                    { 44, 17, "Гомель" },
                    { 45, 18, "Брюссель" },
                    { 46, 18, "Антверпен" },
                    { 47, 18, "Гент" },
                    { 48, 19, "Порто-Ново" },
                    { 49, 19, "Котону" },
                    { 50, 20, "София" },
                    { 51, 20, "Пловдив" },
                    { 52, 20, "Варна" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Accounts_CountryId",
                table: "Accounts",
                column: "CountryId");

            migrationBuilder.CreateIndex(
                name: "IX_Accounts_ProvinceId",
                table: "Accounts",
                column: "ProvinceId");

            migrationBuilder.CreateIndex(
                name: "IX_Provinces_CountryId",
                table: "Provinces",
                column: "CountryId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Accounts");

            migrationBuilder.DropTable(
                name: "Provinces");

            migrationBuilder.DropTable(
                name: "Countries");
        }
    }
}
