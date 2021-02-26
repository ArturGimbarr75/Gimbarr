using Assets.Scripts.DataBase.WorkoutTableNS;
using Assets.Scripts.Models;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NewWorkoutManager : MonoBehaviour
{
    [SerializeField]
    private Text TimeText;
    [SerializeField]
    private LoadingManager Loading;
    [SerializeField]
    private GameObject StartWorkoutPanel;
    [SerializeField]
    private GameObject TaskPanel;

    private DateTime BeginTime;
    private Workout CurrentWorkout;
    
    void Start()
    {
        CurrentWorkout = WorkoutTable.GetUnfinishedWorkout();
        StartWorkoutPanel.transform.GetChild(0).GetComponent<Button>().onClick.AddListener(StartWorkout);
        if (CurrentWorkout != null)
        {
            StartWorkoutPanel.SetActive(false);
            BeginTime = CurrentWorkout.Start;
        }
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
            Loading.StartSceneLoading(3);

        if (CurrentWorkout == null)
            return;

        var duration = DateTime.UtcNow - BeginTime;
        TimeText.text = String.Format("{0}:{1}:{2}",
            (int)duration.TotalHours,
            duration.Minutes < 10? "0" + duration.Minutes.ToString() : duration.Minutes.ToString(),
            duration.Seconds < 10 ? "0" + duration.Seconds.ToString() : duration.Seconds.ToString());
    }

    public void StartWorkout()
    {
        WorkoutTable.StartWorkout();
        Loading.StartSceneLoading(6);
    }

    public void AddElement()
    {
        Loading.StartSceneLoading(1);
    }

    public void EndWorkout()
    {
        WorkoutTable.EndWorkout();
        Loading.StartSceneLoading(6);
    }

    public void CloseTaskPanel()
    {

    }
}
