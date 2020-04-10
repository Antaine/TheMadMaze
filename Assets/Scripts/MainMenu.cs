using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{

    private void Start()
    {
        Cursor.lockState = CursorLockMode.Confined;
    }
    public void PlayGame ()
    {
       int i = (SceneManager.GetActiveScene().buildIndex + 1);
        if (i >3)
        {
            SceneManager.LoadScene(1);
        }
        else
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
       
    }

    public void QuitGame()
    {
        Debug.Log("Quit");
        Application.Quit();
    }

}
