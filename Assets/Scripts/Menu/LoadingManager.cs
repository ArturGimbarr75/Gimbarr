using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LoadingManager : MonoBehaviour
{
    [SerializeField]
    private GameObject LoadingObject;
    [SerializeField]
    private bool FindingButtonsAutomatically;
    [SerializeField]
    private Button[] Buttons;

    void Awake()
    {
        if (FindingButtonsAutomatically)
        {
            Buttons = GameObject.FindObjectsOfType<Button>();
        }
    }

    public void StartSceneLoading(int sceneNumber)
    {
        foreach (var b in Buttons)
            b.interactable = false;

        LoadingObject.SetActive(true);
        AsyncOperation operation = SceneManager.LoadSceneAsync(sceneNumber);
        //operation.allowSceneActivation = false;
    }

}
