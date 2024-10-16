using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Landmine_MapHorseWagon_2 : MonoBehaviour
{
    public void ScaleOBJ()
    {
        this.transform.localScale = new Vector3(5, 5, 5);
    }
    public void Destroy()
    {
        Destroy(this.gameObject);
    }

}
