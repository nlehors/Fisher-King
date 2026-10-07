using UnityEngine;

public class ShopManager : MonoBehaviour
{
    [SerializeField] private GameObject shopUI;
    
    [SerializeField] private GameObject pressSpace;
    
    private bool _isPlayerInCollider;

    private void Start()
    {
        (_isPlayerInCollider) = false;
        
        shopUI.SetActive(false);
    }
    
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            _isPlayerInCollider = true;
            
            pressSpace.SetActive(true);
        }
    }

    void Update()
    {
        if (_isPlayerInCollider) 
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                shopUI.SetActive(true);
            }
               
        }
    }
}
