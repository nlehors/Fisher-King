using UnityEngine;

[CreateAssetMenu(fileName = "ShopSo", menuName = "Scriptable Objects/ShopSo")]
public class ShopSo : ScriptableObject
{
    public string shopName; 
    
    public Sprite shopSprite;
    
    [TextArea] public string shopGreeting;
}
