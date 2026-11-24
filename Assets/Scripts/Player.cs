using System;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour
{
    float playerHealth;
    public float baseDamage = 5;//à remplacer
    
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
    
    public float invincibilityTime;
    float invincibilityTimeRemaining;

    public float regenTime;
    public float regenTimeRemaining;

    public int playerMoney;

    InputAction moveLeft = InputSystem.actions.FindAction("MoveLeft");
    InputAction moveRight = InputSystem.actions.FindAction("MoveRight");
    InputAction moveUp = InputSystem.actions.FindAction("MoveUp");
    InputAction moveDown = InputSystem.actions.FindAction("MoveDown");
    InputAction interaction = InputSystem.actions.FindAction("Interaction");

    public string fishingZoneTag = "Fishing Zone";
    public string shopTag = "Shop";
    public string ennemiTag = "Ennemi";
    public string ennemiBulletTag = "EnnemiBullet";

    public bool isOnFishingZone;
    public bool isOnShop;

    public Collider2D zoneWhereIam;

    public NewShopManager shopManager;
    public MenuManager MenuManager;

    public GameObject boatSprite;
    int rotationFix;
    
    public Image lifeBar;
    
    void Start()
    {
        playerHealth = playerStatsDictionary["playerMaxHealth"];
    }

    void Update()
    {
        Mouvement();

        invincibilityTimeRemaining -= Time.deltaTime;

        if (playerHealth <= 0)
        {
            MenuManager.ReturnToMenu();
        }

        regenTimeRemaining -= Time.deltaTime;
        if (regenTimeRemaining < 0 && playerHealth < playerStatsDictionary["playerMaxHealth"])
        {
            playerHealth += playerStatsDictionary["playerRegeneration"];
            
            regenTimeRemaining = regenTime;
        }
        
        lifeBar.fillAmount = playerHealth / playerStatsDictionary["playerMaxHealth"];
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
        else if (other.CompareTag(ennemiBulletTag))
        {
            PlayerTakeDamage(other.GetComponent<WeaponShooterParent>().damage);
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
            PlayerTakeDamage(other.GetComponent<Ennemi>().ennemiContactDamage);
        }
    }

    void Mouvement()
    {
        Vector2 mouvement = Vector2.zero;
        if (moveLeft.IsPressed())
        {
            mouvement.x = - 1;
            rotationFix = 1;
        }
        else if (moveRight.IsPressed())
        {
            mouvement.x = 1;
            rotationFix = -1;
        }
        else
        {
            rotationFix = 1;
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

        boatSprite.transform.rotation = Quaternion.Euler(0, 0, Vector2.Angle(new Vector2(0, 1), mouvement) * rotationFix);
        
        transform.position += new Vector3(mouvement.x,mouvement.y, 0);
    }

    void PlayerTakeDamage(float damageForce)
    {
        if (invincibilityTimeRemaining < 0)
        {
            playerHealth -= damageForce;
            invincibilityTimeRemaining = invincibilityTime;
        }
    }
}
