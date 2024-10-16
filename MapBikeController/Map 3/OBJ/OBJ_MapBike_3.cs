using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OBJ_MapBike_3 : OBJBase
{
    private Animator soldier;
    private GameObject goods1;
    private GameObject goods2;

    public AudioSource cutTree;
    public AudioSource dropTree;
    public AudioSource turnOnFire;
    public AudioSource moveStone;
    public AudioSource putDown;
    public AudioSource tiger;
    public AudioSource touchFireStone;

    private Animator tigerAni;
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
        obj1 = GameObject.FindGameObjectWithTag("obj1");// stone
        obj2 = GameObject.FindGameObjectWithTag("obj2");// axe
        obj3 = GameObject.FindGameObjectWithTag("obj3");// canh cay
        obj4 = GameObject.FindGameObjectWithTag("obj4");// smallStone
        obj5 = GameObject.FindGameObjectWithTag("obj5");// StoneR
        obj6 = GameObject.FindGameObjectWithTag("obj6");// StoneL
        obj7 = GameObject.FindGameObjectWithTag("obj7");// fire
        obj8 = GameObject.FindGameObjectWithTag("obj8");// tiger
        obj9 = GameObject.FindGameObjectWithTag("Player");// soldier
        wheel1 = GameObject.FindGameObjectWithTag("Wheel1");
        wheel2 = GameObject.FindGameObjectWithTag("Wheel2");
        goods1 = GameObject.FindGameObjectWithTag("goods1");
        goods2 = GameObject.FindGameObjectWithTag("goods2");

        soldier = obj9.GetComponent<Animator>();
        tigerAni = obj8.transform.GetComponent<Animator>();

        obj7.gameObject.SetActive(false);
    }
    public void Intro()
    {
        soldier.SetFloat("Status", 3);
        var Tween1 = wheel1.transform.DORotate(new Vector3(0, 0, -360), 1, RotateMode.FastBeyond360).SetLoops(-1, LoopType.Restart).SetEase(Ease.Linear);
        var Tween2 = wheel2.transform.DORotate(new Vector3(0, 0, -360), 1, RotateMode.FastBeyond360).SetLoops(-1, LoopType.Restart).SetEase(Ease.Linear);
        obj.transform.DOMoveX(-4f, 3).SetEase(Ease.Linear).OnComplete(() =>
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
    public void OnTouchBigStone()
    {

        if (GameManager.countAction == 0 && GameManager.action)
        {
            MoveRaoundLight(obj2.transform.position);
            moveStone.Play();
            GameManager.action = false;
            obj1.transform.DOMoveX(-15, 0.5f).OnComplete(() =>
            {
                GameManager.countAction++; GameManager.action = true;
            });
        }
        else
        {
            OnTouchBike(obj1.transform);
        }
    }
    public void OnTouchAxe()
    {

        if (GameManager.countAction == 1 && GameManager.action)
        {
            MoveRaoundLight(new Vector3(obj3.transform.position.x, -3.5f));
            GameManager.action = false;
            obj2.transform.DORotate(new Vector3(0, 0, -180), 0.1f);
            obj2.transform.DOMove(new Vector3(8f, -0.83f, 0), 0.5f).OnComplete(() =>
            {
                obj2.transform.DORotate(new Vector3(0, 0, -235), 0.1f).SetEase(Ease.Linear).OnStepComplete(PlayAudioAxe).SetLoops(6, LoopType.Yoyo).OnComplete(() =>
                {
                    obj2.transform.DORotate(new Vector3(0, 0, -250), 0.2f);
                    obj2.transform.DOMoveY(-1.73f, 0.5f);
                    obj3.transform.DOMoveY(-3.5f, 0.2f).SetEase(Ease.InOutSine).OnComplete(() =>
                    {
                        dropTree.Play();
                    });
                    obj3.transform.DOLocalRotate(new Vector3(0, 0, -70), 0.2f).OnComplete(() =>
                {
                    GameManager.countAction++;
                    GameManager.action = true;
                });
                });
            });
        }
        else
        {
            OnTouchBike(obj2.transform);
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
    public void OnTouchBough()
    {
        if (GameManager.countAction == 2 && GameManager.action)
        {
            MoveRaoundLight(obj4.transform.position);
            GameManager.action = false;
            obj3.transform.DOMove(new Vector3(1.5f, -2, 0), 0.5f).OnComplete(() =>
            {
                obj3.transform.DOMoveY(-1.5f, 0.1f).OnComplete(() =>
                {
                    obj3.transform.DOMoveY(-2.7f, 0.2f).SetEase(Ease.InOutSine).OnComplete(() =>
                    {
                        putDown.Play();
                        GameManager.countAction++;
                        GameManager.action = true;
                    }); ;
                });
            });
            obj3.transform.DOLocalRotate(new Vector3(0, 0, -190), 0.5f);
        }
        else
        {
            touchUI.Play();
        }

    }
    public void OnTouchSmallStone()
    {
        if (GameManager.countAction == 3 && GameManager.action)
        {
            MoveRaoundLight(Vector3.zero);
            GameManager.action = false;
            obj4.transform.DOMove(new Vector3(2.1f, -1.5f, 0), 0.5f).OnComplete(() =>
            {
                obj5.transform.DOMoveX(2.68f, 0.2f).SetLoops(6, LoopType.Yoyo);
                obj6.transform.DOMoveX(0.93f, 0.2f).OnStepComplete(PlayAudioFireStone).SetLoops(6, LoopType.Yoyo).OnComplete(() =>
                {
                    turnOnFire.Play();
                    obj7.gameObject.SetActive(true);
                    obj4.transform.DOMoveY(-3.5f, 0.2f).OnComplete(() =>
                    {
                        obj5.transform.DOMoveX(obj5.transform.position.x + 1, 1.5f);
                        obj5.transform.DORotate(new Vector3(0, 0, -180), 1.5f);
                        obj6.transform.DOMoveX(obj5.transform.position.x - 1, 1.5f);
                        obj6.transform.DORotate(new Vector3(0, 0, 180), 1.5f);
                        tiger.Play();
                        obj8.transform.DORotate(new Vector3(0, 180), 0f).OnComplete(() =>
                        {
                            tigerAni.Play("Run");
                            obj8.transform.DOMoveX(12.82f, 1f).OnComplete(() =>
                            {
                                soldier.SetFloat("Status", 3);
                                wheel1.transform.DORotate(new Vector3(0, 0, -360), 1, RotateMode.FastBeyond360).SetLoops(-1, LoopType.Restart).SetEase(Ease.Linear);
                                wheel2.transform.DORotate(new Vector3(0, 0, -360), 1, RotateMode.FastBeyond360).SetLoops(-1, LoopType.Restart).SetEase(Ease.Linear);
                                GameManager.action = true;
                                GameManager.countAction++;
                                GameManager.done = true; textBox.SetActive(false);
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
    public void PlayAudioFireStone()
    {
        if (x % 2 == 0)
        {
            touchFireStone.Play();
        }
        x++;
    }
    public void OnTouchTiger()
    {
        tiger.Play();
    }
}
