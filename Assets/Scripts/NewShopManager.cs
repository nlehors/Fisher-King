using UnityEngine;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine.Serialization;

public class NewShopManager : MonoBehaviour
{
    public GameObject shopUI;
    
    public GameObject openShopUI;

    public Player Player;

    public bool shopActive;
    GameObject activeShop;
    
    InputAction interaction = InputSystem.actions.FindAction("Interaction");

    public float inputBuffer;
    
    void Start()
    {
        shopUI.SetActive(false);
    }
    
    void Update()
    {
        //inputBuffer += Time.unscaledDeltaTime;
        //if (shopActive && inputBuffer > 2 && interaction.WasPerformedThisFrame())
        //{
        //    Player.playerMoney--;
        //    Player.playerSpeed+=10;
        //    ShopDeactivate();
        //}

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
        inputBuffer = 0;
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

    public void Button1()
    {
        ShopDeactivate();
    }
    
    public void Button2()
    {
        ShopDeactivate();
    }
    
    public void Button3()
    {
        ShopDeactivate();
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