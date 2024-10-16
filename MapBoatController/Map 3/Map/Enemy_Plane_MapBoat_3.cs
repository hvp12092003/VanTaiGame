using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Plane_MapBoat_3 : MonoBehaviour
{
    public bool direction = true;
    public GameObject obj1;

    public AudioSource audioPlane;
    void Start()
    {
        obj1 = GameObject.FindGameObjectWithTag("obj1");
        obj1.transform.DOMoveX(12.36f, 10f).SetEase(Ease.InOutSine).OnStepComplete(OnTweenStepComplete).SetLoops(-1, LoopType.Yoyo);
    }
    void OnTweenStepComplete()
    {
       // if (objDDT.Instance.audioGame)            
            audioPlane.Play();

        if (direction)
        {
            obj1.transform.DORotate(new Vector3(0, 0, 0), 0.5f);
            direction = false;
        }
        else
        {
            obj1.transform.DORotate(new Vector3(0, 180, 0), 0.5f);
            direction = true;
        }

    }
}
