using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorkoutListManager : MonoBehaviour
{
    [SerializeField]
    private LoadingManager Loading;
    [SerializeField]
    private GameObject TaskPanel;



    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
            Loading.StartSceneLoading(3);
    }

    public void CloseTaskPanel()
    {
        TaskPanel.SetActive(false);
    }
}
