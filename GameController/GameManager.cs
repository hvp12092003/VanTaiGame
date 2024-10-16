using UnityEngine;
using DG.Tweening;
using UnityEngine.SceneManagement;
using TMPro;
using HVPUnityBase.Base.DesignPattern;
public class GameManager : MonoBehaviour
{
    private GameObject gateL;
    private GameObject gateR;
    private GameObject obj;

    [HeaderAttribute("Properties")]
    public float time = 0;
    private float timeBackMenu = 300;
    static public float countAction = -1;
    static public bool done = false;
    static public bool action = true;

    public bool lastMap;
    public float nextScene;
    // Start is called before the first frame update
    void Start()
    {
        GetObj();
        Intro();
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log(countAction);
        Debug.Log(action);
        ActionEndMap();
        BackMenuAuto();
    }
    public void GetObj()
    {
        obj = GameObject.FindGameObjectWithTag("obj");
        gateL = GameObject.FindGameObjectWithTag("gateL");// panelcam1
        gateR = GameObject.FindGameObjectWithTag("gateR");// panelcam1
    }
    public void Intro()
    {
        if (objDDT.Instance != null) objDDT.Instance.PlayOpenDoor();
        else countAction = 0;

        if (gateL != null && gateR != null)
        {
            gateL.transform.DOMoveX(-15, 1f);
            gateR.transform.DOMoveX(15, 1f).OnComplete(() =>
            {
                countAction = 0;
            });
        }
    }
    public void BackMenuAuto()
    {
        time += Time.deltaTime;
        if (Input.GetMouseButtonDown(0))
        {
            time = 0;
        }
        else if (time >= timeBackMenu)
        {
            BackMenu();
            time = 0;
        }
    }
    public void BackMenu()
    {
        action = true;
        countAction = 0;
        done = false;
        OBJ_DontDesTroy.doneGame = false;
        objDDT.Instance.playVideo = false;
        objDDT.Instance.PlayCloseDoor();
        gateL.transform.DOMoveX(-4.44f, 1f).SetEase(Ease.OutBounce);
        gateR.transform.DOMoveX(4.44f, 1f).SetEase(Ease.OutBounce).OnComplete(() =>
        {
            SceneManager.LoadScene(1);
        });
    }
    public void ActionEndMap()
    {
        if (done)
        {
            done = false;
            obj.transform.DOMoveX(20f, 3f).SetEase(Ease.Linear).OnComplete(() =>
            {
                countAction = 0;
                objDDT.Instance.PlayCloseDoor();
                gateL.transform.DOMoveX(-4.44f, 1f).SetEase(Ease.OutBounce);
                gateR.transform.DOMoveX(4.44f, 1f).SetEase(Ease.OutBounce).OnComplete(() =>
                {
                    if (lastMap)
                    {
                        // OBJ_DontDesTroy.doneGame = true;
                        SceneManager.LoadScene(2);
                    }
                    else
                    {
                        switch (nextScene)
                        {
                            case 3:
                                SceneManager.LoadScene(4);
                                break;
                            case 4:
                                SceneManager.LoadScene(5);
                                break;

                            case 6:
                                SceneManager.LoadScene(7);
                                break;
                            case 7:
                                SceneManager.LoadScene(8);
                                break;
                            case 8:
                                SceneManager.LoadScene(9);
                                break;

                            case 10:
                                SceneManager.LoadScene(11);
                                break;
                            case 11:
                                SceneManager.LoadScene(12);
                                break;
                            case 12:
                                SceneManager.LoadScene(13);
                                break;
                            case 13:
                                SceneManager.LoadScene(14);
                                break;
                        }
                    }
                });
            });
        }
    }
}
public class GMNG : SingletonMonoBehaviour<GameManager> { }