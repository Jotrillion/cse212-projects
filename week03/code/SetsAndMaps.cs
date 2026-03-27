using System.Text.Json;

public static class SetsAndMaps
{
    /// <summary>
    /// The words parameter contains a list of two character 
    /// words (lower case, no duplicates). Using sets, find an O(n) 
    /// solution for returning all symmetric pairs of words.  
    ///
    /// For example, if words was: [am, at, ma, if, fi], we would return :
    ///
    /// ["am & ma", "if & fi"]
    ///
    /// The order of the array does not matter, nor does the order of the specific words in each string in the array.
    /// at would not be returned because ta is not in the list of words.
    ///
    /// As a special case, if the letters are the same (example: 'aa') then
    /// it would not match anything else (remember the assumption above
    /// that there were no duplicates) and therefore should not be returned.
    /// </summary>
    /// <param name="words">An array of 2-character words (lowercase, no duplicates)</param>
    public static string[] FindPairs(string[] words)
    {
        var set = new HashSet<string>(words);
        var result = new List<string>();
        var used = new HashSet<string>();
        /// <summary>
        /// Finds all pairs of words that are reverses of each other (e.g., "ab" and "ba").
        /// </summary>
        /// <param name="words">Array of input words.</param>
        /// <returns>Array of string pairs in the format "ba & ab".</returns>
        foreach (var word in words)
        {
            if (word[0] == word[1]) continue; // skip words like "aa"
            var reversed = new string(new[] { word[1], word[0] });
            if (set.Contains(reversed) && !used.Contains(word) && !used.Contains(reversed))
            {
                result.Add($"{word} & {reversed}");
                used.Add(word);
                used.Add(reversed);
            }
        }
        return result.ToArray();
    }

    // TODO Problem 1 - ADD YOUR CODE HERE


    /// <summary>
    /// Read a census file and summarize the degrees (education)
    /// earned by those contained in the file.  The summary
    /// should be stored in a dictionary where the key is the
    /// degree earned and the value is the number of people that 
    /// have earned that degree.  The degree information is in
    /// the 4th column of the file.  There is no header row in the
    /// file.
    /// </summary>
    /// <param name="filename">The name of the file to read</param>
    /// <returns>fixed array of divisors</returns>
    public static Dictionary<string, int> SummarizeDegrees(string filename)
    {
        /// <summary>
        /// Reads a census file and summarizes the count of each degree type.
        /// </summary>
        /// <param name="filename">Path to the census file.</param>
        /// <returns>Dictionary mapping degree names to their counts.</returns>
        var degrees = new Dictionary<string, int>();
        foreach (var line in File.ReadLines(filename))
        {
            var fields = line.Split(",");
            if (fields.Length > 3)
            {
                string degree = fields[3];
                if (degrees.ContainsKey(degree))
                {
                    degrees[degree]++;
                }
                else
                {
                    degrees[degree] = 1;
                }
            }
        }
        return degrees;
    }

    /// <summary>
    /// Determine if 'word1' and 'word2' are anagrams.  An anagram
    /// is when the same letters in a word are re-organized into a 
    /// new word.  A dictionary is used to solve the problem.
    /// 
    /// Examples:
    /// is_anagram("CAT","ACT") would return true
    /// is_anagram("DOG","GOOD") would return false because GOOD has 2 O's
    /// 
    /// Important Note: When determining if two words are anagrams, you
    /// should ignore any spaces.  You should also ignore cases.  For 
    /// example, 'Ab' and 'Ba' should be considered anagrams
    /// 
    /// Reminder: You can access a letter by index in a string by 
    /// using the [] notation.
    /// </summary>
    public static bool IsAnagram(string word1, string word2)
    {
        // Remove spaces and convert to lowercase
        word1 = word1.Replace(" ", "").ToLower();
        word2 = word2.Replace(" ", "").ToLower();
        /// <summary>
        /// Determines if two words are anagrams, ignoring case and spaces.
        /// </summary>
        /// <param name="word1">First word.</param>
        /// <param name="word2">Second word.</param>
        /// <returns>True if the words are anagrams; otherwise, false.</returns>
        if (word1.Length != word2.Length)
            return false;

        var dict1 = new Dictionary<char, int>();
        var dict2 = new Dictionary<char, int>();

        foreach (var c in word1)
        {
            if (dict1.ContainsKey(c))
                dict1[c]++;
            else
                dict1[c] = 1;
        }

        foreach (var c in word2)
        {
            if (dict2.ContainsKey(c))
                dict2[c]++;
            else
                dict2[c] = 1;
        }

        if (dict1.Count != dict2.Count)
            return false;

        foreach (var kvp in dict1)
        {
            if (!dict2.ContainsKey(kvp.Key) || dict2[kvp.Key] != kvp.Value)
                return false;
        }

        return true;
    }
    /// <summary>
    /// This function will read JSON (Javascript Object Notation) data from the 
    /// United States Geological Service (USGS) consisting of earthquake data.
    /// The data will include all earthquakes in the current day.
    /// 
    /// JSON data is organized into a dictionary. After reading the data using
    /// <summary>
    /// Retrieves a summary of all earthquakes that occurred today from the USGS GeoJSON feed.
    /// Each entry contains the place and magnitude of an earthquake.
    /// Uses the built-in HTTP client library to fetch and parse the data.
    /// More info: https://earthquake.usgs.gov/earthquakes/feed/v1.0/geojson.php
    /// </summary>
    /// <returns>
    /// An array of strings, each describing an earthquake's location and magnitude (e.g., "Place - Mag 2.50").
    /// </returns>
    public static string[] EarthquakeDailySummary()
    {
        const string uri = "https://earthquake.usgs.gov/earthquakes/feed/v1.0/summary/all_day.geojson";
        using var client = new HttpClient();
        using var getRequestMessage = new HttpRequestMessage(HttpMethod.Get, uri);
        using var jsonStream = client.Send(getRequestMessage).Content.ReadAsStream();
        using var reader = new StreamReader(jsonStream);
        var json = reader.ReadToEnd();
        var options = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };

        var featureCollection = JsonSerializer.Deserialize<FeatureCollection>(json, options);

        /// <summary>
        /// Retrieves a summary of all earthquakes that occurred today from the USGS GeoJSON feed.
        /// Each entry contains the place and magnitude of an earthquake.
        /// Uses the built-in HTTP client library to fetch and parse the data.
        /// More info: https://earthquake.usgs.gov/earthquakes/feed/v1.0/geojson.php
        /// </summary>
        /// <returns>
        /// An array of strings, each describing an earthquake's location and magnitude (e.g., "Place - Mag 2.50").
        /// </returns>
        // Check for null in case deserialization fails
        if (featureCollection == null || featureCollection.Features == null)
            return [];

        var result = new List<string>();
        foreach (var feature in featureCollection.Features)
        {
            var place = feature.Properties?.Place;
            var mag = feature.Properties?.Mag;
            if (!string.IsNullOrEmpty(place) && mag != null)
            {
                result.Add($"{place} - Mag {mag:0.00}");
            }
        }
        return result.ToArray();
    }
}