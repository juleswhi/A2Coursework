namespace Attributes;

[AttributeUsage(AttributeTargets.Property)]
internal class PrimaryKey : Attribute { }

[AttributeUsage(AttributeTargets.Property)]
internal class Date : Attribute { }

[AttributeUsage(AttributeTargets.Property)]
internal class Name : Attribute {
    public string Text { get; set; } = "";
    public Name(string name) {
        Text = name;
    }
}

[AttributeUsage(AttributeTargets.Property)]
internal class InitialValueInt : Attribute {
    public int Value { get; set; }
    public InitialValueInt(int val) {
        Value = val;
    }
}

[AttributeUsage(AttributeTargets.Property)]
internal class InitialValueString : Attribute {
    public string Value { get; set; }
    public InitialValueString(string val) {
        Value = val;
    }
}

[AttributeUsage(AttributeTargets.Property)]
internal class InitialValueDate : Attribute { }
