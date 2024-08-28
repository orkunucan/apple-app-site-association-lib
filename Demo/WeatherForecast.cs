using System;

namespace Demo;

/// <summary>
/// A class representing a weather forecast.
/// </summary>
public class WeatherForecast
{
    /// <summary>
    /// The date of the weather forecast.
    /// </summary>
    public DateOnly Date { get; set; }

    /// <summary>
    /// The temperature in Celsius.
    /// </summary>
    public int TemperatureC { get; set; }

    /// <summary>
    /// The temperature in Fahrenheit.
    /// </summary>
    public int TemperatureF => 32 + (int)(TemperatureC / 0.5556);

    /// <summary>
    /// A summary of the weather forecast.
    /// </summary>
    public string Summary { get; set; }
}