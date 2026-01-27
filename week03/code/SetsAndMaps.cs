using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;

public static class SetsAndMaps
{
    // --------------------------------------------------
    // PROBLEM 1: Find Pairs
    // --------------------------------------------------
    public static List<string> FindPairs(string[] words)
    {
        HashSet<string> seen = new HashSet<string>();
        List<string> result = new List<string>();

        foreach (string word in words)
        {
            char a = word[0];
            char b = word[1];

            // special case: aa, bb, etc.
            if (a == b)
                continue;

            string reversed = $"{b}{a}";

            if (seen.Contains(reversed))
            {
                result.Add($"{reversed} & {word}");
            }
            else
            {
                seen.Add(word);
            }
        }

        return result;
    }

    // --------------------------------------------------
    // PROBLEM 2: Degree Summary
    // --------------------------------------------------
    public static Dictionary<string, int> SummarizeDegrees(string filename)
    {
        Dictionary<string, int> summary = new Dictionary<string, int>();

        foreach (string line in File.ReadAllLines(filename))
        {
            string[] parts = line.Split(',');

            if (parts.Length < 4)
                continue;

            string degree = parts[3].Trim();

            if (summary.ContainsKey(degree))
                summary[degree]++;
            else
                summary[degree] = 1;
        }

        return summary;
    }

    // --------------------------------------------------
    // PROBLEM 3: Anagrams
    // --------------------------------------------------
    public static bool IsAnagram(string word1, string word2)
    {
        word1 = word1.Replace(" ", "").ToLower();
        word2 = word2.Replace(" ", "").ToLower();

        if (word1.Length != word2.Length)
            return false;

        Dictionary<char, int> counts = new Dictionary<char, int>();

        foreach (char c in word1)
        {
            if (counts.ContainsKey(c))
                counts[c]++;
            else
                counts[c] = 1;
        }

        foreach (char c in word2)
        {
            if (!counts.ContainsKey(c))
                return false;

            counts[c]--;

            if (counts[c] < 0)
                return false;
        }

        return true;
    }

    // --------------------------------------------------
    // PROBLEM 5: Earthquakes
    // --------------------------------------------------
    public static string[] EarthquakeDailySummary(string json)
    {
        FeatureCollection data =
            JsonSerializer.Deserialize<FeatureCollection>(
                json,
                new JsonSerializerOptions { PropertyNameCaseInsensitive = true }
            );

        List<string> results = new List<string>();

        foreach (Feature feature in data.Features)
        {
            string place = feature.Properties.Place;
            double? mag = feature.Properties.Mag;

            results.Add($"{place} - Mag {mag}");
        }

        return results.ToArray();
    }
}

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
