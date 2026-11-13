using System;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour
{
    float playerHealth;
    public float baseDamage = 5f;//à remplacer
    
    //stats améliorables
    //[Header("stats améliorables")] 
    //public float playerMaxHealth;
    //public float playerSpeed;
    //
    //public float playerDamageModifier;
    //public float playerAttackSpeedModifer;
    //public float playerCritChance;
    //public float playerCritDamage;
    //public float playerAttackAreaSize;
    //public float playerKnockback;
    //
    //public float playerRegeneration;
    //public float playerArmor;
    //public float playerEffectDuration;//c'est censé servir à quelque chose askip
    //public float playerLuck;
    //[Space(10f)] 
    
    [SerializeField] public Dictionary <string,float> playerStatsDictionary = new Dictionary <string,float> {
        { "playerMaxHealth", 0 },
        { "playerSpeed", 0 },
        
        { "playerDamageModifier", 0 }, 
        { "playerAttackSpeedModifer", 0 },
        { "playerCritChance", 0 },
        { "playerCritDamage", 0 },
        { "playerAttackAreaSize", 0 },
        { "playerKnockback", 0 },
        
        { "playerRegeneration", 0 },
        { "playerArmor", 0 },
        { "playerEffectDuration", 0 },
        { "playerLuck", 0 }
    };//si vous changez les noms de ça le jeu explose
    
    public List<string> uprgradeButtonTextList = new List<string>
    {
        "max Health",
        "player speed",
        "damage modifier",
        "attack speed modifier",
        "crit chance",
        "crit damage",
        "attack area size",
        "knockback",
        "regeneration",
        "armor",
        "effect duration",
        "luck"
    };
    
    public List<string> upgradeNames = new List<string>
    {
        "playerMaxHealth",
        "playerSpeed",
        "playerDamageModifier",
        "playerAttackSpeedModifer",
        "playerCritChance",
        "playerCritDamage",
        "playerAttackAreaSize",
        "playerKnockback",
        "playerRegeneration",
        "playerArmor",
        "playerEffectDuration",
        "playerLuck"
    };
    
    public float invincibilityTime;
    float invincibilityTimeRemaining;

    public int playerMoney;

    InputAction moveLeft = InputSystem.actions.FindAction("MoveLeft");
    InputAction moveRight = InputSystem.actions.FindAction("MoveRight");
    InputAction moveUp = InputSystem.actions.FindAction("MoveUp");
    InputAction moveDown = InputSystem.actions.FindAction("MoveDown");
    
    InputAction interaction = InputSystem.actions.FindAction("Interaction");

    public string fishingZoneTag = "Fishing Zone";
    public string shopTag = "Shop";
    public string ennemiTag = "Ennemi";

    public bool isOnFishingZone;
    public bool isOnShop;

    public Collider2D zoneWhereIam;

    public NewShopManager shopManager;
    public MenuManager MenuManager;
    
    void Start()
    {
        playerHealth = playerStatsDictionary["playerMaxHealth"];
    }

    void Update()
    {
        Mouvement();

        invincibilityTimeRemaining -= Time.deltaTime;

        if (playerHealth == 0)
        {
            MenuManager.ReturnToMenu();
        }
    }
    
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag(fishingZoneTag))
        {
            isOnFishingZone = true;
            
            zoneWhereIam = other;
        }
        else if (other.CompareTag(shopTag))
        {
            isOnShop = true;

            zoneWhereIam = other;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag(fishingZoneTag))
        {
            isOnFishingZone = false;
            
            zoneWhereIam = null;
        }
        else if (other.CompareTag(shopTag))
        {
            isOnShop = false;
            
            zoneWhereIam = null;
        }
    }

    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.CompareTag(ennemiTag))
        {
            if (invincibilityTimeRemaining < 0)
            {
                playerHealth--;
                invincibilityTimeRemaining = invincibilityTime;
            }
        }
    }

    void Mouvement()
    {
        Vector2 mouvement = Vector2.zero;
        if (moveLeft.IsPressed())
        {
            mouvement.x = - 1;
        }
        else if (moveRight.IsPressed())
        {
            mouvement.x = 1;
        }
        
        if (moveUp.IsPressed())
        {
            mouvement.y = 1;
        }
        else if (moveDown.IsPressed())
        {
            mouvement.y = - 1;
        }

        mouvement = Vector2.Normalize(mouvement) * playerStatsDictionary["playerSpeed"] * Time.deltaTime;

        transform.position += new Vector3(mouvement.x,mouvement.y, 0);
    }

    
}
