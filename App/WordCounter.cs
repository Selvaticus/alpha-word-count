using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;

namespace App
{
  class WordCounter
  {
    readonly char[] delimiterChars = { ' ', ',', '.', ':' };
    private Dictionary<string, int> words;
    private List<KeyValuePair<string, int>> sortedCounts;
    public WordCounter()
    {
      words = new Dictionary<string, int>();
      sortedCounts = new List<KeyValuePair<string, int>>();
    }

    public void ReadFile(string filename)
    {
      using (StreamReader reader = new StreamReader(filename))
      {
        string line;
        while ((line = reader.ReadLine()) != null)
        {
          var matches = Regex.Matches(line, @"\b([a-z]{2,}|[ai])\b", RegexOptions.IgnoreCase);
          foreach (var word in matches.Cast<Match>().Select(m => m.Value))
          {
            var lowerCaseWord = word.ToLowerInvariant();
            int index;

            if (this.words.TryGetValue(lowerCaseWord, out index))
            {
              // Word previously seen
              var kv = this.sortedCounts[index];
              this.sortedCounts[index] = new KeyValuePair<string, int>(lowerCaseWord, kv.Value + 1);
              var newIndex = BubbleUp(index);
              this.words[lowerCaseWord] = newIndex;

            }
            else
            {
              // New word found
              this.sortedCounts.Add(new KeyValuePair<string, int>(lowerCaseWord, 1));
              this.words.Add(lowerCaseWord, this.sortedCounts.Count - 1);
            }
          }
        }
      }
    }

    public IEnumerable<KeyValuePair<string, int>> Take(int count = 10)
    {
      var result = new List<KeyValuePair<string, int>>();

      for (int i = 0; i < count; i++)
      {
        yield return this.sortedCounts[i];
      }
    }

    private int BubbleUp(int index)
    {
      while (index >= 1 && this.sortedCounts[index].Value > this.sortedCounts[index - 1].Value)
      {
        var tmp = this.sortedCounts[index];
        this.sortedCounts[index] = this.sortedCounts[index - 1];
        this.sortedCounts[index - 1] = tmp;
        index--;
      }
      return index;
    }
  }
}