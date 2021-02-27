using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Assets.Scripts.SingletoneModel;
using UnityEngine.UI;

public class MainMenuButtonsManager : MonoBehaviour
{
    [SerializeField]
    private LoadingManager Loading;
    [SerializeField]
    private Image FlagImage;
    [SerializeField]
    private List<Sprite> FlagsList;
    private Dictionary<TranslationSingletone.Language, Sprite> Flags;

    private void Start()
    {
        Flags = new Dictionary<TranslationSingletone.Language, Sprite>();
        Flags.Add(TranslationSingletone.Language.RU, FlagsList[0]);
        Flags.Add(TranslationSingletone.Language.LT, FlagsList[1]);
        Flags.Add(TranslationSingletone.Language.EN, FlagsList[2]);
        Flags.Add(TranslationSingletone.Language.PL, FlagsList[3]);
        FlagImage.sprite = Flags[TranslationSingletone.Instance.CurrentLanguage];
    }

    void Update()
    {
        if (Input.GetKeyUp(KeyCode.Escape))
            Application.Quit();
    }

    public void OnElementsListClick()
    {
        Loading.StartSceneLoading(1);
    }

    public void OnWorkoutClick()
    {
        Loading.StartSceneLoading(3);
    }

    public void OnFlagClick()
    {
        TranslationSingletone.Instance.NextLanguage();
        FlagImage.sprite = Flags[TranslationSingletone.Instance.CurrentLanguage];
    }
}
