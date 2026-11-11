using Unity.VisualScripting;
using System.Collections.Generic;
using UnityEngine;


public class WeaponParent : MonoBehaviour
{
    [SerializeField]public float damage = 10f;
    [SerializeField]public float cooldown = 10f;
    public GameManager gameManager;
    //[SerializeField] public GameObject prefabToGenerate;
    
    [SerializeField]protected float timer;
    protected Player playerScript;
    protected float totalDamage;
    protected List<GameObject> ennemisList;
    protected GameObject nearestEnnemy;
    

    void Start()
    {
        Setup();
        GetNearestEnnemy();
    }
    
    void OnTriggerEnter2D(Collider2D collision)
    { 
        if (collision.CompareTag("Ennemi"))
        {
            Ennemi ennemiScript = collision.GetComponent<Ennemi>();
            Damage(ennemiScript);
            if (ennemiScript.ennemiLife <= 0)
            {
                ennemiScript.Death();
            }
        }
    }
    
    // fonction globales :
    public virtual void Setup()
    {
        playerScript = GetComponentInParent<Player>();
        timer = cooldown;
    }
    
    
    
    public void GetNearestEnnemy()
    {
        //jpp de ce code de con
        //GameObject tempEnnemy = null;
        float distanceMinPlayer = 100f;
        foreach (GameObject ennemi in gameManager.ennemiList)
        { 
            
            if (Vector3.Distance(ennemi.transform.position,playerScript.transform.position) < distanceMinPlayer)
            {
                distanceMinPlayer = Vector3.Distance(ennemi.transform.position, playerScript.transform.position);
              
                nearestEnnemy = ennemi;
            }
        }
        
    }
    public void Damage(Ennemi target)
    {
        totalDamage = damage + playerScript.baseDamage;
        target.ennemiLife -= totalDamage;
    }
    
    
    
    // fonction à move dans un script hérité
    //private void CreateProjectile()
    //{
    //    GameObject lastBullet = Instantiate(prefabToGenerate, transform.position, transform.rotation);
    //}
}
