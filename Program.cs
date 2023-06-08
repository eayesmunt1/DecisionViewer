using System;
using System.Collections.Generic;
using System.Linq;

class WeightedAttribute {
  public string Name { get; set; }
  public int Weight {get; set; }

  public WeightedAttribute(string name, int weight) {
    this.Name = name;
    this.Weight = weight;
  }
}

class Program {
  public static void Main () {
    Console.WriteLine("Weclome to DecisionViewer!");
    Console.WriteLine("Enter the name of the item you're considering:");
    string? item = Console.ReadLine();

    var attributes = new List<string>();
    Console.WriteLine("Now enter names of it's attributes that contribute to your decision.");
    Console.WriteLine("Once you're entered them all type 'done'.");

    var keepGoing = true;
    while(keepGoing) {
      string? attribute = Console.ReadLine();

      if (attribute == "done") {
        keepGoing = false;
      } else if ( attribute == null || attribute == "") {
        Console.WriteLine("Please no empty strings.");
      } else {
        attributes.Add(attribute);
      }
    }

    attributes.ForEach(attribute => {
      Console.WriteLine(attribute);
    });

    var weightedAttributes = attributes.Select(attr => new WeightedAttribute(attr, 0));
    var weightedAttributesList = new List<WeightedAttribute>(weightedAttributes);

    Console.WriteLine("Now enter the weight of each attribute: A value between 1 and 99.");
    Console.WriteLine("The sum of all weights must not exceed 100.");
    var remainingWeight = 100;
    weightedAttributesList.ForEach(wa => {
      var invalidWeight = true;
      if (remainingWeight < 1) {
        Console.WriteLine("You're out of weight.");
        Console.WriteLine(string.Format("{0} will be weighted as 0.", wa.Name));
        invalidWeight = false;
      }

      while (invalidWeight) {
        Console.WriteLine(string.Format("Remaining weight: {0}", remainingWeight));
        Console.WriteLine(string.Format("Enter the weight of {0}", wa.Name));
        string? enteredWeight = Console.ReadLine();

        if (enteredWeight == null || enteredWeight == "") {
            Console.WriteLine("Please enter valid weight.");
            continue;
        }

        int weight = int.Parse(enteredWeight);

        if (weight < 100 && weight > 0 && weight <= remainingWeight) {        
          invalidWeight = false;
          remainingWeight -= weight;
          wa.Weight = weight;
        } else {
          Console.WriteLine("Please enter valid weight.");
        }
      }
    });

    weightedAttributesList.ForEach(attr => {
      Console.WriteLine(string.Format("Name: {0} - Weight: {1}", attr.Name, attr.Weight));
    });
  }
}
