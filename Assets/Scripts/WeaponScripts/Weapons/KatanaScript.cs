using System;
using Unity.Cinemachine;
using UnityEditor.Rendering;
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
    private void Update()
    {
        Debug.Log(dirNearestEnnemy);
        if (timer > 0)
        {
            collider.enabled = false;
            sprite.enabled = false;
            timer -= Time.deltaTime;
        }
        else
        {
            collider.enabled = true;
            sprite.enabled = true;
            Slash();
        }
        
        dirNearestEnnemy = GetAngleNearestEnnemy();
        nearestEnnemy = GetNearestEnnemy();
    }

    public override void Setup()
    {
        base.Setup();
        tempDistance = slashDistance;
        tempPos = transform.localPosition;
        collider = GetComponent<Collider2D>();
        sprite = GetComponent<SpriteRenderer>();
    }

    private void Slash()
    {
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
        }
    }

    private Vector3 GetAngleNearestEnnemy()
    {
        var temp = parent.transform.rotation.eulerAngles;
        temp.z = (nearestEnnemy.transform.position - parent.transform.position).z;
        var rotation = parent.transform.rotation;
        rotation.eulerAngles = temp;
        parent.transform.rotation = rotation;
        
        return temp;
    }
}
