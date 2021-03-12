using Assets.Scripts.DataBase.WorkoutElementTableNS;
using Assets.Scripts.ModelControllers;
using Assets.Scripts.Models;
using Assets.Scripts.SingletoneModel;
using PolyAndCode.UI;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class StatisticsTable : MonoBehaviour, IRecyclableScrollRectDataSource
{
    private List<ElementAndRepeatCount> Elements;
    [SerializeField]
    RecyclableScrollRect RecyclableScroll;

    void Awake()
    {   
        RecyclableScroll.DataSource = this;
        Elements = WorkoutElementTable.GetElementsAndRepeatsCount();
        Elements = Elements.OrderBy(x => x.ElementName).ToList();
    }

    public int GetItemCount()
    {
        return Elements.Count;
    }

    public void SetCell(ICell cell, int index)
    {
        var item = cell as StatisticsCell;
        if (index > Elements.Count - 1 || index < 0)
            return;
        item.ConfigureCell(GimbarrElements.AllElements.Find(x => x.ID == Elements[index].ElementInstance.ID).ElementName, Elements[index].RepeatCount);
    }
}
