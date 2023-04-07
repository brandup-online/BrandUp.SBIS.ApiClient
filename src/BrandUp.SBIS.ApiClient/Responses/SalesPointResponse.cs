using BrandUp.SBIS.ApiClient.Responses.Common;

namespace BrandUp.SBIS.ApiClient.Responses
{
    public class SalesPointResponse
    {
        public List<SalesPoint> SalesPoints { get; set; }
        public Outcome Outcome { get; set; }
    }

    public class SalesPoint
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string Locality { get; set; }
        public string Image { get; set; }
        public int? DefaultPriceList { get; set; }
        public string Phone { get; set; }
        public List<string> Phones { get; set; }
        public WorkSchedule Worktime { get; set; }
        public string Latitude { get; set; }
        public string Longitude { get; set; }
        public List<string> Product { get; set; }
        public List<int> Prices { get; set; }
        public List<Hall> Halls { get; set; }
    }

    public class WorkSchedule
    {
        public string Start { get; set; }
        public string Stop { get; set; }
        public int[] Workdays { get; set; }
        public Schedule Schedule { get; set; }
    }

    public class Schedule
    {
        public List<MainSchedule> MainSchedule { get; set; }
        public List<ExceptionSchedule> ExceptionSchedule { get; set; }
    }


    public class Hall
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public Plan Plan { get; set; }
    }

    public class MainSchedule
    {
        public int[] DaysOfTheWeek { get; set; }
        public int WorkStartTime { get; set; }
        public int WorkEndTime { get; set; }
        public int BreakStartTime { get; set; }
        public int BreakEndTime { get; set; }
    }

    public class ExceptionSchedule
    {
        public string[] ExceptionIntervalDates { get; set; }
        public int WorkStartTime { get; set; }
        public int WorkEndTime { get; set; }
        public int BreakStartTime { get; set; }
        public int BreakEndTime { get; set; }
    }

    public class Background
    {
        public string Position { get; set; }
        public string Repeat { get; set; }
        public int Size { get; set; }
        public string Url { get; set; }
    }

    public class Relation
    {
        public int Left { get; set; }
        public int Top { get; set; }
        public int Right { get; set; }
        public int Bottom { get; set; }
    }

    public class Booking
    {
        public bool Enabled { get; set; }
        public bool Busy { get; set; }
        public int Capacity { get; set; }
        public string EndTime { get; set; }
    }

    public class Item
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public Position Position { get; set; }
        public Booking Booking { get; set; }
    }

    public class Position
    {
        public int X { get; set; }
        public int Y { get; set; }
        public int Z { get; set; }
    }

    public class Plan
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public bool Active { get; set; }
        public Background Background { get; set; }
        public Relation Relation { get; set; }
        public List<Item> Items { get; set; }
    }
}
