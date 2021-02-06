using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetTableSize : MonoBehaviour
{
    private const int MENU_HEIGHT = 400;
    void Awake()
    {
        int screenHeight = Screen.height;
        var rect = GetComponent<RectTransform>();
        rect.sizeDelta = new Vector2(rect.rect.width, screenHeight - MENU_HEIGHT);
        rect.position = new Vector3(rect.position.x, (screenHeight - MENU_HEIGHT) / 2, rect.position.z);
    }
}
