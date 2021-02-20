using Assets.Scripts.DataBase.WorkoutElementTableNS;
using Assets.Scripts.DataBase.WorkoutTableNS;
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
            GetString(),
            WorkoutTable.GetCountOfCompletedWorkouts(),
            WorkoutElementTable.GetCountOfCompletedElements(),
            WorkoutElementTable.GetCountOfDifferentCompletedElements()
        );
    }

    string GetString()
    {
        return "Количество тренировок: {0}\nВыполнено элементов: {1}\nРазных элементов: {2}";
    }
}
