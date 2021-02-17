using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuButtonsManager : MonoBehaviour
{
    [SerializeField]
    private LoadingManager Loading;

    void Update()
    {
        if (Input.GetKeyUp(KeyCode.Escape))
            Application.Quit();
    }

    public void OnElementsListClick()
    {
        Loading.StartSceneLoading(1);
    }

    public void OnWorkoutClick()
    {

    }
}
