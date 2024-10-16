using DG.Tweening;
using UnityEngine;

public class OBJ_Clouds : MonoBehaviour
{
    private GameObject clouds;

    // Start is called before the first frame update
    void Start()
    {
        clouds = GameObject.FindGameObjectWithTag("clouds");
        clouds.transform.DOMoveY(0.2f, 5f).SetLoops(-1, LoopType.Yoyo).SetEase(Ease.Linear);
    }
}
