using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class OBJ_MapHorseWagon_4 : OBJBase
{

    private GameObject soldier;
    private GameObject goods1;
    private GameObject goods2;
    private GameObject goods3;


    public AudioSource horse;
    public AudioSource tnt;
    public AudioSource pushDown;
    public AudioSource moveStone;
    public AudioSource grass;

    private Animator animatorHorse;

    private bool action1 = true;
    private bool action2 = true;
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
        obj1 = GameObject.FindGameObjectWithTag("obj1");//grass
        obj2 = GameObject.FindGameObjectWithTag("obj2");//small stone
        obj3 = GameObject.FindGameObjectWithTag("obj3");//TNT
        obj4 = GameObject.FindGameObjectWithTag("obj4");//swich TNT
        obj5 = GameObject.FindGameObjectWithTag("obj5");//Big Stone
        wheel1 = GameObject.FindGameObjectWithTag("Wheel1");
        wheel2 = GameObject.FindGameObjectWithTag("Wheel2");

        soldier = GameObject.FindGameObjectWithTag("Player");
        goods1 = GameObject.FindGameObjectWithTag("goods1");
        goods2 = GameObject.FindGameObjectWithTag("goods2");
        goods3 = GameObject.FindGameObjectWithTag("goods3");
        obj8 = GameObject.FindGameObjectWithTag("obj8");// Horse

        animatorHorse = obj8.GetComponent<Animator>();
        animator = obj5.GetComponent<Animator>();
        animator2 = soldier.GetComponent<Animator>();
    }
    public void Intro()
    {
        animatorHorse.SetFloat("Status", 1);
        animator2.SetFloat("Status", 1);
        var Tween1 = wheel1.transform.DORotate(new Vector3(0, 0, -360), 1, RotateMode.FastBeyond360).SetLoops(-1, LoopType.Restart).SetEase(Ease.Linear);
        var Tween2 = wheel2.transform.DORotate(new Vector3(0, 0, -360), 1, RotateMode.FastBeyond360).SetLoops(-1, LoopType.Restart).SetEase(Ease.Linear);
        obj.transform.DOMoveX(-2f, 3).SetEase(Ease.Linear).OnComplete(() =>
        {
            textBox.SetActive(true);
            animatorHorse.SetFloat("Status", 0);
            animator2.SetFloat("Status", 0);
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
    public void OnTouchGoods3()
    {
        OnTouchBike(goods3.transform);
    }
    public void OnTouchHorse()
    {
        horse.Play();
        animatorHorse.Play("Pedal");
    }
    public void TouchGrass()
    {
        if (GameManager.countAction == 0 && GameManager.action && action1 || GameManager.countAction == 1 && GameManager.action && action1)
        {
            if (GameManager.countAction == 1) MoveRaoundLight(obj3.transform.position);
            else MoveRaoundLight(obj2.transform.position);
            action1 = false;
            grass.Play();
            GameManager.action = false;
            obj1.transform.DOMove(new Vector3(4, -1), 0.5f).OnComplete(() =>
            {
                obj1.transform.DOMove(new Vector3(14, 4), 0.5f).OnComplete(() =>
                {
                    GameManager.action = true;
                    GameManager.countAction++;
                });
            });
        }
        else
        {
            OnTouchBike(obj1.transform);
        }
    }
    public void TouchSmallStone()
    {
        if (GameManager.countAction == 0 && GameManager.action && action2 || GameManager.countAction == 1 && GameManager.action && action2)
        {
            MoveRaoundLight(obj1.transform.position);
            if (GameManager.countAction==1) MoveRaoundLight(obj3.transform.position);
            action2 = false;
            moveStone.Play();
            GameManager.action = false;
            obj2.transform.DOMoveX(15, 0.5f).OnComplete(() =>
            {
                GameManager.action = true;
                GameManager.countAction++;
            });
        }
        else
        {
            OnTouchBike(obj2.transform);
        }
    }
    public void TouchTNT()
    {
        if (GameManager.countAction == 2 && GameManager.action)
        {
            MoveRaoundLight(obj4.transform.position);
            GameManager.action = false;
            obj3.transform.DOMove(new Vector3(7.5f, -2.71f), 0.5f).OnComplete(() =>
            {
                pushDown.Play();
                obj4.transform.DOMoveY(-3.5f, 1f).SetEase(Ease.OutBounce).OnComplete(() =>
                {
                    MoveRaoundLight(obj4.transform.position);
                    pushDown.Play();
                    GameManager.action = true;
                    GameManager.countAction++;
                });
            });
        }
        else
        {
            OnTouchBike(obj3.transform);
        }
    }
    private bool temp = true;
    public void TouchSwichTNT()
    {
        if (GameManager.countAction >= 3 && GameManager.action && temp)
        {
            temp = false;
            tnt.Play();

            var Tween1 = wheel1.transform.DORotate(new Vector3(0, 0, -360), 1, RotateMode.FastBeyond360).SetLoops(-1, LoopType.Restart).SetEase(Ease.Linear);
            var Tween2 = wheel2.transform.DORotate(new Vector3(0, 0, -360), 1, RotateMode.FastBeyond360).SetLoops(-1, LoopType.Restart).SetEase(Ease.Linear);

            animatorHorse.SetFloat("Status", 1);
            animator2.SetFloat("Status", 1);
            animator.Play("Explosion");
            GameManager.countAction++;
            GameManager.done = true;
            textBox.SetActive(false);
        }
        else { OnTouchBike(obj4.transform); }
    }
}
