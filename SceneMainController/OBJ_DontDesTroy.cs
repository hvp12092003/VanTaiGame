using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using HVPUnityBase.Base.DesignPattern;
public class OBJ_DontDesTroy : MonoBehaviour
{
    public static bool doneGame = false;
    public enum Vehicle
    {
        Boat, Bike, HorseWagon, NULL
    }
    public enum Language
    {
        Viet, English, France
    }
    public bool playVideo = false;

    public Vehicle kindOfVehicel;
    public Vehicle kindOfVehicelVideo;
    public Language language;

    public AudioSource soundBackground;
    public AudioSource audioWin;
    public AudioSource audioTouchUI;
    public AudioSource audioBike;
    public AudioSource audioBoat;
    public AudioSource audioHorseWagon;
    public AudioSource closeDoor;
    public AudioSource openDoor;

    public Sprite[] spriteCanvasLR;
    public Sprite[] spriteCanvas1;
    public Sprite[] spriteCanvas2;
    // Start is called before the first frame update
    void Start()
    {
        DontDestroyOnLoad(this.gameObject);
        SceneManager.LoadScene(1);
        language = Language.Viet;
    }
    public void PlayCloseDoor()
    {
        closeDoor.Play();
    }
    public void PlayOpenDoor()
    {
        openDoor.Play();
    }
    public void TouchUI()
    {
        audioTouchUI.Play();
    }
}
public class objDDT : SingletonMonoBehaviour<OBJ_DontDesTroy> { }