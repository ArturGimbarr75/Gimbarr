using Assets.Scripts.DataBase.WorkoutTableNS;
using Assets.Scripts.ModelControllers;
using Assets.Scripts.Models;
using Assets.Scripts.SingletoneModel;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class WorkoutListTableManager : MonoBehaviour
{
    [SerializeField]
    private LoadingManager Loading;

    private GameObject Prefab;
    private RectTransform Rect;
    private const int BUTTON_HEIGHT = 150;
    private const int SCROLLBAR_WIDTH = 20;
    private List<GameObject> Buttons;

    void Awake()
    {
        Rect = GetComponent<RectTransform>();
        Prefab = transform.GetChild(0).gameObject;
        Prefab.SetActive(false);
        Buttons = new List<GameObject>();
        StartCoroutine("SetUpTable");
    }

    public IEnumerator SetUpTable()
    {
        List<Text> texts = new List<Text>();
        var workoutList = WorkoutTable.GetAllCompletedWorkoutsWithElementsCount(out var elementsCount);
        int woekoutsAdded = 0,
            perFrame = 150,
            minFont = int.MaxValue;

        Prefab.SetActive(false);

        while (woekoutsAdded < workoutList.Count)
        {
            woekoutsAdded += perFrame;
            int currentCount = Mathf.Min(woekoutsAdded, workoutList.Count);
            Rect.sizeDelta = new Vector2(0, BUTTON_HEIGHT * currentCount);

            for (int i = woekoutsAdded - perFrame; i < currentCount; i++)
            {
                var nextEl = Instantiate(Prefab);
                nextEl.SetActive(true);
                nextEl.transform.SetParent(transform);
                nextEl.GetComponent<RectTransform>().sizeDelta = new Vector2(Screen.width - SCROLLBAR_WIDTH, BUTTON_HEIGHT);

                nextEl.transform.GetChild(0).GetComponent<Text>().text = workoutList[i].Start.ToLocalTime().ToShortDateString();
                nextEl.transform.GetChild(1).GetComponent<Text>().text = ((int)(workoutList[i].Start - workoutList[i].End).TotalMinutes).ToString() + " min";
                nextEl.transform.GetChild(2).GetComponent<Text>().text = elementsCount[i].ToString();

                int id = workoutList[i].ID;
                nextEl.GetComponent<Button>().onClick.AddListener(delegate
                {
                    SelectedWorkout.Instance.Selected = new Workout() { ID = id };
                    Loading.StartSceneLoading(5);
                });

                yield return new WaitForEndOfFrame();
            }

            yield return null;
        }
    }
}
