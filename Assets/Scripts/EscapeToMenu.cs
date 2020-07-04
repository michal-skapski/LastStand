using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class EscapeToMenu : MonoBehaviour
{
    private int _firstScene = 0;
    void Update()
    {
        if (Input.GetKeyUp(KeyCode.Escape))
        {
            SceneManager.LoadScene(_firstScene);
        }
    }
}
