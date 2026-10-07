using UnityEngine;
using UnityEngine.InputSystem;

public class ShopManager : MonoBehaviour
{
    [SerializeField] private GameObject shopUI;
    
    [SerializeField] private GameObject openShopUI;
    
    private bool _isPlayerInCollider;

    private void Start()
    {
        _isPlayerInCollider = false;
        
        shopUI.SetActive(false);
        
        openShopUI.SetActive(false);
    }
    
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            _isPlayerInCollider = true;
            
            openShopUI.SetActive(true);
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            _isPlayerInCollider = false;
            
            openShopUI.SetActive(false);
            
            shopUI.SetActive(false);
        }
    }
    
    void Update()
    {
        if (_isPlayerInCollider && Keyboard.current.eKey.wasPressedThisFrame)       
        {
            shopUI.SetActive(true);
            
            openShopUI.SetActive(false);
        }
    }
}
