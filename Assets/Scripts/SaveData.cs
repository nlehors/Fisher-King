using UnityEngine;

using System.Collections.Generic;

[System.Serializable]
public class SaveData
{
    public float gameTime;
    public int ennemiKilled;
    public int numberOfGame;
    public int numberOfwin;
    
    public float volume;

    public bool[] fishCollection;

    public SaveData(GameManager gameManager)
    {
        gameTime = gameManager.gameTime;
        ennemiKilled = gameManager.ennemiKilled;
        numberOfGame = gameManager.numberOfGame;
        numberOfwin = gameManager.numberOfwin;
        
        volume = gameManager.volume;
        
        fishCollection = gameManager.fishCollection;
    }
}
