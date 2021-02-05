using Assets.Scripts.ModelControllers;
using Assets.Scripts.Models;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class TableManager : MonoBehaviour
{
    private GameObject Prefab;

    void Start()
    {
        Prefab = transform.GetChild(0).gameObject;
        Prefab.SetActive(false);
        SetTable(GimbarrElements.AllElements);
    }

    public void SetTable(List<Element> list)
    {
        List<GameObject> objToRemove = new List<GameObject>();
        for (int i = 0; i < transform.childCount; i++)
            objToRemove.Add(transform.GetChild(i).gameObject);

        for (int i = 0; i < objToRemove.Count; i++)
            if (objToRemove[i].activeSelf)
                Destroy(objToRemove[i]);

        list = list.OrderBy(x => x.ElementName).ToList();
        foreach (var el in list)
        {
            var nextEl = Instantiate(Prefab);
            nextEl.SetActive(true);
            nextEl.transform.SetParent(transform);
            nextEl.transform.localScale = Vector3.one;
            nextEl.GetComponentInChildren<Text>().text = el.ElementName;
        }
    }
}
