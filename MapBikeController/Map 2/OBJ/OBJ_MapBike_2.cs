using DG.Tweening;
using UnityEngine;

public class OBJ_MapBike_2 : OBJBase
{

    private Animator soldier;

    private GameObject goods1;
    private GameObject goods2;


    private bool actionStone1 = true;
    private bool actionStone2 = true;

    public AudioSource MoveGrass;
    public AudioSource AxeStone;
    public AudioSource DropStone;
    public AudioSource MoveStone;

    // Start is called before the first frame update
    void Start()
    {
        GetObj();
        Intro();
    }
    public override void GetObj()
    {
        base.GetObj();
        obj = GameObject.FindGameObjectWithTag("obj");
        obj3 = GameObject.FindGameObjectWithTag("obj3");
        obj4 = GameObject.FindGameObjectWithTag("obj4");
        obj5 = GameObject.FindGameObjectWithTag("obj5");
        obj6 = GameObject.FindGameObjectWithTag("obj6");
        wheel1 = GameObject.FindGameObjectWithTag("Wheel1");
        wheel2 = GameObject.FindGameObjectWithTag("Wheel2");
        obj7 = GameObject.FindGameObjectWithTag("Player");
        goods1 = GameObject.FindGameObjectWithTag("goods1");
        goods2 = GameObject.FindGameObjectWithTag("goods2");
        soldier = obj7.GetComponent<Animator>();
    }
    public void Intro()
    {
        soldier.SetFloat("Status", 3);
        var Tween1 = wheel1.transform.DORotate(new Vector3(0, 0, -360), 1, RotateMode.FastBeyond360).SetLoops(-1, LoopType.Restart).SetEase(Ease.Linear);
        var Tween2 = wheel2.transform.DORotate(new Vector3(0, 0, -360), 1, RotateMode.FastBeyond360).SetLoops(-1, LoopType.Restart).SetEase(Ease.Linear);
        obj.transform.DOMoveX(-1.5f, 3).SetEase(Ease.Linear).OnComplete(() =>
        {
            textBox.SetActive(true);
            soldier.SetFloat("Status", 4);
            Tween1.Kill();
            Tween2.Kill();
        });
    }
    public void OnTouchSoldier()
    {
        OnTouchBike(soldier.transform);
    }
    public void OnTouchGoods1()
    {
        OnTouchBike(goods1.transform);
    }
    public void OnTouchGoods2()
    {
        OnTouchBike(goods2.transform);
    }
    public void OnTouchGrass_BikeMap2()
    {

        if (GameManager.countAction == 0 && GameManager.action)
        {
            MoveRaoundLight(obj4.transform.position);
            MoveGrass.Play();
            GameManager.action = false;
            obj3.transform.DOMove(new Vector3(15, 1), 0.5f).OnComplete(() =>
            {
                GameManager.countAction++;
                GameManager.action = true;
            });
        }
        else
        {
            OnTouchBike(obj3.transform);
        }
    }
    public void OnTouchAxe_BikeMap2()
    {

        if (GameManager.countAction == 1 && GameManager.action)
        {
            GameManager.action = false;
            obj4.transform.DORotate(new Vector3(0, 0, 10), 0.1f);
            obj4.transform.DOMove(new Vector3(-3.5f, -1f, 0), 1f).OnComplete(() =>
            {
                obj4.transform.DORotate(new Vector3(0, 0, 100), 0.1f).OnStepComplete(OnTweenStepComplete).SetLoops(6, LoopType.Yoyo).OnComplete(() =>
                {
                    DropStone.Play();
                    obj5.transform.DOMoveY(-3.5f, 0.5f);
                                MoveRaoundLight(obj5.transform.position);
                    obj4.transform.DOMove(new Vector3(-8.06f, -1.72f, 0), 0.2f).OnComplete(() =>
                    {
                        obj4.transform.DORotate(new Vector3(0, 0, 100), 0.1f).OnStepComplete(OnTweenStepComplete).SetEase(Ease.InOutSine).SetLoops(6, LoopType.Yoyo).OnComplete(() =>
                        {
                            DropStone.Play();
                            obj6.transform.DOMoveY(-3.5f, 0.5f).OnComplete(() =>
                            {
                                GameManager.countAction++; GameManager.action = true;
                            });
                        });
                    });
                });

            });
        }
        else
        {
            OnTouchBike(obj4.transform);
        }
    }
    int x = 2;
    public void OnTweenStepComplete()
    {
        if (x % 2 == 0)
        {
            AxeStone.Play();
        }
        x++;
    }

    public void OnTouchSmallStone_BikeMap2_1()
    {

        if (GameManager.countAction == 3 && GameManager.action && actionStone1 || GameManager.countAction == 2 && GameManager.action && actionStone1)
        {
            MoveRaoundLight(obj6.transform.position);
            GameManager.action = false;
            obj5.transform.DOMove(new Vector3(3.12f, -2.23f, 0), 0.5f).OnComplete(() =>
            {
                MoveStone.Play();
                obj5.transform.DOMoveY(-5f, 0.2f).OnComplete(() =>
                {
                    actionStone1 = false;
                    GameManager.action = true;
                    GameManager.countAction++;
                    if (GameManager.countAction == 4)
                    {
                        soldier.SetFloat("Status", 3);
                        wheel1.transform.DORotate(new Vector3(0, 0, -360), 1, RotateMode.FastBeyond360).SetLoops(-1, LoopType.Restart).SetEase(Ease.Linear);
                        wheel2.transform.DORotate(new Vector3(0, 0, -360), 1, RotateMode.FastBeyond360).SetLoops(-1, LoopType.Restart).SetEase(Ease.Linear);
                        GameManager.done = true; textBox.SetActive(false);
                    }
                });
            });
        }
        else
        {
            if (!actionStone1)
                OnTouchBike(obj5.transform);
            else touchUI.Play();
        }
    }

    public void OnTouchSmallStone_BikeMap2_2()
    {

        if (GameManager.countAction == 3 && GameManager.action && actionStone2 || GameManager.countAction == 2 && GameManager.action && actionStone2)
        {
            GameManager.action = false;
            obj6.transform.DOMove(new Vector3(4.9f, -2.23f, 0), 0.5f).OnComplete(() =>
            {
                MoveRaoundLight(obj5.transform.position);
                MoveStone.Play();
                obj6.transform.DOMoveY(-4.5f, 0.2f).OnComplete(() =>
                {
                    actionStone2 = false;
                    GameManager.action = true;
                    GameManager.countAction++;
                    if (GameManager.countAction == 4)
                    {
                        soldier.SetFloat("Status", 3);
                        wheel1.transform.DORotate(new Vector3(0, 0, -360), 1, RotateMode.FastBeyond360).SetLoops(-1, LoopType.Restart).SetEase(Ease.Linear);
                        wheel2.transform.DORotate(new Vector3(0, 0, -360), 1, RotateMode.FastBeyond360).SetLoops(-1, LoopType.Restart).SetEase(Ease.Linear);
                        GameManager.done = true; textBox.SetActive(false);
                    }
                });
            });
        }
        else
        {
            if (!actionStone2)
                OnTouchBike(obj6.transform);
            else touchUI.Play();
        }
    }
}
