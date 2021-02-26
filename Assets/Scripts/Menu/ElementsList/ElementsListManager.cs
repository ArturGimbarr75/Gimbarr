using Assets.Scripts.DataBase.WorkoutElementTableNS;
using Assets.Scripts.SingletoneModel;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ElementsListManager : MonoBehaviour
{
    [SerializeField]
    private LoadingManager Loading;
    [SerializeField]
    private GameObject ChoicePanel;

    void Update()
    {
        if (Input.GetKeyUp(KeyCode.Escape))
        {
            if (ChoicePanel.activeSelf)
                ChoicePanel.SetActive(false);
            else
                Loading.StartSceneLoading(0);
        }
    }

    public void OnAddClick()
    {
        WorkoutElementTable.AddElementToWorkout(SelectedElement.Instance.Selected.ID);
        Loading.StartSceneLoading(6);
    }

    public void OnInfoClick()
    {
        Loading.StartSceneLoading(2);
    }
}
