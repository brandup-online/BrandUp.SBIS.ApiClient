using BrandUp.SBIS.ApiClient.Shop.Responses.Common;

namespace BrandUp.SBIS.ApiClient.Shop.Responses
{
    public class SalesPointResponse
    {
        /// <summary>
        /// Список точек продаж
        /// </summary>
        public List<SalesPoint> SalesPoints { get; set; }
        /// <summary>
        /// Признак наличия записей на следующей странице
        /// </summary>
        public Outcome Outcome { get; set; }
    }

    /// <summary>
    /// Описание точки продажи
    /// </summary>
    public class SalesPoint
    {
        /// <summary>
        /// Идентификатор точки продаж, который будет передаваться в другие запросы как параметр «pointId»
        /// </summary>
        public int Id { get; set; }
        /// <summary>
        /// Коммерческое название
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// Фактический адрес
        /// </summary>
        public string Address { get; set; }
        /// <summary>
        /// Город
        /// </summary>
        public string Locality { get; set; }
        /// <summary>
        /// Картинка для точки продаж
        /// </summary>
        public string Image { get; set; }
        /// <summary>
        /// Прайс по умолчанию
        /// </summary>
        public int? DefaultPriceList { get; set; }
        /// <summary>
        /// Первый номер телефона в списке
        /// </summary>
        public string Phone { get; set; }
        /// <summary>
        /// Список телефонов
        /// </summary>
        public List<string> Phones { get; set; }
        /// <summary>
        /// Режим работы
        /// </summary>
        public WorkSchedule Worktime { get; set; }
        /// <summary>
        /// Координаты по широте
        /// </summary>
        public string Latitude { get; set; }
        /// <summary>
        /// Координаты по долготе
        /// </summary>
        public string Longitude { get; set; }
        /// <summary>
        /// Список товаров
        /// </summary>
        public List<string> Product { get; set; }
        /// <summary>
        /// Список идентификаторов прайс-листов
        /// </summary>
        public List<int> Prices { get; set; }
        /// <summary>
        /// Список залов и столиков
        /// </summary>
        public List<Hall> Halls { get; set; }
    }

    public class WorkSchedule
    {
        /// <summary>
        /// Начало рабочего дня
        /// </summary>
        public string Start { get; set; }
        /// <summary>
        /// Конец рабочего дня
        /// </summary>
        public string Stop { get; set; }
        /// <summary>
        /// Рабочие дни
        /// </summary>
        public int[] Workdays { get; set; }
        /// <summary>
        /// Расписание
        /// </summary>
        public Schedule Schedule { get; set; }
    }

    public class Schedule
    {
        /// <summary>
        /// Основное расписание
        /// </summary>
        public List<MainSchedule> MainSchedule { get; set; }
        /// <summary>
        /// Исключения из расписания
        /// </summary>
        public List<ExceptionSchedule> ExceptionSchedule { get; set; }
    }


    public class Hall
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public Plan Plan { get; set; }
    }

    /// <summary>
    /// Время работы в течении дня
    /// </summary>
    public class MainSchedule
    {
        /// <summary>
        /// Дни работы
        /// </summary>
        public int[] DaysOfTheWeek { get; set; }
        /// <summary>
        /// Начало рабочего дня
        /// </summary>
        public int WorkStartTime { get; set; }
        /// <summary>
        /// Конец рабочего дня
        /// </summary>
        public int WorkEndTime { get; set; }
        /// <summary>
        /// Начало перерыва
        /// </summary>
        public int BreakStartTime { get; set; }
        /// <summary>
        /// Конец перерыва
        /// </summary>
        public int BreakEndTime { get; set; }
    }

    public class ExceptionSchedule
    {
        /// <summary>
        /// Дни, исключенные из рабочего расписания
        /// </summary>
        public string[] ExceptionIntervalDates { get; set; }
        /// <summary>
        /// Начало рабочего дня
        /// </summary>
        public int WorkStartTime { get; set; }
        /// <summary>
        /// Конец рабочего дня
        /// </summary>
        public int WorkEndTime { get; set; }
        /// <summary>
        /// Начало перерыва
        /// </summary>
        public int BreakStartTime { get; set; }
        /// <summary>
        /// Конец перерыва
        /// </summary>
        public int BreakEndTime { get; set; }
    }

    /// <summary>
    /// Настройки фонового изображения
    /// </summary>
    public class Background
    {
        public string Position { get; set; }
        public string Repeat { get; set; }
        public int Size { get; set; }
        public string Url { get; set; }
    }

    /// <summary>
    /// Координаты относительно начальной точки экрана
    /// </summary>
    public class Relation
    {
        public int Left { get; set; }
        public int Top { get; set; }
        public int Right { get; set; }
        public int Bottom { get; set; }
    }

    /// <summary>
    /// Возможность брони объекта
    /// </summary>
    public class Booking
    {
        public bool Enabled { get; set; }
        public bool Busy { get; set; }
        public int Capacity { get; set; }
        public string EndTime { get; set; }
    }

    public class Item
    {
        /// <summary>
        /// Описание объектов схемы зала
        /// </summary>
        public int Id { get; set; }
        public int Kind { get; set; }
        public string Name { get; set; }
        /// <summary>
        /// Координаты объекта схемы зала
        /// </summary>
        public Position Position { get; set; }
        /// <summary>
        /// Возможность брони объекта
        /// </summary>
        public Booking Booking { get; set; }
    }
    /// <summary>
    /// Координаты объекта схемы зала
    /// </summary>
    public class Position
    {
        public int X { get; set; }
        public int Y { get; set; }
        public int Z { get; set; }
    }

    /// <summary>
    /// Схема зала
    /// </summary>
    public class Plan
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public bool Active { get; set; }
        /// <summary>
        /// Настройки фонового изображения
        /// </summary>
        public Background Background { get; set; }
        /// <summary>
        /// Координаты относительно начальной точки экрана
        /// </summary>
        public Relation Relation { get; set; }
        /// <summary>
        /// Описание объектов схемы зала
        /// </summary>
        public List<Item> Items { get; set; }
    }
}
