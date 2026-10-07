using UnityEngine;

[CreateAssetMenu(fileName = "ShopSo", menuName = "Scriptable Objects/ShopSo")]
public class ShopSo : ScriptableObject
{
    public string shopName; 
    
    public Sprite shopIcon;
    
    [TextArea] public string shopGreeting;
}
