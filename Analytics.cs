public static class Analytics {
    public static void GetBestChoice(List<Option> options, List<WeightedAttribute> attributes) {
        int[] scores = new int[options.Count];
        int index = 0;

        options.ForEach(option => {
            int sum = 0;
            option.Attributes.ForEach(optionAttr => {
                var weightedAttr = attributes.Find(attribute => attribute.Name == optionAttr.Name) ?? throw new Exception("Attribute Not Found; Wow this is super fatal");
                int weight = weightedAttr.Weight;
                sum += optionAttr.Weight * weight;
            });
            scores[index] = sum;
            index++;
        });

        int maxIndex = 0;
        for (int i = 1; i < scores.Length; i++)
        {
            if (scores[i] > scores[maxIndex])
            {
                maxIndex = i;
            }
        }

        Console.WriteLine(string.Format("Your best choice is {0}", options[maxIndex].Name));
    }
}