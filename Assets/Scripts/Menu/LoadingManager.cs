using Assets.Scripts.SingletoneModel;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LoadingManager : MonoBehaviour
{
    [SerializeField]
    private GameObject LoadingObject;
    [SerializeField]
    private bool FindingButtonsAutomatically;
    [SerializeField]
    private Button[] Buttons;

    void Awake()
    {
        if (FindingButtonsAutomatically)
        {
            Buttons = GameObject.FindObjectsOfType<Button>();
        }
    }

    public void StartSceneLoading(int sceneNumber)
    {
        foreach (var b in Buttons)
            b.interactable = false;

        BeforeSceneChanged(SceneManager.GetActiveScene().buildIndex, sceneNumber);
        LoadingObject.SetActive(true);
        AsyncOperation operation = SceneManager.LoadSceneAsync(sceneNumber);
    }

    /*
        0 -> MainMenu
        1 -> ElementsList
        2 -> ElementInfo
        3 -> Workout
        4 -> WorkoutList
        5 -> WorkoutInfo
        6 -> NewWorkout
    */
    void BeforeSceneChanged(int currentSceneId, int nextSceneId)
    {
        if (currentSceneId == 0 && nextSceneId == 1)
        {
            FunctionInElementsList.Instance.Function = FunctionInElementsList.FunctionType.Info;
        }

        if (currentSceneId == 6 && nextSceneId == 1)
        {
            FunctionInElementsList.Instance.Function = FunctionInElementsList.FunctionType.Choice;
        }
    }

}
