using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SetSizeOnPrefab : MonoBehaviour
{
    private static int? FontSize = null;

    void Awake()
    {
        if (FontSize == null)
        {
            var text = GetComponent<Text>();
            FontSize = text.fontSize;
            text.resizeTextForBestFit = false;
            text.fontSize = (int)FontSize;
        }
    }

    void OnDestroy()
    {
        FontSize = null;
    }
}
