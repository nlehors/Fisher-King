using System;
using UnityEngine;

public class FishingZone : MonoBehaviour
{
    public float deactivationTimer;

    public void Update()
    {
        deactivationTimer -= Time.deltaTime;
        gameObject.SetActive(deactivationTimer <= 0);
    }
}

