using System;
using UnityEngine;

public class XpAttract : MonoBehaviour
{
    public float radius = 2.5f;
    public float attractSpeed = 1000f;


    private void Update()
    {
        gameObject.transform.localScale = new Vector3(radius,radius,radius);
    }


    void OnTriggerStay2D(Collider2D collider)
    {
        if (collider.CompareTag("Xp"))
        {
           collider.transform.position = Vector2.MoveTowards(collider.transform.position, gameObject.transform.position, attractSpeed * Time.deltaTime);
        }
    }
}
