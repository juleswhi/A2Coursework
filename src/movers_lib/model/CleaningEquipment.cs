﻿namespace Model;

public record CleaningEquipment : IDatabaseModel {
    [PrimaryKey]
    public int Id { get; set; }
    [ForeignKeyAttribute(typeof(Equipment))]
    public int EquipmentId { get; set; }
    public CleaningEquipment GenerateFakeData()
        => new Faker<CleaningEquipment>()
            .RuleFor(o => o.Id, f => DAL.Query<CleaningEquipment>().Select(o => o.Id).Max() + 1)
            .RuleFor(o => o.EquipmentId, f => f.PickRandom(DAL.Query<Equipment>().Select(x => x.Id)))
            .Generate();
    public Dictionary<string, (Action<IDatabaseModel?>, bool)> ViewButtons() {
        return new() {
            { "Create", (_ => { }, false) },
            { "Edit", (_ => { }, true ) },
            { "Delete", (_ => { }, true) }
        };
    }
    public Dictionary<string, (Action<(List<(string, Func<string>)>, IDatabaseModel?)>, bool)> CreateButtons() {
        return new() {
            { "Create", (_ => { }, false) },
            { "Edit", (_ => { }, true ) },
            { "Delete", (_ => { }, true) }
        };
    }

    public IDatabaseModel? CreateFromList(List<(string, Func<string>)> list, IDatabaseModel? model) {
        return default;
    }
}
