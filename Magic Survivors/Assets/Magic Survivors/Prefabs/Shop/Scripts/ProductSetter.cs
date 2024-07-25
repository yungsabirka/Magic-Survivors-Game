using UnityEngine;

public static class ProductSetter
{
    public static float GetBonusesValue(float standartBonus, ProductType productType)
    {
        var bonusValue = PlayerPrefs.GetFloat($"{productType}", 0f);
        standartBonus += (standartBonus * bonusValue);
        return standartBonus;
    }
}

