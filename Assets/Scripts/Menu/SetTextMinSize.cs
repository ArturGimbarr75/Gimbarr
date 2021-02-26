using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class SetTextMinSize : MonoBehaviour
{
    [SerializeField]
    private Text[] TextArr;

    void Start()
    {
        StartCoroutine("SetTextFontSize");
    }

    IEnumerator SetTextFontSize()
    {
        if (TextArr.Length != 0)
        {
            yield return new WaitForEndOfFrame();

            int minFontSize = int.MaxValue;
            foreach (var t in TextArr)
            {
                t.resizeTextForBestFit = false;
                if (t.cachedTextGenerator.fontSizeUsedForBestFit < minFontSize)
                {
                    minFontSize = t.cachedTextGenerator.fontSizeUsedForBestFit;
                }
            }
            foreach (var t in TextArr)
            {
                t.resizeTextForBestFit = false;
                t.fontSize = minFontSize;
            }
        }
        yield return null;
    }


}
