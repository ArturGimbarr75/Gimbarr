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

class ElementCell : MonoBehaviour, ICell
{
    public Text ElementName;

    [SerializeField]
    private GameObject ChoicePanel;
    [SerializeField]
    private LoadingManager Loading;

    private int ID;

    void Start()
    {
        GetComponent<Button>().onClick.AddListener(ButtonListener);
    }

    public void ConfigureCell(string elementName, int id)
    {
        ID = id;
        ElementName.text = elementName;
    }

    private void ButtonListener()
    {
        if (FunctionInElementsList.Instance.Function == FunctionInElementsList.FunctionType.Info)
        {
            SelectedElement.Instance.Selected = GimbarrElements.AllElements.First(x => x.ID == ID);
            Loading.StartSceneLoading(2);
        }
        else
        {
            SelectedElement.Instance.Selected = GimbarrElements.AllElements.First(x => x.ID == ID);
            ChoicePanel.SetActive(true);
        }
    }
}
