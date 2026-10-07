using System;
using Unity.VisualScripting;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class Ennemi : MonoBehaviour
{
    public float ennemiSpeed;
    public float ennemiLife;

    public GameObject xpPrefab;
    
    GameManager gameManager;
    
    void Start()
    {
        gameManager = GetComponentInParent<GameManager>();
    }

    void Update()
    {
        GoThere(gameManager.player.transform.position,ennemiSpeed);
    }

    void GoThere(Vector3 target, float speed)
    {
        Vector2 vector = new Vector2(target.x - transform.position.x, target.y - transform.position.y);

        vector = Vector2.Normalize(vector) * speed * Time.deltaTime;

        transform.position += new Vector3(vector.x, vector.y, 0);
    }

    void death()
    {
        Instantiate(xpPrefab);
        gameManager.NukeMe(this.gameObject);
        Destroy(this.gameObject);
    }
}