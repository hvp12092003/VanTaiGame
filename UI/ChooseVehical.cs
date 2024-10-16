using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using static OBJ_DontDesTroy;

public class ChooseVehical : MonoBehaviour
{
    public AudioSource touchUI;
    private GameObject gateL;
    private GameObject gateR;
    void Start()
    {
        gateL = GameObject.FindGameObjectWithTag("gateL");// panelcam1
        gateR = GameObject.FindGameObjectWithTag("gateR");// panelcam1

        objDDT.Instance.PlayOpenDoor();
        gateL.transform.DOMoveX(-15, 1f);
        gateR.transform.DOMoveX(15, 1f);
    }
    public void ChooseBoat()
    {
        touchUI.Play();
        objDDT.Instance.PlayCloseDoor();
        gateL.transform.DOMoveX(-4.44f, 1f).SetEase(Ease.OutBounce);
        gateR.transform.DOMoveX(4.44f, 1f).SetEase(Ease.OutBounce).OnComplete(() =>
        {
            objDDT.Instance.kindOfVehicel = OBJ_DontDesTroy.Vehicle.Boat;
            SceneManager.LoadScene(3);
        });
    }
    public void ChooseBike()
    {
        touchUI.Play();
        objDDT.Instance.PlayCloseDoor();
        gateL.transform.DOMoveX(-4.44f, 1f).SetEase(Ease.OutBounce);
        gateR.transform.DOMoveX(4.44f, 1f).SetEase(Ease.OutBounce).OnComplete(() =>
        {
            objDDT.Instance.kindOfVehicel = OBJ_DontDesTroy.Vehicle.Bike;
            SceneManager.LoadScene(6);
        });
    }
    public void ChooseHorseWagon()
    {
        touchUI.Play();
        objDDT.Instance.PlayCloseDoor();
        gateL.transform.DOMoveX(-4.44f, 1f).SetEase(Ease.OutBounce);
        gateR.transform.DOMoveX(4.44f, 1f).SetEase(Ease.OutBounce).OnComplete(() =>
        {
            objDDT.Instance.kindOfVehicel = OBJ_DontDesTroy.Vehicle.HorseWagon;
            SceneManager.LoadScene(10);
        });
    }
}
