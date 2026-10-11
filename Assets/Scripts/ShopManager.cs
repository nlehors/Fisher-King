using UnityEngine;
using UnityEngine.InputSystem;

public class ShopManager : MonoBehaviour
{
    [SerializeField] private GameObject shopUI;
    
    [SerializeField] private GameObject openShopUI;

    private void Start()
    {
        shopUI.SetActive(false);
        
        openShopUI.SetActive(false);
    }
    
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            openShopUI.SetActive(true);
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            openShopUI.SetActive(false);
        }
    }

    void Update()
    {
        if (Keyboard.current.eKey.wasPressedThisFrame)
        {
            if (shopUI.activeSelf)
            {
                shopUI.SetActive(false);
            }
            else if (openShopUI.activeSelf)
            {
                shopUI.SetActive(true);
                openShopUI.SetActive(false);
            }
        }
    }


}
