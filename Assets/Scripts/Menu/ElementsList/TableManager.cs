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
    private GameObject Prefab;
    private RectTransform Rect;
    private const int BUTTON_HEIGHT = 150;
    private List<GameObject> Buttons;

    void Start()
    {
        Rect = GetComponent<RectTransform>();
        Prefab = transform.GetChild(0).gameObject;
        Prefab.SetActive(false);
        Buttons = new List<GameObject>();
        SetUpTable();
    }

    public void SetUpTable()
    {
        var list = GimbarrElements.AllElements.OrderBy(x => x.ElementName).ToList();
        Rect.sizeDelta = new Vector2(0, BUTTON_HEIGHT * list.Count);

        foreach (var el in list)
        {
            var nextEl = Instantiate(Prefab);
            nextEl.SetActive(true);
            nextEl.transform.SetParent(transform);
            nextEl.GetComponentInChildren<Text>().text = el.ElementName;
            int id = el.ID;
            nextEl.GetComponent<Button>().onClick.AddListener(delegate
            {
                SelectedElement.Instance.Selected = GimbarrElements.AllElements.First(x => x.ID == id);
                SceneManager.LoadScene(2);
            });
            Buttons.Add(nextEl);
        }
    }

    public void UpdateTable(List<Element> list)
    {
        var elNames = list.Select(x => x.ElementName).OrderBy(x => x).ToList();

        Rect.sizeDelta = new Vector2(0, BUTTON_HEIGHT * list.Count);
        foreach (var el in Buttons)
            el.SetActive(elNames.Contains(el.GetComponentInChildren<Text>().text));   
    }
}
