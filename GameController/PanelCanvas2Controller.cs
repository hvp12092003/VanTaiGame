using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

public class PanelCanvas2Controller : MonoBehaviour
{
    public Image Image;
    public Sprite[] sprites;
    void Start()
    {
        Image = this.GetComponent<Image>();
        switch (objDDT.Instance.language)
        {
            case OBJ_DontDesTroy.Language.Viet:
                Image.sprite = objDDT.Instance.spriteCanvas2[0];
                break;
            case OBJ_DontDesTroy.Language.English:
                Image.sprite = objDDT.Instance.spriteCanvas2[1];
                break;
            case OBJ_DontDesTroy.Language.France:
                Image.sprite = objDDT.Instance.spriteCanvas2[2];
                break;
        }
    }
}