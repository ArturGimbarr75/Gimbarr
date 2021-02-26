using Assets.Scripts.DataBase.WorkoutElementTableNS;
using Assets.Scripts.ModelControllers;
using Assets.Scripts.Models;
using Assets.Scripts.SingletoneModel;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class TableManager : MonoBehaviour
{
    [SerializeField]
    private LoadingManager Loading;
    [SerializeField]
    private GameObject ChoicePanel;

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
        var list = GimbarrElements.AllElements.OrderBy(x => x.ElementName).ToList();
        int elementsAdded = 0,
            perFrame = 150,
            minFont = Prefab.GetComponentInChildren<Text>().fontSize;
        while (elementsAdded < list.Count)
        {
            elementsAdded += perFrame;
            int currentCount = Mathf.Min(elementsAdded, list.Count);
            Rect.sizeDelta = new Vector2(0, BUTTON_HEIGHT * currentCount);

            bool isMinFontChanged = false;
            for (int i = elementsAdded - perFrame; i < currentCount; i++)
            {
                var nextEl = Instantiate(Prefab);
                nextEl.SetActive(true);
                nextEl.transform.SetParent(transform);
                nextEl.GetComponent<RectTransform>().sizeDelta = new Vector2(Screen.width - SCROLLBAR_WIDTH, BUTTON_HEIGHT);
                nextEl.GetComponentInChildren<Text>().text = list[i].ElementName;
                int id = list[i].ID;
                if (FunctionInElementsList.Instance.Function == FunctionInElementsList.FunctionType.Info)
                {                  
                    nextEl.GetComponent<Button>().onClick.AddListener(delegate
                    {
                        SelectedElement.Instance.Selected = GimbarrElements.AllElements.First(x => x.ID == id);
                        Loading.StartSceneLoading(2);
                    });
                }
                else
                {
                    nextEl.GetComponent<Button>().onClick.AddListener(delegate
                    {
                        SelectedElement.Instance.Selected = GimbarrElements.AllElements.First(x => x.ID == id);
                        ChoicePanel.SetActive(true);
                    });
                }

                var text = nextEl.GetComponentInChildren<Text>();
                text.resizeTextForBestFit = false;
                if (text.fontSize < minFont)
                {
                    minFont = nextEl.GetComponentInChildren<Text>().fontSize;
                    isMinFontChanged = true;
                }

                Buttons.Add(nextEl);
            }

            if (isMinFontChanged)
                Buttons.ForEach(x =>
                {
                    var text = x.GetComponentInChildren<Text>();
                    text.resizeTextForBestFit = false;
                    text.fontSize = minFont;
                });

            yield return new WaitForEndOfFrame();
        }

        yield return null;
    }

    public void UpdateTable(List<Element> list)
    {
        var elNames = list.Select(x => x.ElementName).OrderBy(x => x).ToList();
       
        foreach (var el in Buttons)
            el.SetActive(elNames.Contains(el.GetComponentInChildren<Text>().text));

        Rect.sizeDelta = new Vector2(0, BUTTON_HEIGHT * Buttons.Count(x => x.activeSelf));
    }
}
