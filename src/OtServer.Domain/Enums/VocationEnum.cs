using System.ComponentModel;

namespace OtServer.Domain.Enums
{
    public enum VocationEnum : int
    {
        [Description("None")]
        None = 0,
        [Description("Sorcerer")]
        Sorcerer = 1,
        [Description("Druid")]
        Druid = 2,
        [Description("Archer")]
        Archer = 3,
        [Description("Knight")]
        Knight = 4,
        [Description("Master Sorcerer")]
        MasterSorcerer = 5,
        [Description("Elder Druid")]
        ElderDruid = 6,
        [Description("Royal Archer")]
        RoyalArcher = 7,
        [Description("Elite Knight")]
        EliteKnight= 8,
        [Description("Wyzard")]
        Wyzard = 9,
        [Description("Cleric")]
        Cleric = 10,
        [Description("Ranger")]
        Ranger = 11,
        [Description("Slayer")]
        Slayer = 12,
        [Description("Dark Wyzard")]
        DarkWyzard = 13,
        [Description("Elemental Cleric")]
        ElementalCleric = 14,
        [Description("Elven Ranger")]
        ElvenRanger = 15,
        [Description("Dragon Slayer")]
        DragonSlayer = 16,



    }
}
