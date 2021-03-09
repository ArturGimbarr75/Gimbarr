using Assets.Scripts.DataBase.WorkoutElementTableNS;
using Assets.Scripts.DataBase.WorkoutTableNS;
using Assets.Scripts.SingletoneModel;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ElementInfoManager : MonoBehaviour
{
    [SerializeField]
    private LoadingManager Loading;
    [SerializeField]
    private GameObject AddButton;
    [SerializeField]
    private GameObject PlayButton;
    [SerializeField]
    private GameObject VideoPanel;

    void Start()
    {
        if (FunctionInElementsList.Instance.Function == FunctionInElementsList.FunctionType.Info)
            AddButton.SetActive(false);
        else
            AddButton.SetActive(true);
    }

    void Update()
    {
        if (Input.GetKeyUp(KeyCode.Escape))
            Loading.StartSceneLoading(1);
    }

    public void OnAddClick()
    {
        if (WorkoutTable.HasUnfinishedWorkout())
        {
            WorkoutElementTable.AddElementToWorkout(SelectedElement.Instance.Selected.ID);
            Loading.StartSceneLoading(6);
        }
    }

    public void OnPlayClick()
    {
        PlayButton.SetActive(false);
        VideoPanel.SetActive(true);
    }
}
