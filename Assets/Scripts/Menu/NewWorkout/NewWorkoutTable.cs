using Assets.Scripts.DataBase.WorkoutElementTableNS;
using Assets.Scripts.DataBase.WorkoutTableNS;
using Assets.Scripts.ModelControllers;
using Assets.Scripts.SingletoneModel;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class NewWorkoutTable : MonoBehaviour
{
    [SerializeField]
    private GameObject TaskPanel;
    [SerializeField]
    private GameObject AddPanel;
    [SerializeField]
    private Button YesButton;
    [SerializeField]
    private LoadingManager Loading;

    private GameObject Prefab;
    private List<Text> Texts;
    private RectTransform Rect;
    private const int BUTTON_HEIGHT = 150;
    private const int SCROLLBAR_WIDTH = 20;

    void Awake()
    {
        Texts = new List<Text>();
        Rect = GetComponent<RectTransform>();
        Prefab = transform.GetChild(0).gameObject;
        Prefab.SetActive(false);
        StartCoroutine("SetUpTable");
    }

    public IEnumerator SetUpTable()
    {
        int workoutId;
        if (!WorkoutTable.HasUnfinishedWorkout(out workoutId))
            yield break;

        var list = WorkoutElementTable.GetWorkoutElements(workoutId);
        if (list.Count == 0)
            yield break;

        list = list.OrderBy(x => x.Order).ToList();
        int elementsAdded = 0;
        int perFrame = 150;
        int minFont = Prefab.transform.GetChild(1).GetComponent<Text>().fontSize;

        while (elementsAdded < list.Count)
        {
            elementsAdded += perFrame;
            int currentCount = Mathf.Min(elementsAdded, list.Count);
            Rect.sizeDelta = new Vector2(0, BUTTON_HEIGHT * currentCount);

            for (int i = elementsAdded - perFrame; i < currentCount; i++)
            {
                var nextEl = Instantiate(Prefab);
                nextEl.SetActive(true);
                nextEl.transform.SetParent(transform);
                nextEl.GetComponent<RectTransform>().sizeDelta = new Vector2(Screen.width - SCROLLBAR_WIDTH, BUTTON_HEIGHT);
                nextEl.transform.GetChild(0).GetComponent<Text>().text = (i + 1).ToString();
                nextEl.transform.GetChild(1).GetComponent<Text>().text =
                    GimbarrElements.AllElements.First(x => x.ID == list[i].ElementId).ElementName;
                int id = list[i].ID;
                nextEl.transform.GetChild(2).GetComponent<Button>().onClick.AddListener(delegate               
                {
                    WorkoutElementTable.DeleteElement(id);
                    Loading.StartSceneLoading(6);
                });
                int index = i;
                nextEl.GetComponent<Button>().onClick.AddListener(delegate
                {
                    AddPanel.SetActive(true);
                    AddPanel.transform.GetChild(1).GetComponent<Button>().onClick.AddListener(delegate
                    {
                        WorkoutElementTable.AddElementToWorkout(list[index].ElementId);
                        AddPanel.SetActive(false);
                        Loading.StartSceneLoading(6);
                    });
                });


                Texts.Add(nextEl.transform.GetChild(1).GetComponent<Text>());
            }

            yield return new WaitForEndOfFrame();
        }
        SetTextSize();
        yield return null;
    }

    void SetTextSize()
    {
        var minFontSize = Texts.Where(x => x.cachedTextGenerator.fontSizeUsedForBestFit != 0)
            .Min(x => x.cachedTextGenerator.fontSizeUsedForBestFit);
        Texts.ForEach(x => x.resizeTextMaxSize = minFontSize);
    }
}
