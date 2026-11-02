using System;
using Unity.Cinemachine;
using UnityEngine;

public class KatanaScript : WeaponParent
{
    public float slashDistance;
    public float slashSpeed;
    [SerializeField] private GameObject parent;

    private Vector3 dirNearestEnnemy;
        
    private float tempDistance;
    private Vector3 tempPos;
    private Collider2D collider;
    private SpriteRenderer sprite;
    private bool isSlashing = false;
    
    private void Update()
    {
        Debug.Log(collider.enabled);
        if (timer <= 0 && isSlashing == false)
        {
            collider.enabled = true;
            sprite.enabled = true;
            Slash();
        }
        timer -= Time.deltaTime;
        
        
        GetNearestEnnemy();
        Orientate(nearestEnnemy.transform);
    }

    public override void Setup()
    {
        base.Setup();
        tempDistance = slashDistance;
        tempPos = transform.localPosition;
        collider = GetComponent<Collider2D>();
        sprite = GetComponent<SpriteRenderer>();
        collider.enabled = false;
        sprite.enabled = false;
    }

    private void Slash()
    {
        isSlashing = true;
        if (slashDistance > 0)
        {
            Vector3 temp = transform.localPosition;
            temp.x -= slashSpeed * Time.deltaTime;
            transform.localPosition = temp;
            slashDistance -= slashSpeed * Time.deltaTime;
        }
        else
        {
            slashDistance = tempDistance;
            transform.localPosition = tempPos;
            timer = cooldown;
            collider.enabled = false;
            sprite.enabled = false;
        }
    }

    private void Orientate(Transform target)
    {
        transform.LookAt(target);
    }
}
