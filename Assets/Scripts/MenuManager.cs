using UnityEngine;

using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    public string gameSceneName = "Main";
    public string CollectionSceneName;
    public string MainMenuSceneName = "MainMenu";
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void StartGame()
    {
        SceneManager.LoadScene(gameSceneName);
    }
    
    public void LoadCollection()
    {
        SceneManager.LoadScene(CollectionSceneName);
    }
    
    public void ReturnToMenu()
    {
        SceneManager.LoadScene(MainMenuSceneName);
    }
    
    public void Quit()
    {
        Debug.Log("so long");
        Application.Quit();
    }
}
