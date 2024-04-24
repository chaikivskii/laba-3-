using System;
using System.Globalization;
using System.IO;
using Newtonsoft.Json;

public class Date
{
    private int Day { get; set; }
    private int Month { get; set; }
    private int Year { get; set; }

    public Date(int day, int month, int year)
    {
        this.Day = day;
        this.Month = month;
        this.Year = year;
    }

    public int GetDay()
    {
        return this.Day;
    }

    public int GetMonth()
    {
        return this.Month;
    }

    public int GetYear()
    {
        return this.Year;
    }

    public int DaysDifference(Date date)
    {
        DateTime date1 = new DateTime(this.Year, this.Month, this.Day);
        DateTime date2 = new DateTime(date.GetYear(), date.GetMonth(), date.GetDay());
        TimeSpan difference = date2 - date1;
        return difference.Days;
    }

    public string DayOfWeek()
    {
        DateTime date = new DateTime(this.Year, this.Month, this.Day);
        return date.DayOfWeek.ToString();
    }

    public string ToJson()
    {
        return JsonConvert.SerializeObject(this);
    }

    public static Date FromJson(string json)
    {
        return JsonConvert.DeserializeObject<Date>(json);
    }

    public void SaveToJsonFile(string filePath)
    {
        string json = this.ToJson();
        File.WriteAllText(filePath, json);
    }

    public static Date LoadFromJsonFile(string filePath)
    {
        string json = File.ReadAllText(filePath);
        return FromJson(json);
    }
}
