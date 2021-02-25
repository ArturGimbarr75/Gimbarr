using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorkoutListManager : MonoBehaviour
{
    [SerializeField]
    private LoadingManager Loading;

    void Update()
    {
        if (Input.GetKeyUp(KeyCode.Escape))
            Loading.StartSceneLoading(3);
    }
}
