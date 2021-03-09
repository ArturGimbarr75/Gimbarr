using Assets.Scripts.ModelControllers;
using Assets.Scripts.Models;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class SearchManager : MonoBehaviour
{
    private ElementTableManager InfoTable;
    private InputField Field;
    private Dropdown DropdownStyles;
    private List<Element> AllElements;
    private List<GimbarrElements.GimbarrStyle> DropdownElements;

    void Awake()
    {
        InfoTable = GameObject.Find("Content").GetComponent<ElementTableManager>();

        DropdownElements = new List<GimbarrElements.GimbarrStyle>()
        {
            GimbarrElements.GimbarrStyle.All,
            GimbarrElements.GimbarrStyle.Figuras,
            GimbarrElements.GimbarrStyle.Giros,
            GimbarrElements.GimbarrStyle.Yoyos
        };

        Field = GetComponent<InputField>();
        Field.onValueChanged.AddListener(delegate { OnSearchConditionChanged(); });

        DropdownStyles = GameObject.Find("StylesDropdown").GetComponent<Dropdown>();
        DropdownStyles.ClearOptions();
        DropdownStyles.AddOptions(DropdownElements.Select(x => x.ToString()).ToList());
        DropdownStyles.onValueChanged.AddListener(delegate { OnSearchConditionChanged(); });

        AllElements = GimbarrElements.AllElements;
    }

    private void OnSearchConditionChanged()
    {
        var list = AllElements.Where
            (
                x =>
                (Field.text == string.Empty ? true : x.ElementName.ToLower().Contains(Field.text.ToLower())) &&
                (DropdownElements[DropdownStyles.value].HasFlag(x.Style))
            ).Select(x => x).ToList();
        InfoTable.UpdateTable(list);
    }
}
