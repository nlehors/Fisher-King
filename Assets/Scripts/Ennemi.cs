using Unity.VisualScripting;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class Ennemi : MonoBehaviour
{
    public float ennemiSpeed;
    public float ennemiLife;

    public GameObject player;
    
    void Start()
    {
        
    }

    void Update()
    {
        GoThere(player.transform.position,ennemiSpeed);
        Health();
    }

    void GoThere(Vector3 target, float speed)
    {
        Vector2 vector = new Vector2(target.x - transform.position.x, target.y - transform.position.y);

        vector = Vector2.Normalize(vector) * speed;

        transform.position += new Vector3(vector.x, vector.y, 0);
    }

    void Health()
    {
        if (ennemiLife <= 0)
        {
            // à changer pour un destroy une fois le système de wave fait.
            this.gameObject.SetActive(false);
        }
    }
    
}