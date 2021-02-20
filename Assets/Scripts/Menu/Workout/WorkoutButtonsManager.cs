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
        
    }

    public void OnWorkoutsClick()
    {

    }

    public void OnStatisticsClick()
    {

    }
}
