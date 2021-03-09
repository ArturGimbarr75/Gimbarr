using Assets.Scripts.ModelControllers;
using Assets.Scripts.Models;
using PolyAndCode.UI;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class ElementTableManager : MonoBehaviour, IRecyclableScrollRectDataSource
{
    [SerializeField]
    RecyclableScrollRect RecyclableScroll;
    [SerializeField]
    GameObject Content;

    private List<InitInfo> Elements;

    void Awake()
    {
        Elements = new List<InitInfo>();
        UpdateTable(GimbarrElements.AllElements);
        RecyclableScroll.DataSource = this;
    }

    public void UpdateTable(List<Element> elements)
    {
        Elements.Clear();
        foreach (var el in elements)
            Elements.Add(new InitInfo()
            {
                ElementName = el.ElementName,
                ID = el.ID
            });
        Elements = Elements.OrderBy(x => x.ElementName).ToList();

        RecyclableScroll.ReloadData();
    }

    public int GetItemCount()
    {
        return Elements.Count;
    }

    public void SetCell(ICell cell, int index)
    {
        var item = cell as ElementCell;
        if (index > Elements.Count - 1 || index < 0)
            return;
        item.ConfigureCell(Elements[index].ElementName, Elements[index].ID);
    }

    private struct InitInfo
    {
        public string ElementName { get; set; }
        public int ID { get; set; }

        public override string ToString()
        {
            return $"{ElementName} ID: {ID}";
        }
    }
}
