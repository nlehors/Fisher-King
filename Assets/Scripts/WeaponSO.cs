using UnityEngine;
using System.Collections.Generic;


[CreateAssetMenu(fileName = "WeaponSo", menuName = "Scriptable Objects/WeaponSO")]
public class WeaponSo : ScriptableObject

{

    public Sprite icon;

    public string WeaponName;

    [TextArea] public string WeaponDescription;

    //liste des niveaux et prix 
    public List<int> prices = new List<int> {1, 2, 3};

    





}
