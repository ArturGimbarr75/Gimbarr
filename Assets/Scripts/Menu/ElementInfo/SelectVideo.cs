using Assets.Scripts.SingletoneModel;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using YoutubePlayer;

public class SelectVideo : MonoBehaviour
{
    [SerializeField]
    GameObject Loading;
    [SerializeField]
    GameObject Panel;
    [SerializeField]
    VideoPlayerProgress Progress;
    SimpleYoutubeVideo SYV;

    void Awake()
    {
        SYV = GetComponent<SimpleYoutubeVideo>();
        SYV.videoUrl = SelectedElement.Instance.Selected.Url;
    }

    void Update()
    {
        if (Progress.videoPlayer.isPrepared && Panel.activeSelf)
            Loading.SetActive(false);
    }
}
