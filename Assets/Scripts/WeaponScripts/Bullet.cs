using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float lifeTime = 10f;
    
    private GameManager gameManager;
    private Weapon weaponScript;
    private GameObject player;
    private List<GameObject> ennemisList;
    private GameObject nearestEnnemy;
    private float bulletSpeed = 5f;

    private Vector2 dirVector;
    
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
        gameManager = FindAnyObjectByType<GameManager>();
        ennemisList = gameManager.ennemiList;
        player = GameObject.FindGameObjectWithTag("Player");
        weaponScript = player.GetComponentInChildren<Weapon>();
        
        nearestEnnemy = GetNearestEnnemy();
      
        Destroy(gameObject,lifeTime);
        
        dirVector = new Vector2(nearestEnnemy.transform.position.x - transform.position.x, nearestEnnemy.transform.position.y - transform.position.y);

        dirVector = Vector2.Normalize(dirVector) * bulletSpeed;
    }

    // Update is called once per frame
    void Update()
    {
        ennemisList = gameManager.GetEnnemiList();
        
        transform.position += new Vector3(dirVector.x, dirVector.y, 0) * Time.deltaTime;
    }

    void OnTriggerEnter2D(Collider2D collision)
    { 
        if (collision.CompareTag("Ennemi"))
        {
            Ennemi ennemiScript = collision.GetComponent<Ennemi>();
            weaponScript.Damage(ennemiScript);
            if (ennemiScript.ennemiLife <= 0)
            {
                ennemiScript.Death();
            }
            Destroy(gameObject);
        }
    }

    public GameObject GetNearestEnnemy()
    {
        GameObject tempEnnemy = null;
        float distanceMinPlayer = 100f;
        foreach (GameObject ennemi in ennemisList)
        { 
            
            if (Vector3.Distance(ennemi.transform.position,player.transform.position) < distanceMinPlayer)
            {
                distanceMinPlayer = Vector3.Distance(ennemi.transform.position, player.transform.position);
              
                tempEnnemy = ennemi;
            }
        }
        return tempEnnemy;
    }
}
