using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Video;
using UnityEngine.SceneManagement;

public class VideoController : MonoBehaviour
{
    public GameObject panelCam2;

    public VideoPlayer video1;
    public VideoPlayer video2;
    public VideoPlayer video3;
    public float numScene;
    // Start is called before the first frame update
    void Start()
    {
        if (SceneManager.GetActiveScene().buildIndex == 2)
        {
            if (!objDDT.Instance.playVideo) return;
            panelCam2 = GameObject.FindGameObjectWithTag("panelcam2");
            panelCam2.SetActive(false);
            switch (objDDT.Instance.kindOfVehicelVideo)
            {
                case OBJ_DontDesTroy.Vehicle.Bike:
                    video2.Play();
                    break;
                case OBJ_DontDesTroy.Vehicle.HorseWagon:
                    video3.Play();
                    break;
                case OBJ_DontDesTroy.Vehicle.Boat:
                    video1.Play();
                    break;
            }
        }
        else this.gameObject.SetActive(false);
    }
}
