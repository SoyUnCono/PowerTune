namespace PowerTune.Models;
public class TupleItem {
    public double Item1 {
        get; set;
    }
    public string Item2 {
        get; set;
    }

    public TupleItem(double item1, string item2) {
        Item1 = item1;
        Item2 = item2;
    }
}

