
public static class Requirements {
    public static List<WeightedAttribute> GatherAttributes() {
        Console.WriteLine("Now enter names of it's attributes that contribute to your decision.");
        Console.WriteLine("Once you're entered them all type 'done'.");
        var attributes = new List<string>();

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

        return weightedAttributesList;
    }

    public static List<Option> GatherOptions(List<WeightedAttribute> attributes) {
        var options = new List<Option>();

        Console.WriteLine("Now enter names of your options.");
        Console.WriteLine("Once you're entered them all type 'done'.");

        var keepGoing = true;
        while (keepGoing) {
            string? optionName = Console.ReadLine();

            if (optionName == "done") {
                keepGoing = false;
            } else if ( optionName == null || optionName == "") {
                Console.WriteLine("Please no empty strings.");
            } else {
                options.Add(new Option(optionName));
            }
        }

        options.ForEach(option => {
            Console.WriteLine(string.Format("We will go through all attributes for {0} and score them", option.Name));
            Console.WriteLine("If the attribute is a true or false value rather than a scoring then just write yes or no.");
            Console.WriteLine("If the attribute can be scored then give it a value between 0 and 10.");

            attributes.ForEach(attribute => {
                bool invalidResponse = true;

                while(invalidResponse) {
                    Console.WriteLine(string.Format("Rate {0} for {1}", attribute.Name, option.Name));
                    string? response = Console.ReadLine();

                    switch(response) {
                        case null:
                        case "":
                            Console.WriteLine("Please enter valid response");
                            break;
                        case "done":
                            invalidResponse = false;
                            break;
                        case "yes":
                            option.Attributes.Add(new WeightedAttribute(attribute.Name, 100));
                            invalidResponse = false;
                            break;
                        case "no":
                            option.Attributes.Add(new WeightedAttribute(attribute.Name, 0));
                            invalidResponse = false;
                            break;
                        default:
                            var weight = int.Parse(response);
                            if (weight < 0 || weight > 10) {
                                Console.WriteLine("Please enter a value between 0 and 10.");
                            } else {
                                option.Attributes.Add(new WeightedAttribute(attribute.Name, weight));
                                invalidResponse = false;
                            }
                            break;
                    }   
                }
            });
        });

        return options;
    }
}