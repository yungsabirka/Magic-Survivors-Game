public interface IProduct
{
    ProductType Type { get; }
    float BonusValue { get; }
    int CurrentBonusAmount { get; }
    int MaxBonusAmount { get; }
    int Price { get; }
}
