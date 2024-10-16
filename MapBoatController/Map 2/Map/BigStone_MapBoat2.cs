using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BigStone_MapBoat2 : MonoBehaviour
{
    public GameObject smallStone;
    public GameObject tnt;
    public void Destroy()
    {
        Destroy(this.gameObject);
    }
    public void TurnOffObj()
    {
        smallStone.SetActive(false);
        tnt.SetActive(false);
    }
}
