using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

public class VideoSetup : MonoBehaviour
{
    public VideoPlayer vd;
    public GameObject cam2;
    // Start is called before the first frame update
    void Start()
    {
        vd = this.GetComponent<VideoPlayer>();
        cam2 = GameObject.FindGameObjectWithTag("cam2");
        vd.targetCamera = cam2.GetComponent<Camera>();
    }
}
