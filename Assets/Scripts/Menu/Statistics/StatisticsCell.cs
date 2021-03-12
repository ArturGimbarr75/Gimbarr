using Assets.Scripts.ModelControllers;
using Assets.Scripts.SingletoneModel;
using PolyAndCode.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.UI;

class StatisticsCell : MonoBehaviour, ICell
{
    private string ElementName;
    private int Count;
    [SerializeField]
    private GameObject InfoPanel;
    [SerializeField]
    private Text Name;
    [SerializeField]
    private Text RepeatCount;

    void Start()
    {
        GetComponent<Button>().onClick.AddListener(ButtonListener);
    }

    public void ConfigureCell(string elementName, int count)
    {
        Count = count;
        ElementName = elementName;

        Name.text = ElementName;
        RepeatCount.text = Count.ToString();
    }

    private void ButtonListener()
    {
        SelectedElement.Instance.Selected = GimbarrElements.AllElements.First(x => x.ElementName == ElementName);
        InfoPanel.SetActive(true);
    }
}
