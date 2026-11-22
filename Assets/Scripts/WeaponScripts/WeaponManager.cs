using UnityEngine;

public class WeaponManager : MonoBehaviour
{
    public string weaponKeyName;
    public float currentWeaponLevel;

    [SerializeField] public GameObject normal;
    [SerializeField] public GameObject rare;
    [SerializeField] public GameObject epic;
    [SerializeField] public GameObject legendary;
    
    private NewShopManager shopManager;
        
        
        
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        shopManager = FindAnyObjectByType<NewShopManager>();
    }

    // Update is called once per frame
    void Update()
    {
        currentWeaponLevel = shopManager.weaponsDictionary[weaponKeyName];
        if (currentWeaponLevel == 0)
        {
            normal.SetActive(false);
            rare.SetActive(false);
            epic.SetActive(false);
            legendary.SetActive(false);
        }
        else if (currentWeaponLevel == 1)
        {
            normal.SetActive(true);
            rare.SetActive(false);
            epic.SetActive(false);
            legendary.SetActive(false);
        }
        else if(currentWeaponLevel == 2)
        {
            normal.SetActive(false);
            rare.SetActive(true);
            epic.SetActive(false);
            legendary.SetActive(false);
        }
        else if(currentWeaponLevel == 3)
        {
            normal.SetActive(false);
            rare.SetActive(false);
            epic.SetActive(true);
            legendary.SetActive(false);
        }
        else if(currentWeaponLevel == 4)
        {
            normal.SetActive(false);
            rare.SetActive(false);
            epic.SetActive(false);
            legendary.SetActive(true);
        }
        
        else if(currentWeaponLevel <= 0)
        {
            currentWeaponLevel = 0;
        }
        else if(currentWeaponLevel >= 4)
        {
            currentWeaponLevel = 4;
        }
        
    }
}
