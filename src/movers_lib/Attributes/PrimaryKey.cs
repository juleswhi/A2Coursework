using Model;
namespace Attributes;

[AttributeUsage(AttributeTargets.Property)]
internal class PrimaryKey : Attribute { }

[AttributeUsage(AttributeTargets.Property)]
internal class DateAttribute : Attribute { }

[AttributeUsage(AttributeTargets.Property)]
internal class Name : Attribute {
    public string Text { get; set; } = "";
    public Name(string name) {
        Text = name;
    }
}

[AttributeUsage(AttributeTargets.Property)]
internal class ForeignKeyAttribute : Attribute {
    public Type Type { get; set; } = typeof(IDatabaseModel);
    public ForeignKeyAttribute(Type type) {
        Type = type;
    }
}

[AttributeUsage(AttributeTargets.Property)]
internal class ToggleAttribute : Attribute { }

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
internal class InitialValueBool : Attribute {
    public bool Value { get; set; }
    public InitialValueBool(bool val) {
        Value = val;
    }
}

[AttributeUsage(AttributeTargets.Property)]
internal class InitialValueDate : Attribute { }

