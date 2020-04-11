﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndTrigger : MonoBehaviour
{
    int i;
    // Start is called before the first frame update
    public void LoadLevel()
    {
        i = (SceneManager.GetActiveScene().buildIndex + 1);
        if (i<4)
        {
            Debug.Log("Loading Level " + i);
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
        else
        {
            Cursor.lockState = CursorLockMode.None;
            SceneManager.LoadScene("__Menu");
        }
        
      
       
    }

    private void OnTriggerEnter()
    {
        LoadLevel();
    }
}