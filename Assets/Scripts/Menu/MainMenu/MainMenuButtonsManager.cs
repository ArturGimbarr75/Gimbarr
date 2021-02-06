using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuButtonsManager : MonoBehaviour
{
    void Update()
    {
        if (Input.GetKeyUp(KeyCode.Escape))
            Application.Quit();
    }

    public void OnElementsListClick()
    {
        SceneManager.LoadScene(1);
    }

    public void OnWorkoutClick()
    {

    }
}
