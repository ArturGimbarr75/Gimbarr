using Assets.Scripts.DataBase.WorkoutElementTableNS;
using Assets.Scripts.ModelControllers;
using Assets.Scripts.SingletoneModel;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class WorkoutInfoTable : MonoBehaviour
{
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
        var list = WorkoutElementTable.GetWorkoutElements(SelectedWorkout.Instance.Selected.ID);
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
