using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ChangePanelLanguage : MonoBehaviour
{
    public Sprite[] images;
    public Image image;
    // Start is called before the first frame update
    void Start()
    {
        image = this.GetComponent<Image>();
        switch (objDDT.Instance.language)
        {
            case OBJ_DontDesTroy.Language.Viet:
                image.sprite = images[0];
                break;
            case OBJ_DontDesTroy.Language.English:
                image.sprite = images[1];
                break;
            case OBJ_DontDesTroy.Language.France:
                image.sprite = images[2];
                break;
        }
    }
}
