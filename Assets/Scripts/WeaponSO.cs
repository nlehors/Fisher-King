using UnityEngine;

[CreateAssetMenu(fileName = "WeaponSO", menuName = "Scriptable Objects/WeaponSO")]
public class WeaponSo : ScriptableObject
{   
    public string weaponName; 
    
   [TextArea] public string weaponDescription;

    public int price1;
    
    public int price2;
    
    public int price3;

    public Sprite icon; 

}
