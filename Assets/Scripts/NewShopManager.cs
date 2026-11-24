using UnityEngine;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine.Serialization;
using TMPro;

public class NewShopManager : MonoBehaviour
{
    public GameObject shopUI;
    
    public GameObject openShopUI;

    public Player Player;

    public bool shopActive;
    GameObject activeShop;
    
    InputAction interaction = InputSystem.actions.FindAction("Interaction");
    InputAction callShop = InputSystem.actions.FindAction("CallShop");
    
    int randomButton1;
    int randomButton2;
    int randomButton3;

    public TMP_Text button1;
    public TMP_Text button2;
    public TMP_Text button3;
    
    public Dictionary <string,float> weaponsDictionary = new Dictionary <string,float> {
        { "katana", 0 },
        //{ "harpoonGun", 0 },
        //{ "dynamite", 0 }, 
        //{ "fishingNet", 0 },
        
        { "molotov", 0 },
        { "cutlass", 0 },
        { "flintlock", 0 },
        //{ "canon", 0 },
        //
        //{ "turret", 0 },
        //{ "torpedo", 0 },
        //{ "seaMine", 0 },
        //{ "propeller", 0 }
    };//si vous changez les noms de ça le jeu explose
    
    Dictionary <string,int> weaponsCostDictionary = new Dictionary <string,int> {
        { "katana", 1 },
        //{ "harpoonGun", 2 },
        //{ "dynamite", 3 }, 
        //{ "fishingNet", 4 },
        
        { "molotov", 5 },
        { "cutlass", 6 },
        { "flintlock", 7 },
        //{ "canon", 8 },
        //
        //{ "turret", 9 },
        //{ "torpedo", 10 },
        //{ "seaMine", 11 },
        //{ "propeller", 12 }
    };//si vous changez les noms de ça le jeu explose
    
    List<string> weaponsNames = new List<string>
    {
        "katana",
        //"harpoonGun",
        //"dynamite",
        //"fishingNet",
        
        "molotov",
        "cutlass",
        "flintlock",
        //"canon",
        //
        //"turret",
        //"torpedo",
        //"seaMine",
        //"propeller"
    };
    
    List<string> shopWeaponTextList = new List<string>
    {
        "Katana",
        //"Harpoon Gun",
        //"Dynamite",
        //"Fishing Net",
        
        "Molotov",
        "Cutlass",
        "Flintlock",
        //"Canon",
        //
        //"Turret",
        //"Torpedo",
        //"SeaMine",
        //"Propeller"
    };
    
    void Start()
    {
        shopUI.SetActive(false);
    }
    
    void Update()
    {
        openShopUI.SetActive(Player.isOnShop);
        
        //if (shopActive)
        //{
        //    openShopUI.SetActive(false);
        //}
        //else
        //{
        //    openShopUI.SetActive(Player.isOnShop);
        //}

        //if (interaction.WasPerformedThisFrame() && Player.isOnShop && !shopActive)
        //{
        //    ShopActivate(Player.zoneWhereIam.gameObject);
        //}

        if (callShop.WasPerformedThisFrame() && !shopActive)
        {
            shopActive = true;
            ShopActivateFromAnywhere();
        }
    }

    public void ShopActivateFromAnywhere()
    {
        randomButton1 = Random.Range(0, weaponsDictionary.Count);
        randomButton2 = Random.Range(0, weaponsDictionary.Count);
        //while (randomButton1 == randomButton2)
        //{
        //    randomButton2 = Random.Range(0, weaponsDictionary.Count);
        //}
        randomButton3 = Random.Range(0, weaponsDictionary.Count);
        //while (randomButton1 == randomButton3 | randomButton2 == randomButton3)
        //{
        //    randomButton2 = Random.Range(0, weaponsDictionary.Count);
        //}
            
        button1.text = shopWeaponTextList[randomButton1] + " cost : "+ weaponsCostDictionary[weaponsNames[randomButton1]];
        button2.text = shopWeaponTextList[randomButton2] + " cost : "+ weaponsCostDictionary[weaponsNames[randomButton2]];
        button3.text = shopWeaponTextList[randomButton3] + " cost : "+ weaponsCostDictionary[weaponsNames[randomButton3]];
        
        Time.timeScale = 0;
        shopUI.SetActive(true);
        openShopUI.SetActive(false);
    }
    
