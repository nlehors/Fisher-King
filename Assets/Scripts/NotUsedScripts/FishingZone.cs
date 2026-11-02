using UnityEngine;

public class FishingZone : MonoBehaviour
{
    public FishingManager fishingManager;

    void OnTriggerEnter2D(Collider2D other)
    {
        //Debug.Log($"Trigger entered by {other.name}, tag: {other.tag}");
        if (other.CompareTag("Player"))
        {
                
            //fishingManager.isFishing = true;

        }
    }
    void OnTriggerExit2D(Collider2D other)
    {
        
        if (other.CompareTag("Player"))
        {
            //fishingManager.isFishing = false;
        }
    }
    
}

