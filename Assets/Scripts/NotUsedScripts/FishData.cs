using UnityEngine;

public enum FishType
{
    Common,
    Rare,
    Unique,
    Legendary
}

[CreateAssetMenu(fileName = "FishData", menuName = "Scriptable Objects/FishData")]
public class FishData : ScriptableObject
{
    [SerializeField] private string fishName;
    [SerializeField] private Sprite fishIcon;
    [SerializeField] private FishType fishRank;
    [SerializeField] private float fishChance;
    [SerializeField] private int fishValue;
    
    public string FishName => fishName;
    public Sprite FishIcon => fishIcon;
    public FishType FishRank => fishRank;
    public float FishChance => fishChance;
    public int FishValue => fishValue;
}
