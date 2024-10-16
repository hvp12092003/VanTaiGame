using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Big_Stone_Map4 : MonoBehaviour
{
    public GameObject obj2;
    public GameObject obj3;
    public AudioSource tnt;
    void Start()
    {
        obj2 = GameObject.FindGameObjectWithTag("obj2");// stone
        obj3 = GameObject.FindGameObjectWithTag("obj3");// tnt
    }
    public void PlayAudioTNT()
    {
        //   if (objDDT.Instance.audioGame)
        tnt.Play();
    }
    public void DestroyStoneAndTNT()
    {
        Destroy(obj2.gameObject);
        Destroy(obj3.gameObject);
        Destroy(this.gameObject);
    }
}
