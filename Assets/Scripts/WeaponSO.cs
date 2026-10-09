using UnityEngine;
using System.Collections;


[CreateAssetMenu(fileName = "WeaponSO", menuName = "Scriptable Objects/WeaponSO")]
public class WeaponSo : ScriptableObject
{   
    public string weaponName; 
    
    [TextArea] public string weaponDescription;

    ArrayList My_array = new ArrayList();


    public Sprite icon;


}
