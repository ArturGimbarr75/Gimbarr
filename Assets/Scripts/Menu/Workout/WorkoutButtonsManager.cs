using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorkoutButtonsManager : MonoBehaviour
{
    [SerializeField]
    private LoadingManager Loading;

    void Update()
    {
        if (Input.GetKeyUp(KeyCode.Escape))
            Loading.StartSceneLoading(0);
    }

    public void OnNewWorkoutClick()
    {
        Loading.StartSceneLoading(6);
    }

    public void OnWorkoutsClick()
    {
        Loading.StartSceneLoading(4);
    }

    public void OnStatisticsClick()
    {
        Loading.StartSceneLoading(7);
    }
}
