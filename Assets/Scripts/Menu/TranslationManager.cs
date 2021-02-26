using Assets.Scripts.SingletoneModel;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TranslationManager : MonoBehaviour
{
    [SerializeField]
    private int Key;


    void Awake()
    {
        SetText();
        TranslationSingletone.Instance.OnLanguageChanged += OnLanguageChanged;
    }

    void OnLanguageChanged(object sender, EventArgs e)
    {
        SetText();
    }

    void SetText()
    {
        GetComponent<Text>().text = TranslationSingletone.Instance.GetTranslation(Key);
    }
}
