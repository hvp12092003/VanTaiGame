using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class OBJ_MapBoat_3 : OBJBase
{
    private GameObject soldier;
    private GameObject goods1;

    public AudioSource cutTree;
    public AudioSource brushMove;
    public AudioSource brushDown;

    private bool actionBrush1 = true;
    private bool actionBrush2 = true;
    // Start is called before the first frame update
    void Start()
    {
        GetObj();
        Intro();
    }
    public void Intro()
    {
        obj.transform.DOMoveY(0.3f, 1f).SetEase(Ease.Linear).SetLoops(-1, LoopType.Yoyo);
        obj.transform.DOMoveX(-3.3f, 3).OnComplete(()=> { textBox.SetActive(true); });
    }
    public override void GetObj()
    {
        base.GetObj();
        obj4 = GameObject.FindGameObjectWithTag("obj4");// axe
        obj2 = GameObject.FindGameObjectWithTag("obj2");// bui1
        obj3 = GameObject.FindGameObjectWithTag("obj3");// bui2
        soldier = GameObject.FindGameObjectWithTag("Player");
        goods1 = GameObject.FindGameObjectWithTag("goods1");
        obj = GameObject.FindGameObjectWithTag("obj");// 
    }
    public void OnTouchSoldier()
    {
        OnTouchBike(soldier.transform);
    }
    public void OnTouchGoods1()
    {
        OnTouchBike(goods1.transform);
    }
    public void OnTouchAxe()
    {

        if (GameManager.countAction == 0 && GameManager.action)
        {
            MoveRaoundLight(Vector3.zero);
            GameManager.action = false;
            obj4.transform.DORotate(new Vector3(0, 0, 200), 0.1f);
            obj4.transform.DOMove(new Vector3(7.32f, 1.5f, 0), 1f).OnComplete(() =>
            {
                obj4.transform.DORotate(new Vector3(0, 0, 130), 0.1f).SetEase(Ease.InOutSine).OnStepComplete(PlayAudioAxe).SetLoops(6, LoopType.Yoyo).OnComplete(() =>
                {
                    brushDown.Play();
                    obj2.transform.DOMoveY(-0.89f, 0.5f);
                    obj4.transform.DOMove(new Vector3(2.45f, 1.96f), 1f).OnComplete(() =>
                    {
                        obj4.transform.DORotate(new Vector3(0, 0, 130), 0.1f).SetEase(Ease.InOutSine).OnStepComplete(PlayAudioAxe).SetLoops(6, LoopType.Yoyo).OnComplete(() =>
                        {
                            obj4.transform.DORotate(new Vector3(0, 0, 130), 0.1f).OnComplete(() =>
                            {
                                brushDown.Play();
                                obj4.transform.DOMoveY(-7f, 0.5f);
                                obj3.transform.DOMoveY(-0.89f, 0.5f).OnComplete(() =>
                                {
                                    MoveRaoundLight(obj2.transform.position);
                                    GameManager.countAction++;
                                    GameManager.action = true;
                                });
                            });

                        });
                    });
                });
            });
        }
        else
        {
            OnTouchBike(obj4.transform); ;
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
        if (GameManager.countAction == 1 && GameManager.action && actionBrush1 || GameManager.countAction == 2 && GameManager.action && actionBrush1)
        {
            MoveRaoundLight(obj3.transform.position);
            actionBrush1 = false;
            GameManager.action = false;
            brushDown.Play();
            GameManager.action = false;
            obj2.transform.DOScale(new Vector3(1.81f, 1, 1), 0.5f);
            obj2.transform.DOMove(new Vector3(-5f, -1.02f, 0), 0.5f).OnComplete(() =>
            {
                obj2.transform.DORotate(new Vector3(0, 0, -45), 0.5f).OnComplete(() =>
                {
                    obj2.transform.SetParent(obj.transform);

                    GameManager.countAction++;
                    GameManager.action = true;
                    if (GameManager.countAction == 3)
                    {
                        GameManager.done = true;
                        textBox.SetActive(false);
                    }
                });
            });
        }
        else
        {
            if (!actionBrush1)
                OnTouchBike(obj2.transform);
            else { touchUI.Play(); }
        }

    }
    public void OnTouchBush_2()
    {

        if (GameManager.countAction == 2 && GameManager.action && actionBrush2 || GameManager.countAction == 1 && GameManager.action && actionBrush2)
        {
            MoveRaoundLight(obj2.transform.position);
            actionBrush2 = false;
            GameManager.action = false;
            brushDown.Play();
            obj3.transform.DOScale(new Vector3(1.81f, 1, 1), 0.5f);
            obj3.transform.DOMove(new Vector3(-9.2f, -2.02f, 0), 0.5f).OnComplete(() =>
            {
                obj3.transform.DORotate(new Vector3(0, 0, 45), 0.5f).OnComplete(() =>
                {
                    obj3.transform.SetParent(obj.transform);
                    GameManager.countAction++;
                    GameManager.action = true;

                    if (GameManager.countAction == 3)
                    {
                        textBox.SetActive(false);
                        GameManager.done = true;
                    }


                    if (objDDT.Instance != null)
                    {
                        objDDT.Instance.kindOfVehicelVideo = OBJ_DontDesTroy.Vehicle.Boat;
                        objDDT.Instance.playVideo = true;
                    }
                });
            });
        }
        else
        {
            if (!actionBrush2)
                OnTouchBike(obj3.transform);
            else { touchUI.Play(); }
        }
    }
}
