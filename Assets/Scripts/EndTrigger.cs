using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndTrigger : MonoBehaviour
{
    // Start is called before the first frame update
    public void LoadMenu()
    {
        Debug.Log("Loading Level 2");
        SceneManager.LoadScene("Level2");
    }

    private void OnTriggerEnter()
    {
        LoadMenu();
    }
}
