using System;
using System.Collections;
using UnityEditor.Rendering;
using UnityEngine;

public class CutlassStab : MonoBehaviour
{
    private CutlassScript script;
    private Collider2D collider;
    private SpriteRenderer sprite;
    
    void Start()
    {
        script = GetComponentInParent<CutlassScript>();
        collider = GetComponent<Collider2D>();
        sprite = GetComponent<SpriteRenderer>();

    }

    private void FixedUpdate()
    {
        if (script.isActive)
        {
            collider.enabled = true;
            sprite.enabled = true;
        }
        else
        {
            collider.enabled = false;
            sprite.enabled = false;
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (script.stabDuration > 0 && script.stabDistance > 0 && other.tag == "Ennemi")
        {
            script.isStabbing = true;
        }
    }
}
