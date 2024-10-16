using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonAudio : MonoBehaviour
{
    public GameObject on, Off;
    public bool music;
    // Start is called before the first frame update
    void Start()
    {
        this.gameObject.SetActive(false); return;
        SwichButton();
    }
    public void UpdateStatusAudio()
    {
        // objDDT.Instance.UpdateAudioMain();
        SwichButton();
    }
    private void SwichButton()
    {
        // if (objDDT.Instance.audioGame)
        //  {
        on.SetActive(true);
        Off.SetActive(false);
        //  }
        //  else
        //  {
        on.SetActive(false);
        Off.SetActive(true);
        //  }
    }
}
