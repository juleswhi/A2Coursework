using Model;
namespace Attributes;

[AttributeUsage(AttributeTargets.Property)]
internal class ForeignKey : Attribute {
    public Type Type { get; set; } = typeof(IDatabaseModel);
    public ForeignKey(Type type) {
        Type = type;
    }
}
