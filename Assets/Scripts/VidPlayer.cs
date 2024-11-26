using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

public class VidPlayer : MonoBehaviour
{
    [SerializeField]
    private string fileName;

    // Start is called before the first frame update
    void Start() {
        VideoPlayer videoPlayer = GetComponent<VideoPlayer>();
        if (videoPlayer) {
            string videoPath = System.IO.Path.Combine(Application.streamingAssetsPath, fileName);
            videoPlayer.url = videoPath;
        } // if 
    } // Start

    // Update is called once per frame
    void Update()
    {

    } // Update
}
