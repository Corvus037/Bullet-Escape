using UnityEngine;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.F2))
        {
            LoadLevel2();
        }
    }

    public void LoadLevel2()
    {
        SceneManager.LoadScene("Level 2");
    }
}