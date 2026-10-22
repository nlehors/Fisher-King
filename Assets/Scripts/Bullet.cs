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

    
    
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
        gameManager = FindAnyObjectByType<GameManager>();
        Debug.Log("Game Manager   : " + gameManager);
        ennemisList = gameManager.ennemiList;
        Debug.Log("Game Manager   : " + ennemisList);
        player = GameObject.FindGameObjectWithTag("Player");
        weaponScript = player.GetComponentInChildren<Weapon>();
        
        nearestEnnemy = GetNearestEnnemy();
        Debug.Log("nearestEnnemy   : " + nearestEnnemy);
      
        Destroy(gameObject,lifeTime);
    }

    // Update is called once per frame
    void Update()
    {
        ennemisList = gameManager.GetEnnemiList();
        
        GoThere(nearestEnnemy.transform.position,bulletSpeed);
        
      
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
        float distanceMinPlayer = 100f; //Vector3.Distance(ennemisList[0].transform.position,player.transform.position);
      // Debug.Log("ennemi List  : " + ennemisList.Count);
        foreach (GameObject ennemi in ennemisList)
        { 
            
            if (Vector3.Distance(ennemi.transform.position,player.transform.position) < distanceMinPlayer)
            {
                distanceMinPlayer = Vector3.Distance(ennemi.transform.position, player.transform.position);
              
                tempEnnemy = ennemi;
              //  Debug.Log("TEMP  : " + tempEnnemy);
            }
        }
        Debug.Log("TEMP 2  : " + tempEnnemy);
        return tempEnnemy;
    }
    
    void GoThere(Vector3 target, float speed)
    {
        Debug.Log(target);
        Vector2 vector = new Vector2(target.x - transform.position.x, target.y - transform.position.y);

        vector = Vector2.Normalize(vector) * speed * Time.deltaTime;

        this.transform.position += new Vector3(vector.x, vector.y, 0);
    }
}
