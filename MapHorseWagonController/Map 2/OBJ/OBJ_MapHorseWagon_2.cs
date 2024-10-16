using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class OBJ_MapHorseWagon_2 : OBJBase
{
    private GameObject wheel1;//
    private GameObject wheel2;//

    private GameObject soldier;
    private GameObject goods1;
    private GameObject goods2;
    private GameObject goods3;

    public AudioSource grass;
    public AudioSource tnt;
    public AudioSource stone;
    public AudioSource horse;

    private Animator animatorHorse;
    private Animator animatorObj5;
    private Animator animatorObj6;

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
        obj1 = GameObject.FindGameObjectWithTag("obj1");//grass1
        obj2 = GameObject.FindGameObjectWithTag("obj2");//grass2
        obj3 = GameObject.FindGameObjectWithTag("obj3");//stone1
        obj4 = GameObject.FindGameObjectWithTag("obj4");//stone2
        obj5 = GameObject.FindGameObjectWithTag("obj5");//landmine1
        obj6 = GameObject.FindGameObjectWithTag("obj6");//landmine2
        wheel1 = GameObject.FindGameObjectWithTag("Wheel1");
        wheel2 = GameObject.FindGameObjectWithTag("Wheel2");

        soldier = GameObject.FindGameObjectWithTag("Player");
        goods1 = GameObject.FindGameObjectWithTag("goods1");
        goods2 = GameObject.FindGameObjectWithTag("goods2");
        goods3 = GameObject.FindGameObjectWithTag("goods3");
        obj7 = GameObject.FindGameObjectWithTag("obj7");// Horse
        obj8 = GameObject.FindGameObjectWithTag("obj8");// Player

        animatorObj5 = obj5.GetComponent<Animator>();
        animatorObj6 = obj6.GetComponent<Animator>();

        animatorHorse = obj7.GetComponent<Animator>();
        animator2 = obj8.GetComponent<Animator>();
    }
    public void Intro()
    {
        animatorHorse.SetFloat("Status", 1);
        animator2.SetFloat("Status", 1);
        var Tween1 = wheel1.transform.DORotate(new Vector3(0, 0, -360), 1, RotateMode.FastBeyond360).SetLoops(-1, LoopType.Restart).SetEase(Ease.Linear);
        var Tween2 = wheel2.transform.DORotate(new Vector3(0, 0, -360), 1, RotateMode.FastBeyond360).SetLoops(-1, LoopType.Restart).SetEase(Ease.Linear);
        obj.transform.DOMoveX(1f, 3).SetEase(Ease.Linear).OnComplete(() =>
        {
            textBox.SetActive(true);
            animator2.SetFloat("Status", 0);
            animatorHorse.SetFloat("Status", 0);
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
    public void TouchGlass_1()
    {
        if (GameManager.countAction == 0 && GameManager.action || GameManager.countAction == 1 && GameManager.action)
        {
            if (GameManager.countAction == 0) MoveRaoundLight(obj2.transform.position);
            else MoveRaoundLight(obj3.transform.position);
            grass.Play();
            GameManager.action = false;
            obj1.transform.DOMove(new Vector3(13, 0, 0), 0.5f).OnComplete(() =>
            {
                GameManager.action = true;
                GameManager.countAction++;
            });
        }
        else
        {
            touchUI.Play();
        }
    }
    public void TouchGlass_2()
    {
        if (GameManager.countAction == 0 && GameManager.action || GameManager.countAction == 1 && GameManager.action)
        {
            if (GameManager.countAction == 0) MoveRaoundLight(obj1.transform.position);
            else MoveRaoundLight(obj3.transform.position);
            grass.Play();
            GameManager.action = false;
            obj2.transform.DOMove(new Vector3(13, 0, 0), 0.5f).OnComplete(() =>
            {
                GameManager.action = true;
                GameManager.countAction++;
            });
        }
        else
        {
            touchUI.Play();
        }
    }
    public void TouchSmallStone_1()
    {
        if (GameManager.countAction == 2 && GameManager.action || GameManager.countAction == 3 && GameManager.action)
        {
            if (GameManager.countAction == 2) MoveRaoundLight(obj4.transform.position);
            else SetTime();
            GameManager.action = false;
            obj3.transform.DOMove(new Vector3(8.26f, 0, 0), 0.5f).OnComplete(() =>
            {
                stone.Play();
                obj3.transform.DOMoveY(-3.5f, 0.5f).OnComplete(() =>
            {
                obj3.gameObject.SetActive(false);
                tnt.Play();
                animatorObj6.Play("Explosion");
                GameManager.countAction++;
                GameManager.action = true;
                if (GameManager.countAction == 4)
                {
                    animatorHorse.SetFloat("Status", 1);
                    animator2.SetFloat("Status", 1);
                    var Tween1 = wheel1.transform.DORotate(new Vector3(0, 0, -360), 1, RotateMode.FastBeyond360).SetLoops(-1, LoopType.Restart).SetEase(Ease.Linear);
                    var Tween2 = wheel2.transform.DORotate(new Vector3(0, 0, -360), 1, RotateMode.FastBeyond360).SetLoops(-1, LoopType.Restart).SetEase(Ease.Linear);
                    GameManager.done = true; textBox.SetActive(false);
                }
            });
            });
        }
        else
        {
            OnTouchBike(obj3.transform);
        }
    }
    public void TouchSmallStone_2()
    {
        if (GameManager.countAction == 2 && GameManager.action || GameManager.countAction == 3 && GameManager.action)
        {
            MoveRaoundLight(obj3.transform.position);
            GameManager.action = false;
            obj4.transform.DOMove(new Vector3(5.96f, 0, 0), 0.5f).OnComplete(() =>
            {
                stone.Play();
                obj4.transform.DOMoveY(-3.5f, 0.5f).OnComplete(() =>
                {
                    obj4.gameObject.SetActive(false);
                    tnt.Play();
                    animatorObj5.Play("Explosion");
                    GameManager.action = true;
                    GameManager.countAction++;
                    if (GameManager.countAction == 4)
                    {
                        animatorHorse.SetFloat("Status", 1);
                        animator2.SetFloat("Status", 1);
                        var Tween1 = wheel1.transform.DORotate(new Vector3(0, 0, -360), 1, RotateMode.FastBeyond360).SetLoops(-1, LoopType.Restart).SetEase(Ease.Linear);
                        var Tween2 = wheel2.transform.DORotate(new Vector3(0, 0, -360), 1, RotateMode.FastBeyond360).SetLoops(-1, LoopType.Restart).SetEase(Ease.Linear);
                        GameManager.done = true; textBox.SetActive(false);
                    }
                });
            });
        }
        else
        {
            OnTouchBike(obj4.transform);
        }
    }
}
