using Assets.Scripts.DataBase.WorkoutElementTableNS;
using Assets.Scripts.DataBase.WorkoutTableNS;
using Assets.Scripts.SingletoneModel;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WorkoutStatisticsInfoManager : MonoBehaviour
{
    public Text Statistics;

    void Awake()
    {
        Statistics.text = string.Format
        (
            TranslationSingletone.Instance.GetTranslation(6),
            WorkoutTable.GetCountOfCompletedWorkouts(),
            WorkoutElementTable.GetCountOfCompletedElements(),
            WorkoutElementTable.GetCountOfDifferentCompletedElements()
        );
    }
}
