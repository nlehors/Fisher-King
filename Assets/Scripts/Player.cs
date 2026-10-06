using System;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour
{
    public int playerLife;
    
    public float playerSpeed;
    
    public float invincibilityTime;
    float invincibilityTimeRemaining;

    InputAction moveLeft = InputSystem.actions.FindAction("MoveLeft");
    InputAction moveRight = InputSystem.actions.FindAction("MoveRight");
    InputAction moveUp = InputSystem.actions.FindAction("MoveUp");
    InputAction moveDown = InputSystem.actions.FindAction("MoveDown");

    public string fishingZoneTag;
    public string shopTag;
    public string ennemiTag;

    public bool isOnFishingZone;
    public bool isOnShop;
    
    void Start()
    {
        
    }

    void Update()
    {
        Mouvement();

        invincibilityTimeRemaining -= Time.deltaTime;
    }
    
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag(fishingZoneTag))
        {
            isOnFishingZone = true;
        }
        else if (other.CompareTag(shopTag))
        {
            isOnShop = true;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag(fishingZoneTag))
        {
            isOnFishingZone = false;
        }
        else if (other.CompareTag(shopTag))
        {
            isOnShop = false;
        }
    }

    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.CompareTag(ennemiTag))
        {
            if (invincibilityTimeRemaining < 0)
            {
                playerLife--;
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
