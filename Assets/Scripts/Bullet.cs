using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float lifeTime = 10;
    
    private GameManager gameManager;
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
        GetNearestEnnemy();
    }

    // Update is called once per frame
    void Update()
    {
        ennemisList = gameManager.GetEnnemiList();
        if (nearestEnnemy != null && maxDistanceDetect > 0)
        {
            transform.position = Vector2.MoveTowards(transform.position, nearestEnnemy.transform.position,maxDistanceDetect * Time.deltaTime);
            
        }
        
        Destroy(this,lifeTime);
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
