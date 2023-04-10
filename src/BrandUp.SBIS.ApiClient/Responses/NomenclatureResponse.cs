using BrandUp.SBIS.ApiClient.Responses.Common;
using System.Text.Json.Serialization;

namespace BrandUp.SBIS.ApiClient.Responses
{
    public class NomenclatureResponse
    {
        /// <summary>
        /// Список номенклатур
        /// </summary>
        public List<Nomenclature> Nomenclatures { get; set; }
        /// <summary>
        /// Флаг наличия записей на следующей странице
        /// </summary>
        public Outcome Outcome { get; set; }
    }

    public class Nomenclature
    {
        /// <summary>
        /// Артикул наименования
        /// </summary>
        public string Article { get; set; }
        /// <summary>
        /// Массив списков с характеристиками номенклатуры
        /// </summary>
        public Dictionary<string, string> Attributes { get; set; }
        /// <summary>
        /// Остаток товара с учетом открытых смен. Остаток передается по складу точки продаж
        /// </summary>
        public string Balance { get; set; }
        /// <summary>
        /// Цена товара из прайса
        /// </summary>
        public double? Cost { get; set; }
        /// <summary>
        /// Поле «Описание» из карточки номенклатуры
        /// </summary>
        public string Description { get; set; }
        /// <summary>
        /// Хешированное название номенклатурной позиции для запроса подробной информации
        /// </summary>
        public string ExternalId { get; set; }
        /// <summary>
        /// Идентификатор раздела
        /// </summary>
        public int HierarchicalId { get; set; }
        /// <summary>
        /// Идентификатор родительского раздела
        /// </summary>
        public int? HierarchicalParent { get; set; }
        /// <summary>
        /// Идентификатор номенклатуры
        /// </summary>
        public int? Id { get; set; }
        /// <summary>
        /// Массив ссылок на изображение товара
        /// </summary>
        public List<string> Images { get; set; }
        /// <summary>
        /// Порядковый номер в каталоге
        /// </summary>
        public int IndexNumber { get; set; }
        /// <summary>
        /// Массив списков модификаторов
        /// </summary>
        public List<Modifier> Modifiers { get; set; }
        /// <summary>
        /// Название товара
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// Код товара, указанный в карточке номенклатуры
        /// </summary>
        public string NomNumber { get; set; }
        /// <summary>
        /// Короткий код
        /// </summary>
        [JsonPropertyName("short_code")]
        public int? ShortCode { get; set; }
        /// <summary>
        /// Список мастеров, которые могут применять этот товар/услугу
        /// </summary>
        public string Masters { get; set; }
        /// <summary>
        /// Признак публикации номенклатурной позиции
        /// </summary>
        public bool Published { get; set; }
        /// <summary>
        /// Единица измерения
        /// </summary>
        public string Unit { get; set; }
    }

    public class Modifier
    {
        /// <summary>
        /// Идентификатор номенклатурной позиции
        /// </summary>
        public int Id { get; set; }
        /// <summary>
        /// Хешированное название номенклатурной позиции для запроса подробной информации
        /// </summary>
        public string ExternalId { get; set; }
        /// <summary>
        /// Код товара, указанный в карточке номенклатуры
        /// </summary>
        public string NomNumber { get; set; }
        /// <summary>
        /// Название товара
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// Цена модификатора
        /// </summary>
        public double Cost { get; set; }
        /// <summary>
        /// Название единицы измерения
        /// </summary>
        public string Unit { get; set; }
    }
}
