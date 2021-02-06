using Assets.Scripts.SingletoneModel;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using YoutubePlayer;

public class SelectVideo : MonoBehaviour
{
    void Awake()
    {
        GetComponent<SimpleYoutubeVideo>().videoUrl = SelectedElement.Instance.Selected.Url;
    }
}
