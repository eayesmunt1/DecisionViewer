using System;
using System.Collections.Generic;
using System.Linq;

class Program {
  public static void Main () {
    Console.WriteLine("Weclome to DecisionViewer!");
    Console.WriteLine("Enter the name of the item you're considering:");
    string? item = Console.ReadLine();

    var attributes = Requirements.GatherAttributes();

    var options = Requirements.GatherOptions(attributes);

    Console.WriteLine(string.Format("Your best choice for {0} is", item));
    Analytics.GetBestChoice(options, attributes);
  }
}
