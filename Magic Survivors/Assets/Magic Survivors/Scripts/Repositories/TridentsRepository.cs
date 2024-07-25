using System.Collections.Generic;
using UnityEngine;

public class TridentsRepository : Repository
{
    public List<Transform> TridentCells = new();

    public float StandartDamage { get; set; }
    public float StandartAngularSpeed { get; set; }
    public float AngularSpeed { get; set; }
    public float Damage { get; set; }
    public int MaxTridentAmount { get; set; }

    public override void Initialize()
    {
        StandartDamage = ProductSetter.GetBonusesValue(20, ProductType.TridentDamage);
        StandartAngularSpeed = ProductSetter.GetBonusesValue(60, ProductType.TridentSpeed);
        MaxTridentAmount = (int)ProductSetter.GetBonusesValue(2, ProductType.TridentsAmount);
        Damage = StandartDamage;
        AngularSpeed = StandartAngularSpeed;
    }
}

