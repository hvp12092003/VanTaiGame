using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class OBJ_MapBoat_1 : OBJBase
{
    public AudioSource audio2;//dropGoods
    public AudioSource audio3;//dropWater
    private Animator soldier;
    // Start is called before the first frame update
    void Start()
    {
        GetObj();
        textBox.SetActive(true);
        obj4.transform.DOMoveY(-0.3f, 1f).SetEase(Ease.Linear).SetLoops(-1, LoopType.Yoyo);
    }
    public override void GetObj()
    {
        base.GetObj();
        obj1 = GameObject.FindGameObjectWithTag("obj1");// boat
        obj2 = GameObject.FindGameObjectWithTag("obj2");// goods
        obj3 = GameObject.FindGameObjectWithTag("obj3");// a soldier
        obj4 = GameObject.FindGameObjectWithTag("obj4");// all
        obj5 = GameObject.FindGameObjectWithTag("Player");// a soldier
        obj = GameObject.FindGameObjectWithTag("obj");// obj main

        soldier = obj5.GetComponent<Animator>();
           }
    public void OnTouchBoat()
    {

        if (GameManager.countAction == 0 && GameManager.action)
        {
            MoveRaoundLight(obj2.transform.position);
            GameManager.action = false;
            obj1.transform.DOScale(new Vector3(-1, 1, 1), 0.5f);
            obj1.transform.DOMove(new Vector3(0f, -2.5f, 0), 0.5f).OnComplete(() =>
            {
                obj1.transform.DOMoveY(-3, 0.5f).OnComplete(() =>
                {
                    obj1.transform.SetParent(obj4.transform);

                    audio3.Play();
                    GameManager.countAction++;
                    GameManager.action = true;

                });
            });
        }
        else
        {
            touchUI.Play();
        }
    }
    public void OnTouchGoods()
    {

        if (GameManager.countAction == 1 && GameManager.action)
        {
            MoveRaoundLight(obj3.transform.position);
            GameManager.action = false;
            obj2.transform.DOScale(new Vector3(1.45f, 1.45f, 1.45f), 0.5f);
            obj2.transform.DOMove(new Vector3(-0.58f, 0f, 0), 0.5f).OnComplete(() =>
            {
                obj2.transform.DOMoveY(-1.8f, 0.5f).OnComplete(() =>
                {
                    obj2.transform.SetParent(obj4.transform);
                    obj4.transform.GetChild(1).SetSiblingIndex(0);

                    audio2.Play();
                    GameManager.countAction++;
                    GameManager.action = true;
                });
            });
        }
        else
        {
            OnTouchBike(obj2.transform);
        }
    }
    public void OnTouchPlayer()
    {

        if (GameManager.countAction == 2 && GameManager.action)
        {
            textBox.SetActive(false);
            MoveRaoundLight(Vector3.zero);
            GameManager.action = false;
            soldier.SetFloat("Status", 1);
            obj3.transform.DOScale(new Vector3(1.1f, 1.1f, 1.1f), 0.4f);
            obj3.transform.DOMoveX(1.47f, 2f).SetEase(Ease.Linear).OnComplete(() =>
            {
                obj3.transform.DOMoveY(-2.27f, 0.4f).OnComplete(() =>
                {
                    textBox.SetActive(false);
                    soldier.SetFloat("Status", 0);
                    obj3.transform.SetParent(obj4.transform);
                    obj4.transform.GetChild(2).SetSiblingIndex(0);
                    GameManager.countAction++;
                    GameManager.done = true;
                    GameManager.action = true;
                });
            });
        }
        else
        {
            OnTouchBike(obj3.transform);
        }
    }
}