    public void ShopActivate(GameObject shop)
    {
        randomButton1 = Random.Range(0, 12);
        randomButton2 = Random.Range(0, 12);
        while (randomButton1 == randomButton2)
        {
            randomButton2 = Random.Range(0, 12);
        }
        randomButton3 = Random.Range(0, 12);
        while (randomButton1 == randomButton3 | randomButton2 == randomButton3)
        {
            randomButton2 = Random.Range(0, 12);
        }
            
        button1.text = shopWeaponTextList[randomButton1] + " cost : "+ weaponsCostDictionary[weaponsNames[randomButton1]];
        button2.text = shopWeaponTextList[randomButton2] + " cost : "+ weaponsCostDictionary[weaponsNames[randomButton2]];
        button3.text = shopWeaponTextList[randomButton3] + " cost : "+ weaponsCostDictionary[weaponsNames[randomButton3]];
        
        Time.timeScale = 0;
        shopUI.SetActive(true);
        openShopUI.SetActive(false);
        activeShop = shop;
    }
    
    public void ShopDeactivate()
    {
        Time.timeScale = 1;
        
        shopUI.SetActive(false);

        if (!(activeShop == null))
        {
            activeShop.SetActive(false);
            activeShop = null;
        }
        
        Player.isOnShop = false;
        
        shopActive = false;
    }

    public void Button1()
    {
        ShopDeactivate();
        
        weaponsDictionary[weaponsNames[randomButton1]]++;

        Player.playerMoney -= weaponsCostDictionary[weaponsNames[randomButton1]];
    }
    
    public void Button2()
    {
        ShopDeactivate();
        
        weaponsDictionary[weaponsNames[randomButton2]]++;
        
        Player.playerMoney -= weaponsCostDictionary[weaponsNames[randomButton2]];
    }
    
    public void Button3()
    {
        ShopDeactivate();
        
        weaponsDictionary[weaponsNames[randomButton3]]++;
        
        Player.playerMoney -= weaponsCostDictionary[weaponsNames[randomButton3]];
    }
}

//You walk along the edge of danger
//And it will change you
//Why would you let this voice set in your head
//It is meant to destroy you
//You summon storms
//You play with nature
//Now watch it hurt you
//Why would you want to shape the world in your hands
//You will never make it through
//Catch the fire burning out your soul
//Just make it die or you will turn it all
//To ashes and blood
//To ashes and blood
//You waste your life to gain power
//You shift the game rules
//How does it feel to reach the line that no one ever got to cross?
//Does it make you a god now?
//Every sin will be forgiven
//If you lay down your weapons to the ground
//Catch the fire burning out your soul
//Just make it die or you will fall
//Catch the fire burning out your soul
//Just make it die or you will turn it all
//To ashes and blood
//To ashes and blood
//To ashes and blood
//To ashes and blood
//To ashes and blood
//(hey, hey)
//
//–
//
//Shuriman chant translated from an old prayer to the goddess Jan’ahrem:
//Beyond these walls, the storm's fury grows
//Over land and sea, the storm's fury grows
//But I have nothing to fear!
//For the blue bird is with me
//
//Performed by Woodkid
//Written by Tanguy Destable, Yoann Lemoine, Alex Seaver
//Produced by Tanguy Destable, Alex Seaver, Woodkid 
//Additional Production Support by Hollywood Scoring       
//Mixed by Chris Tabron        
//Mastered by Joe LaPorta at Sterling Sound
//
//Executive Music Producer: Alex Seaver
//Executive in Charge of Music: Maria Egan
//Music Supervision: Riot Games Music Team, Jen Malone, Nicole Weisberg
//Senior Soundtrack Project Manager: Kerianne Pinkstaff
//A&R: Evan Lipschutz, Bob DeBelina