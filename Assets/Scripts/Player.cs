using System;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour
{
    int playerHealth;
    public float baseDamage = 5f;//à remplacer
    
    //stats améliorables
    [Header("stats améliorables")] 
    public float playerMaxHealth;
    public float playerSpeed;
    
    public float playerDamageModifier;
    public float playerAttackSpeedModifer;
    public float playerCritChance;
    public float playerCritDamage;
    public float playerAttackAreaSize;
    public float playerKnockback;

    public float playerRegeneration;
    public float playerArmor;
    public float playerEffectDuration;//c'est censé servir à quelque chose askip
    public float playerLuck;
    [Space(10f)]
    
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

        mouvement = Vector2.Normalize(mouvement) * playerSpeed * Time.deltaTime;

        transform.position += new Vector3(mouvement.x,mouvement.y, 0);
    }

    
}
