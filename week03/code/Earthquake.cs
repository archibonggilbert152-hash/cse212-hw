using System.Text.Json;

namespace EarthquakeData
{
  public class FeatureCollection
  {
    public List<Feature> Features { get; set; }
  }

  public class Feature
  {
    public Properties Properties { get; set; }
  }

  public class Properties
  {
    public string Place { get; set; }
    public double? Mag { get; set; }
  }

  public static class EarthquakeProcessor
  {
    public static List<string> EarthquakeDailySummary(string json)
    {
      FeatureCollection data =
          JsonSerializer.Deserialize<FeatureCollection>(json,
          new JsonSerializerOptions { PropertyNameCaseInsensitive = true });

      List<string> results = new List<string>();

      foreach (Feature feature in data.Features)
      {
        string place = feature.Properties.Place;
        double? mag = feature.Properties.Mag;

        results.Add($"{place} - Mag {mag}");
      }

      return results;
    }
  }
}
