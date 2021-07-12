using UnityEngine;

[CreateAssetMenu(fileName = "Hex", menuName = "HexObject", order = 51)]
public class HexObject : ScriptableObject
{
    [SerializeField] private int id;
    [SerializeField] private int price;
    [SerializeField] private int income;

    public int Id { get => id; }
    public int Price { get => price; }
    public int Income { get => income; }
}