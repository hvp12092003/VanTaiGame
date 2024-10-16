using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using System;
using Unity.VisualScripting;

public class OBJ_MapHorseWagon_5 : OBJBase
{
    private GameObject soldier;
    private GameObject goods1;
    private GameObject goods2;
    private GameObject goods3;

    public AudioSource brushDown;
    public AudioSource brushMove;
    public AudioSource cutTree;
    public AudioSource horse;

    private Animator animatorHorse;

    private bool action1 = true;
    private bool action2 = true;
    void Start()
    {
        GetObj();
        Intro();
    }

    private void Intro()
    {
        animatorHorse.SetFloat("Status", 1);
        animator2.SetFloat("Status", 1);
        var Tween1 = wheel1.transform.DORotate(new Vector3(0, 0, -360), 1, RotateMode.FastBeyond360).SetLoops(-1, LoopType.Restart).SetEase(Ease.Linear);
        var Tween2 = wheel2.transform.DORotate(new Vector3(0, 0, -360), 1, RotateMode.FastBeyond360).SetLoops(-1, LoopType.Restart).SetEase(Ease.Linear);
        obj.transform.DOMoveX(-2.5f, 3).SetEase(Ease.Linear).OnComplete(() =>
        {
            textBox.SetActive(true);
            animatorHorse.SetFloat("Status", 0);
            animator2.SetFloat("Status", 0);
            Tween1.Kill();
            Tween2.Kill();
        });
    }

    public override void GetObj()
    {
        base.GetObj();
        obj = GameObject.FindGameObjectWithTag("obj");
        obj2 = GameObject.FindGameObjectWithTag("obj2");
        obj3 = GameObject.FindGameObjectWithTag("obj3");
        obj4 = GameObject.FindGameObjectWithTag("obj4");
        wheel1 = GameObject.FindGameObjectWithTag("Wheel1");
        wheel2 = GameObject.FindGameObjectWithTag("Wheel2");
        soldier = GameObject.FindGameObjectWithTag("Player");
        goods1 = GameObject.FindGameObjectWithTag("goods1");
        goods2 = GameObject.FindGameObjectWithTag("goods2");
        goods3 = GameObject.FindGameObjectWithTag("goods3");
        obj8 = GameObject.FindGameObjectWithTag("obj8");// Horse

        animatorHorse = obj8.GetComponent<Animator>();
        animator2 = soldier.GetComponent<Animator>();
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
    public void TouchAxe2()
    {
        if (GameManager.countAction == 0 && GameManager.action)
        {
            MoveRaoundLight(Vector3.zero);
            touchUI.Play();
            GameManager.action = false;
            obj4.transform.DOMove(new Vector3(6.5f, 1f, 0), 0.5f).OnComplete(() =>
            {
                obj4.transform.DORotate(new Vector3(0, 0, 180), 0.1f).SetEase(Ease.Linear).OnStepComplete(PlayAudioAxe).SetLoops(6, LoopType.Yoyo).OnComplete(() =>
                {
                    brushDown.Play();
                    obj3.transform.DOMoveY(-2.85f, 0.2f);
                    obj4.transform.DOMove(new Vector3(7.5f, 3f, 0), 0.5f).OnComplete(() =>
                    {
                        obj4.transform.DORotate(new Vector3(0, 0, 180), 0.1f).SetEase(Ease.Linear).OnStepComplete(PlayAudioAxe).SetLoops(6, LoopType.Yoyo).OnComplete(() =>
                        {
                            MoveRaoundLight(obj3.transform.position);
                            brushDown.Play();
                            obj2.transform.DOMoveY(-2.85f, 0.2f);
                            obj4.transform.DOMoveY(-6f, 1f);
                            GameManager.countAction++;
                            GameManager.action = true;
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
    public void PlayAudioAxe()
    {
        if (x % 2 == 0)
        {
            cutTree.Play();
        }
        x++;
    }
    public void OnTouchBush_1()
    {
        if (GameManager.countAction == 1 && GameManager.action && action1 || GameManager.countAction == 2 && GameManager.action && action1)
        {
            MoveRaoundLight(obj3.transform.position);
            action1 = false;
            brushMove.Play();
            GameManager.action = false;
            obj2.transform.DOMove(new Vector3(-3.5f, -1f, 0), 0.5f).OnComplete(() =>
            {
                obj2.transform.DORotate(new Vector3(0, 0, -20), 0.5f).OnComplete(() =>
                {
                    obj2.transform.SetParent(obj.transform);
                    GameManager.countAction++;
                    GameManager.action = true;
                    if (GameManager.countAction == 3)
                    {
                        GameManager.done = true; textBox.SetActive(false);
                        var Tween1 = wheel1.transform.DORotate(new Vector3(0, 0, -360), 1, RotateMode.FastBeyond360).SetLoops(-1, LoopType.Restart).SetEase(Ease.Linear);
                        var Tween2 = wheel2.transform.DORotate(new Vector3(0, 0, -360), 1, RotateMode.FastBeyond360).SetLoops(-1, LoopType.Restart).SetEase(Ease.Linear);
                        animatorHorse.SetFloat("Status", 1);
                        animator2.SetFloat("Status", 1);
                    }
                });
            });
        }
        else
        {
            if (!action1) OnTouchBike(obj2.transform);
            else touchUI.Play();
        }
    }
    public void OnTouchBush_2()
    {
        if (GameManager.countAction == 1 && GameManager.action && action2 || GameManager.countAction == 2 && GameManager.action && action2)
        {
            MoveRaoundLight(obj2.transform.position);
            action2 = false;
            brushMove.Play();
            GameManager.action = false;
            obj3.transform.DOMove(new Vector3(-6.8f, -1f, 0), 0.5f).OnComplete(() =>
            {
                obj3.transform.DORotate(new Vector3(0, 0, 20), 0.5f).OnComplete(() =>
                {
                    obj3.transform.SetParent(obj.transform);
                    GameManager.countAction++;
                    GameManager.action = true;
                    if (GameManager.countAction == 3)
                    {
                        GameManager.done = true; textBox.SetActive(false);
                        var Tween1 = wheel1.transform.DORotate(new Vector3(0, 0, -360), 1, RotateMode.FastBeyond360).SetLoops(-1, LoopType.Restart).SetEase(Ease.Linear);
                        var Tween2 = wheel2.transform.DORotate(new Vector3(0, 0, -360), 1, RotateMode.FastBeyond360).SetLoops(-1, LoopType.Restart).SetEase(Ease.Linear);
                        animatorHorse.SetFloat("Status", 1);
                        animator2.SetFloat("Status", 1);
                    }

                    objDDT.Instance.kindOfVehicelVideo = OBJ_DontDesTroy.Vehicle.HorseWagon;
                    objDDT.Instance.playVideo = true;
                });
            });
        }
        else
        {
            if (!action2) OnTouchBike(obj3.transform);
            else touchUI.Play();
        }
    }
}
