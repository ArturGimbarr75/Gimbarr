﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorkoutInfoManager : MonoBehaviour
{
    [SerializeField]
    private LoadingManager Loading;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
            Loading.StartSceneLoading(4);
    }
}
