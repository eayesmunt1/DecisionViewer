public class WeightedAttribute {
  public string Name { get; set; }
  public int Weight { get; set; }

  public WeightedAttribute(string name, int weight) {
    this.Name = name;
    this.Weight = weight;
  }
}