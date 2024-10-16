using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OBJ_MapBike_4 : OBJBase
{
    private Animator soldier;
    private GameObject goods1;
    private GameObject goods2;

    private Animator animatorBigStone;

    public AudioSource moveGrass;
    public AudioSource moveStone;
    public AudioSource putDown;

    private bool actionGrass = true;
    private bool actionStone = true;

    void Start()
    {
        GetObj();
        Intro();
    }
    public override void GetObj()
    {
        base.GetObj();
        obj = GameObject.FindGameObjectWithTag("obj");
        obj1 = GameObject.FindGameObjectWithTag("obj1");// grass
        obj2 = GameObject.FindGameObjectWithTag("obj2");// stone
        obj3 = GameObject.FindGameObjectWithTag("obj3");// tnt
        obj4 = GameObject.FindGameObjectWithTag("obj4");// swich tnt
        obj5 = GameObject.FindGameObjectWithTag("obj5");// BigStone
        obj6 = GameObject.FindGameObjectWithTag("Player");// Soldier
        wheel1 = GameObject.FindGameObjectWithTag("Wheel1");
        wheel2 = GameObject.FindGameObjectWithTag("Wheel2");
        goods1 = GameObject.FindGameObjectWithTag("goods1");
        goods2 = GameObject.FindGameObjectWithTag("goods2");


        soldier = obj6.GetComponent<Animator>();
        animatorBigStone = obj5.GetComponent<Animator>();
    }
    public void Intro()
    {
        soldier.SetFloat("Status", 3);
        var Tween1 = wheel1.transform.DORotate(new Vector3(0, 0, -360), 1, RotateMode.FastBeyond360).SetLoops(-1, LoopType.Restart).SetEase(Ease.Linear);
        var Tween2 = wheel2.transform.DORotate(new Vector3(0, 0, -360), 1, RotateMode.FastBeyond360).SetLoops(-1, LoopType.Restart).SetEase(Ease.Linear);
        obj.transform.DOMoveX(-7f, 3).SetEase(Ease.Linear).OnComplete(() =>
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
    public void OnTouchGlass()
    {
        if (GameManager.countAction == 0 && GameManager.action && actionGrass || GameManager.countAction == 1 && GameManager.action && actionGrass)
        {
            if (GameManager.countAction == 0) MoveRaoundLight(obj2.transform.position);
            else MoveRaoundLight(obj3.transform.position);
            moveGrass.Play();
            GameManager.action = false;
            obj1.transform.DOMove(new Vector3(6.23f, -1f, 0), 1f).OnComplete(() =>
            {
                obj1.transform.DOMove(new Vector3(15f, 5f, 0), 0.5f).OnComplete(() =>
                {
                    actionGrass = false;
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
    public void OnTouchSmallStone_3()
    {

        if (GameManager.countAction == 0 && GameManager.action && actionStone || GameManager.countAction == 1 && GameManager.action && actionStone)
        {
           if(GameManager.countAction==0) MoveRaoundLight(obj1.transform.position);
            else MoveRaoundLight(obj3.transform.position);
            moveStone.Play();
            GameManager.action = false;
            obj2.transform.DOMoveY(-3.66f, 0.5f).OnComplete(() =>
            {
                actionStone = false;
                GameManager.action = true;
                GameManager.countAction++;
            });
        }
        else
        {
            OnTouchBike(obj2.transform);
        }
    }
    public void OnTouchTNT()
    {

        if (GameManager.countAction == 2 && GameManager.action)
        {
            MoveRaoundLight(Vector3.zero);
            GameManager.action = false;
            obj3.transform.DOMove(new Vector3(8f, -1.28f, 0), 0.5f).OnComplete(() =>
            {
                obj4.transform.DOMoveY(-3f, 0.7f).SetEase(Ease.OutBounce).OnComplete(() =>
                {
                    MoveRaoundLight(obj4.transform.position);
                    putDown.Play();
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
    public void OnTouchSwichTNT()
    {

        if (GameManager.countAction == 3 && GameManager.action && temp)
        {
            MoveRaoundLight(Vector3.zero);
            textBox.SetActive(false);
            temp = false;

            obj3.SetActive(false);
            animatorBigStone.Play("Explosion_BigStone");
            soldier.SetFloat("Status", 3);
            wheel1.transform.DORotate(new Vector3(0, 0, -360), 1, RotateMode.FastBeyond360).SetLoops(-1, LoopType.Restart).SetEase(Ease.Linear);
            wheel2.transform.DORotate(new Vector3(0, 0, -360), 1, RotateMode.FastBeyond360).SetLoops(-1, LoopType.Restart).SetEase(Ease.Linear);

            GameManager.action = true;
            GameManager.countAction++;
            GameManager.done = true;

            objDDT.Instance.kindOfVehicelVideo = OBJ_DontDesTroy.Vehicle.Bike;
            objDDT.Instance.playVideo = true;
        }
        else
        {
            OnTouchBike(obj4.transform);
        }
    }
}
