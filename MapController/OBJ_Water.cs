using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class OBJ_Water : MonoBehaviour
{
    private GameObject water1;
    private GameObject water2;
    // Start is called before the first frame update
    void Start()
    {
        water1 = GameObject.FindGameObjectWithTag("Water1");// 
        water2 = GameObject.FindGameObjectWithTag("Water2");// 

        ActionWater();

    }
    private void ActionWater()
    {
        water1.transform.DOMoveX(25, 25).SetLoops(-1, LoopType.Yoyo).SetEase(Ease.Linear);
        water2.transform.DOMoveX(-25f, 25).SetLoops(-1, LoopType.Yoyo).SetEase(Ease.Linear);
    }

}
