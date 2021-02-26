using Assets.Scripts.ModelControllers;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class MainMenuManager : MonoBehaviour
{
    [SerializeField]
    private Text Statistics;

    void Start()
    {
        var line = "Giros: {0}\nFiguras: {1}\nYoyos: {2}";
        Statistics.text = String.Format
        (
            line,
            GimbarrElements.AllElements.Count(x => x.Style == GimbarrElements.GimbarrStyle.Giros),
            GimbarrElements.AllElements.Count(x => x.Style == GimbarrElements.GimbarrStyle.Figuras),
            GimbarrElements.AllElements.Count(x => x.Style == GimbarrElements.GimbarrStyle.Yoyos)
        );
    }
}
