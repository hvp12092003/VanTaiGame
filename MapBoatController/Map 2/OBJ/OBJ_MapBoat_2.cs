using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using System;

public class OBJ_MapBoat_2 : OBJBase
{
    private GameObject soldier;
    private GameObject goods1;

    public AudioSource audio2;//TNT
    public AudioSource audio3;//push down
    public AudioSource audio4;//grass
    public AudioSource audio5;//move stone

    private Animator animator;
    // Start is called before the first frame update
    void Start()
    {
        GetObj();
        Intro();
    }

    private void Intro()
    {
        obj.transform.DOMoveY(0.3f, 1f).SetEase(Ease.Linear).SetLoops(-1, LoopType.Yoyo);
        obj.transform.DOMoveX(-3f, 3).OnComplete(() => { textBox.SetActive(true); });
    }

    public override void GetObj()
    {
        base.GetObj();
        obj1 = GameObject.FindGameObjectWithTag("obj1");// Grass
        obj2 = GameObject.FindGameObjectWithTag("obj2");// SmallStone
        obj3 = GameObject.FindGameObjectWithTag("obj3");// TNT
        obj4 = GameObject.FindGameObjectWithTag("obj4");// SwichTNT
        obj5 = GameObject.FindGameObjectWithTag("obj5");// Bigstone
        soldier = GameObject.FindGameObjectWithTag("Player");
        goods1 = GameObject.FindGameObjectWithTag("goods1");
        obj = GameObject.FindGameObjectWithTag("obj");// 
        animator = obj5.GetComponent<Animator>();
    }
    public void OnTouchSoldier()
    {
        OnTouchBike(soldier.transform);
    }
    public void OnTouchGoods1()
    {
        OnTouchBike(goods1.transform);
    }
    private bool action = true;
    public void OnTouchGlass()
    {
        if (GameManager.countAction == 0 && GameManager.action || GameManager.countAction == 1 && GameManager.action)
        {
            MoveRaoundLight(obj2.transform.position);
            audio4.Play();

            GameManager.action = false;

            obj1.transform.DOMoveY(0, 1f).OnComplete(() =>
            {
                obj1.transform.DOMove(new Vector3(15f, 5f, 0), 0.5f).OnComplete(() =>
                {
                    if (GameManager.countAction <= 2) GameManager.countAction++;
                    GameManager.action = true;
                });
            });
        }
        else
        {
            OnTouchBike(obj1.transform);
        }
    }
    public void OnTouchStone()
    {
        if (GameManager.countAction == 0 && GameManager.action && action || GameManager.countAction == 1 && GameManager.action && action)
        {
            MoveRaoundLight(obj3.transform.position);
            action = false;
            audio5.Play();

            GameManager.action = false;

            obj2.transform.DOMove(new Vector3(6.21f, -5.4f, 0), 0.5f).OnComplete(() =>
            {
                audio3.Play();
                if (GameManager.countAction <= 2) GameManager.countAction++;
                GameManager.action = true;
            });
        }
        else
        {
            touchUI.Play();
        }
    }
    public void OnTouchTNT()
    {
        if (GameManager.countAction == 2 && GameManager.action)
        {
            MoveRaoundLight(Vector3.zero);
            GameManager.action = false;
            obj3.transform.DOScale(new Vector3(2.5f, 2.5f, 2.5f), 0.5f);
            obj3.transform.DOMove(new Vector3(7.7f, -2f, 0), 1f).OnComplete(() =>
            {
                obj4.transform.DOMoveY(-1.2f, 0.5f).SetEase(Ease.OutBounce).OnComplete(() =>
                {
                    MoveRaoundLight(obj4.transform.position);
                    audio3.Play();
                });
                GameManager.countAction++;
                GameManager.action = true;
            });
        }
        else
        {
            Debug.Log(1);
            OnTouchBike(obj3.transform);
        }
    }
    private bool temp = true;
    public void OnTouchSwichTNT()
    {
        if (temp)
        {
            MoveRaoundLight(Vector3.zero);
            temp = false;
            obj4.transform.DOShakePosition(0.5f, 0.5f);

            audio2.Play();
            animator.Play("Explosion");
            GameManager.countAction = 0;
            GameManager.action = true;
            GameManager.done = true; textBox.SetActive(false);
        }
        else
        {
            OnTouchBike(obj4.transform);
        }
    }
}
