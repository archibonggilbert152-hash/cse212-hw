public class SetsAndMaps
{
    public static List<string> FindPairs(List<string> words)
    {
        HashSet<string> seen = new HashSet<string>();
        List<string> result = new List<string>();

        foreach (string word in words)
        {
            char first = word[0];
            char second = word[1];

            // Skip words like "aa"
            if (first == second)
                continue;

            string reversed = $"{second}{first}";

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

    public static Dictionary<string, int> SummarizeDegrees(string filename)
{
    Dictionary<string, int> degrees = new Dictionary<string, int>();

    foreach (string line in File.ReadAllLines(filename))
    {
        string[] columns = line.Split(',');

        if (columns.Length < 4)
            continue;

        string degree = columns[3].Trim();

        if (degrees.ContainsKey(degree))
        {
            degrees[degree]++;
        }
        else
        {
            degrees[degree] = 1;
        }
    }

    return degrees;
}
public static bool IsAnagram(string word1, string word2)
{
    word1 = word1.Replace(" ", "").ToLower();
    word2 = word2.Replace(" ", "").ToLower();

    if (word1.Length != word2.Length)
        return false;

    Dictionary<char, int> letters = new Dictionary<char, int>();

    foreach (char c in word1)
    {
        if (letters.ContainsKey(c))
            letters[c]++;
        else
            letters[c] = 1;
    }

    foreach (char c in word2)
    {
        if (!letters.ContainsKey(c))
            return false;

        letters[c]--;

        if (letters[c] < 0)
            return false;
    }

    return true;
    }
}

