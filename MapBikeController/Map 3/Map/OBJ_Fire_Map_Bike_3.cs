using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
public class OBJ_Fire_Map_Bike_3 : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        this.transform.DOScale(new Vector3(0.6f, 0.6f), 0.01f).SetLoops(-1, LoopType.Yoyo);
    }
}
