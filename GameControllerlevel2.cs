using UnityEngine;
using UnityEngine.SceneManagement;

public class GameControllerlevel2 : MonoBehaviour
{
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.F2))
        {
            LoadLevel3();
        }
    }

    public void LoadLevel3()
    {
        SceneManager.LoadScene("Win");
    }
}