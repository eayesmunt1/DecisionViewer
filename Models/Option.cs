public class Option {
    public string Name {get;set;}
    public List<WeightedAttribute> Attributes { get;set;}

    public Option(string name) {
        this.Name = name;
        this.Attributes = new List<WeightedAttribute>();
    }
}