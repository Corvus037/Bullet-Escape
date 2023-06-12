using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelChanger : MonoBehaviour
{
    public string sceneName;

    public GameObject panel;



    bool s;
    void Awake() {
     s =  ConfigController.instance.showPanel;
    }

    
    

    public void ChangeLevel()
    {
        ConfigController.instance.SetPause(false);
        Cursor.visible = true;
        SceneManager.LoadScene(sceneName);
    }

     public void Exit()
    {
        ConfigController.instance.Menu();
    
    }

    public void Audio()
    {
        
        panel.SetActive(true);
        
    
    }

    public void AudioExit()
    {
        
        panel.SetActive(false);
        
    
    }
}