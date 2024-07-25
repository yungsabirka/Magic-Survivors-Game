using System.Collections.Generic;
using UnityEngine;

public class MagixBookRepository : Repository
{
    public MagixBookStats StandartStats { get; set; }
    public MagixBookStats CurrentStats { get; set; }
    public List<Transform> MovingPoints { get; set; } = new();

    public override void Initialize()
    {
        StandartStats = new MagixBookStats
        {
            AttackRadius = ProductSetter.GetBonusesValue(5, ProductType.MagicBookAttackRadius),
            AttackDelayInSeconds = 1,
            Damage = ProductSetter.GetBonusesValue(30, ProductType.MagicBookDamage),
            ProjectilesMovingSpeed = ProductSetter.GetBonusesValue(2, ProductType.MagicBookProjectileSpeed),
            MagixBookMovingSpeed = 1
        };
        CurrentStats = StandartStats;
    }
}

