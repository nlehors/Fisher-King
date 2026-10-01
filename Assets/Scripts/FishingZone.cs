using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Serialization;

public class FishingZone : MonoBehaviour
{
    public FishingUI fishingUI;

    void OnTriggerEnter2D(Collider2D other)
    {
        //Debug.Log($"Trigger entered by {other.name}, tag: {other.tag}");
        Debug.Log("Player detected", this);
        if (other.CompareTag("Player"))
        {
                
            fishingUI.isFishing = true;

        }
    }
    void OnTriggerExit2D(Collider2D other)
    {
        Debug.Log("Exit");
        if (other.CompareTag("Player"))
        {
            fishingUI.isFishing = false;
        }
    }
    
}

