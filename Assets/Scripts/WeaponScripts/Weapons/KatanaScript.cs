using System;
using Unity.Cinemachine;
using UnityEngine;

public class KatanaScript : WeaponParent
{
    public float angleRotation;
    
    private Transform pos;
    private Quaternion temp;
    
    private void Update()
    {
        Slash();
    }

    public override void Setup()
    {
        base.Setup();
        pos = GetComponent<Transform>();
        temp = pos.rotation;
    }

    private void Slash()
    {
        Rotation(angleRotation * Time.deltaTime);
        //if (pos.forward <= ) 
    }

    private void Rotation(float angle)
    { 
        pos.Rotate(pos.forward,angle); 
    }
    
}
