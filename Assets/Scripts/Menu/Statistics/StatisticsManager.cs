using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StatisticsManager : MonoBehaviour
{
    [SerializeField]
    private LoadingManager Loading;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
            Loading.StartSceneLoading(3);
    }
}
