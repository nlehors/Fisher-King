//using System.Collections.Generic;
//using UnityEngine;
//using UnityEngine.InputSystem;
//
//public class ShopManager : MonoBehaviour
//{
//    [SerializeField] private GameObject shopUI;
//    
//    [SerializeField] private GameObject openShopUI;
//
//    //liste des shops 
//    [SerializeField] private List<ShopSo> shops = new List<ShopSo> {};
//
//    [SerializeField] private SpriteRenderer spriteRenderer;
//
//    //prendre position joueur 
//    [SerializeField] private Transform player;
//
//    [SerializeField] private float minDistance = 6f;
//
//    [SerializeField] private float maxDistance = 10f;
//
//    private void ChoisirSpriteShop(ShopSo shop)
//    {
//        spriteRenderer.sprite = shop.shopSprite; 
//    }
//
//    private void TeleporterShop()
//    {
//       //Vector 2 pour 2D, prend une position al�atoire dans une cerle 
//        Vector2 direction = Random.insideUnitCircle.normalized;
//
//        // prend un distance al�atoire
//        float distance = Random.Range(minDistance, maxDistance);
//
//        //place le marchand 
//        transform.position = (Vector2)player.position + direction * distance;
//    }
//
//    private void Start()
//    {
//        shopUI.SetActive(false);
//        
//        openShopUI.SetActive(false);
//
//        AfficherShop();
//    }
//
//    private void AfficherShop()
//    {   //si la liste n'est pas vide 
//        if (shops.Count > 0)
//        {   // choisi un nombre entre 0 1 2 
//            int shopChoisi = Random.Range(0, shops.Count);
//            //applique le sprite au shop 
//            ChoisirSpriteShop(shops[shopChoisi]);
//        }
//
//        spriteRenderer.enabled = true;
//
//       
//    }
//
//    private void FermerShop()
//    {
//        shopUI.SetActive(false);
//
//        openShopUI.SetActive(false);
//
//        spriteRenderer.enabled = false;
//
//        TeleporterShop();
//    }
//    private void OnTriggerEnter2D(Collider2D other)
//    {
//        if (other.CompareTag("Player"))
//        {
//            openShopUI.SetActive(true);
//        }
//    }
//
//    private void OnTriggerExit2D(Collider2D other)
//    {
//        if (other.CompareTag("Player"))
//        {
//            openShopUI.SetActive(false);
//        }
//    }
//
//    void Update()
//    {
//        if (Keyboard.current.eKey.wasPressedThisFrame)
//        {
//            if (shopUI.activeSelf)
//            {
//                FermerShop();
//            }
//            else if (openShopUI.activeSelf)
//            {
//                shopUI.SetActive(true);
//
//                openShopUI.SetActive(false);
//            }
//        }
//    }
//
//
//}


//[Intro]
//Click Clack Click-Click Clack
//Click Clack Click-Click Clack
//Click Clack Click-Click Clack
//
//[Build]
//Click Clack Click-Click Clack
//Click Clack Click-Click Clack
//Click Clack Click-Click Clack
//Click Clack Click-Click Clack
//
//[Drop]
//Click Clack Click-Click Clack
//Click Clack Click-Click Clack
//Click Clack Click-Click Clack
//Click Clack Click-Click Clack
//Click Clack Click-Click Clack
//Click Clack Click-Click Clack
//Click Clack Click-Click Clack
//
//[Bridge]
//Click Clack Click-Click Clack
//Click Clack Click-Click Clack
//Click Clack Click-Click Clack
//Click Clack Click-Click Clack
//You might also like
//Don’t Look Back in Anger
//Oasis
//NRO1 BÄMÄ
//OLGA
//BONBON
//S4RA
//[Build]
//Click Clack Click-Click Clack
//Click Clack Click-Click Clack
//Click Clack Click-Click Clack
//Click Clack Click-Click Clack
//
//[Drop]
//Click Clack Click-Click Clack
//Click Clack Click-Click Clack
//Click Clack Click-Click Clack
//Click Clack Click-Click Clack
//Click Clack Click-Click Clack
//Click Clack Click-Click Clack
//Click Clack Click-Click Clack
//
//[Outro]
//Click Clack Click-Click Clack
//Click Clack Click-Click Clack
//Click Clack Click-Click Clack