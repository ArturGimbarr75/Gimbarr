using Assets.Scripts.SingletoneModel;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StatisticsManager : MonoBehaviour
{
    [SerializeField]
    private LoadingManager Loading;
    [SerializeField]
    private GameObject InfoPanel;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
            Loading.StartSceneLoading(3);
    }

    public void OnInfoClick()
    {
        FunctionInElementsList.Instance.Function = FunctionInElementsList.FunctionType.Info;
        Loading.StartSceneLoading(2);
    }

    public void OnCloseClick()
    {
        InfoPanel.SetActive(false);
    }
}
