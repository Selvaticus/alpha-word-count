using System;
using System.Diagnostics;

namespace App
{
  class Program
  {
    readonly static long TicksInMillisecond = Stopwatch.Frequency / 1000L;

    static void Main(string[] args)
    {
      var wordCounter = new WordCounter();

      var filename = args[0];
      Console.WriteLine("Reading file: " + filename);

      var clock = Stopwatch.StartNew();

      wordCounter.ReadFile(filename);
      var result = wordCounter.Take();

      clock.Stop();
      var ticksThisTime = clock.ElapsedTicks;

      Console.WriteLine("Top 10 words by count ");
      foreach (var kv in result)
      {
        Console.WriteLine(kv.Key + " => " + kv.Value);
      }

      Console.WriteLine("Finished in: {0} ms", (ticksThisTime / TicksInMillisecond));
    }
  }
}
