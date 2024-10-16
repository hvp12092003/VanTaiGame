using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BigStone_MapHorseWagon4 : MonoBehaviour
{
    public GameObject obj3;
    public GameObject obj2;
    public GameObject obj7;

    // Start is called before the first frame update
    void Start()
    {
        obj2 = GameObject.FindGameObjectWithTag("obj2");//small stone
        obj3 = GameObject.FindGameObjectWithTag("obj3");//TNT
        obj7 = GameObject.FindGameObjectWithTag("obj7");//TNT
    }
    public void DestroyTNT()
    {
        Destroy(obj3.gameObject);
        //Destroy(obj7.gameObject);
    }
    public void DestroyOBJ()
    {
        Destroy(obj2.gameObject);
        Destroy(this.gameObject);
    }
}
