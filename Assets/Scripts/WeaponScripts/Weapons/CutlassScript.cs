using System;
using Unity.Cinemachine;
using UnityEngine;

public class CutlassScript : WeaponParent
{
    public float rotationSpeed;
    [SerializeField] private GameObject parent;

    private Vector3 dirNearestEnnemy;
    private Collider2D collider;
    private SpriteRenderer sprite;
    
    
    private void Update()
    {
        Rotation(rotationSpeed);
    }

    public override void Setup()
    {
        base.Setup();
    }
    
    
    private void Rotation(float angle)
    { 
        parent.transform.Rotate(parent.transform.forward,angle); 
    }
    
    
}
