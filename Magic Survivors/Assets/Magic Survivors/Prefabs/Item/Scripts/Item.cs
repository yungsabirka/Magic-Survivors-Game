using UnityEngine;

public class Item : MonoBehaviour
{
    [SerializeField] private ItemType _type;
    [SerializeField] private int _value;

    public ItemType Type => _type;
    public int Value => _value;
}

