using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class MenuChooseVehicalController : MonoBehaviour
{
    public string[] textBoat;
    public string[] textBike;
    public string[] textHorseWagon;
    public TextMeshProUGUI t_Boat;
    public TextMeshProUGUI t_Bike;
    public TextMeshProUGUI t_HorseWagon;

    public Image imageCanvas1L;
    public Image imageCanvas1R;
    public Image imageCanvas2;
    // Start is called before the first frame update
    void Start()
    {
        Handler();
    }
    public void Handler()
    {
        switch (objDDT.Instance.language)
        {
            case OBJ_DontDesTroy.Language.Viet:
                t_Boat.text = textBoat[0];
                t_Bike.text = textBike[0];
                t_HorseWagon.text = textHorseWagon[0];

                imageCanvas1L.sprite = objDDT.Instance.spriteCanvasLR[0];
                imageCanvas1R.sprite = objDDT.Instance.spriteCanvasLR[1];
                imageCanvas2.sprite = objDDT.Instance.spriteCanvas2[0];
                break;
            case OBJ_DontDesTroy.Language.English:
                t_Boat.text = textBoat[1];
                t_Bike.text = textBike[1];
                t_HorseWagon.text = textHorseWagon[1];

                imageCanvas1L.sprite = objDDT.Instance.spriteCanvasLR[2];
                imageCanvas1R.sprite = objDDT.Instance.spriteCanvasLR[3];
                imageCanvas2.sprite = objDDT.Instance.spriteCanvas2[1];
                break;
            case OBJ_DontDesTroy.Language.France:
                t_Boat.text = textBoat[2];
                t_Bike.text = textBike[2];
                t_HorseWagon.text = textHorseWagon[2];

                /* imageCanvas1L.sprite =  objDDT.Instance.spriteCanvasLR[4];
                 imageCanvas1R.sprite =  objDDT.Instance.spriteCanvasLR[5];*/
                imageCanvas2.sprite = objDDT.Instance.spriteCanvas2[3];
                break;
        }
    }
}
