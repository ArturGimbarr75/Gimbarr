using Assets.Scripts.ModelControllers;
using Assets.Scripts.Models;
using Assets.Scripts.SingletoneModel;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SetUpElementInfo : MonoBehaviour
{
    public Text Title;
    public Text Style;

    public GameObject SameElementsTable;
    public GameObject ButtonPrefab;

    private const int BUTTON_HEIGHT = 150;

    void Awake()
    {
        var element = SelectedElement.Instance.Selected;

        Title.text = element.ElementName;
        Style.text = "Style: " + element.Style.ToString();

        SetUpButtons();
    }

    void SetUpButtons()
    {
        int maxButtonsCount = (int)(SameElementsTable.GetComponent<RectTransform>().rect.height / (float)BUTTON_HEIGHT);
        string[] notForSearch =
        {
            "a",
            "de",
            "en",

            "unic",
            "contra",
            "omega",

            "seudo",
            "normal",
            "cubital",
            "chalito",
            "aqua",
            "rosa",
            "cripta",
            "supremo",

            "loto",
            "insidioso",
            "anti",

            "x",
            "z",
            "g",
            "q-k",
            "q-y"
        };
        string[] forSearch = SelectedElement.Instance.Selected.ElementName.Split(' ').Where(x => !notForSearch.Contains(x.ToLower())).Select(x => x).ToArray();
        var elementsList = GimbarrElements.AllElements
            .Where(el => forSearch.Where(x => el.ElementName.ToLower().Contains(x.ToLower())).Select(x => x).Count() > 0)
            .Select(el => el).ToList();

        /*HashSet<int> selected = new HashSet<int>();
        for (int i = 0; i < 10000 && selected.Count < forSearch.Count() && selected.Count < maxButtonsCount; i++)
            selected.Add(elementsList[Random.Range(0, elementsList.Count())]);
        Element[] elements = GimbarrElements.AllElements.Where(x => selected.Contains(x.ID)).ToArray();*/

        for (int i = 0; i < maxButtonsCount && i < elementsList.Count(); i++)
        {
            var tempButton = Instantiate(ButtonPrefab);
            tempButton.SetActive(true);
            tempButton.transform.SetParent(SameElementsTable.transform);

            var locPos = tempButton.GetComponent<RectTransform>().localPosition;
            tempButton.GetComponent<RectTransform>().localPosition = new Vector3(0, locPos.y + BUTTON_HEIGHT * i, 0);
            tempButton.GetComponent<RectTransform>().sizeDelta = new Vector2(SameElementsTable.GetComponent<RectTransform>().sizeDelta.x, BUTTON_HEIGHT);

            tempButton.GetComponentInChildren<Text>().text = elementsList[i].ElementName;
            int id = elementsList[i].ID;
            tempButton.GetComponent<Button>().onClick.AddListener(delegate
            {
                SelectedElement.Instance.Selected = GimbarrElements.AllElements.First(x => x.ID == id);
                SceneManager.LoadScene(2);
            });
        }
    }
}
