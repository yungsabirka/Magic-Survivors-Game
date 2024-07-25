using UnityEngine;

public class PlayerInfoRepository : Repository
{
    public CharacterStats StandartStats { get; set; }
    public CharacterStats CurrentStats { get; set; }
    public Vector3 Position { get; set; }
    public float Health { get; set; }

    public override void Initialize()
    {
        StandartStats = new CharacterStats
        {
            WeaponDamage = ProductSetter.GetBonusesValue(50, ProductType.WeaponDamage),
            Speed = ProductSetter.GetBonusesValue(5, ProductType.Speed),
            Armor = ProductSetter.GetBonusesValue(5, ProductType.Armor),
            MaxHealth = ProductSetter.GetBonusesValue(100, ProductType.Health)
        };
        CurrentStats = StandartStats;
        Health = CurrentStats.MaxHealth;
    }
}

