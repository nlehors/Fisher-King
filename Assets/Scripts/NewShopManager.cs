using UnityEngine;
using System.Collections.Generic;
using UnityEngine.InputSystem;

public class NewShopManager : MonoBehaviour
{
    public GameObject shopUI;
    
    public GameObject openShopUI;

    public Player Player;
    
    //public List<GameObject> shopList = new List<GameObject>();

    public bool shopActive;
    GameObject activeShop;
    
    InputAction interaction = InputSystem.actions.FindAction("Interaction");

    public int stupidBuffer;
    
    void Start()
    {
        shopUI.SetActive(false);
        
        //for (int i = 0; i < transform.childCount; i++)
        //{
        //    shopList.Add(transform.GetChild(i).gameObject);
        //}
    }
    
    void Update()
    {
        stupidBuffer++;
        if (shopActive && stupidBuffer > 200 && interaction.WasPerformedThisFrame())
        {
            Player.playerMoney--;
            Player.playerSpeed+=10;
            ShopDeactivate();
        }

        if (shopActive)
        {
            openShopUI.SetActive(false);
        }
        else
        {
            openShopUI.SetActive(Player.isOnShop);
        }

        if (interaction.WasPerformedThisFrame() && Player.isOnShop && !shopActive)
        {
            ShopActivate(Player.zoneWhereIam.gameObject);
        }
        
        
    }

    public void ShopActivate(GameObject shop)
    {
        Time.timeScale = 0;
        shopUI.SetActive(true);
        shopActive = true;
        stupidBuffer = 0;
        activeShop = shop;
    }
    
    public void ShopDeactivate()
    {
        Time.timeScale = 1;
        
        shopUI.SetActive(false);
        shopActive = false;
        
        activeShop.SetActive(false);
        activeShop = null;

        Player.isOnShop = false;
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