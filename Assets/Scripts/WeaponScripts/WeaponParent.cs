using Unity.VisualScripting;
using System.Collections.Generic;
using UnityEngine;


public class WeaponParent : MonoBehaviour
{
    [SerializeField]public float damage = 10f;
    [SerializeField]public float cooldown = 10f;

    //[SerializeField] public GameObject prefabToGenerate;
    
    protected float timer;
    protected Player playerScript;
    protected float totalDamage;
    protected List<GameObject> ennemisList;
    protected GameObject nearestEnnemy;

    void Start()
    {
        Setup();
        nearestEnnemy = GetNearestEnnemy();
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
    
    
    
    public GameObject GetNearestEnnemy()
    {
        //jpp de ce code de con
        GameObject tempEnnemy = null;
        float distanceMinPlayer = 100f;
        foreach (GameObject ennemi in ennemisList)
        { 
            
            if (Vector3.Distance(ennemi.transform.position,playerScript.transform.position) < distanceMinPlayer)
            {
                distanceMinPlayer = Vector3.Distance(ennemi.transform.position, playerScript.transform.position);
              
                tempEnnemy = ennemi;
            }
        }
        return tempEnnemy;
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
