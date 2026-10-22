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
    private float maxDistanceDetect;

    
    
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
        gameManager = FindAnyObjectByType<GameManager>();
        ennemisList = gameManager.ennemiList;
        player = GameObject.FindGameObjectWithTag("Player");
        weaponScript = player.GetComponentInChildren<Weapon>();
        GetNearestEnnemy();
        Destroy(gameObject,lifeTime);
    }

    // Update is called once per frame
    void Update()
    {
        ennemisList = gameManager.GetEnnemiList();
        
        if (nearestEnnemy != null && maxDistanceDetect > 0)
        {
            transform.position = Vector2.MoveTowards(transform.position, nearestEnnemy.transform.position,maxDistanceDetect * Time.deltaTime);
        }
      
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

    public void GetNearestEnnemy()
    {
        float distanceMinPlayer = Vector3.Distance(ennemisList[0].transform.position,player.transform.position);
        foreach (GameObject ennemi in ennemisList)
        {
            if (Vector3.Distance(ennemi.transform.position,player.transform.position) < distanceMinPlayer)
            {
                distanceMinPlayer = Vector3.Distance(ennemi.transform.position, player.transform.position);
                nearestEnnemy = ennemi;
                maxDistanceDetect = distanceMinPlayer;
            }
        }
    }
    
    
}
