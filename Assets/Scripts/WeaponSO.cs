using UnityEngine;

[CreateAssetMenu(fileName = "WeaponSO", menuName = "Scriptable Objects/WeaponSO")]
public class WeaponSo : ScriptableObject
{   
    public string weaponName; 
    
   [TextArea] public string weaponDescription;

    public int price1 = 1;
    
    public int price2 = 2;
    
    public int price3 = 3;

    public Sprite icon;


}
