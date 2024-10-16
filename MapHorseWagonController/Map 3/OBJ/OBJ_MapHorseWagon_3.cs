using DG.Tweening;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.UI;

public class OBJ_MapHorseWagon_3 : OBJBase
{
    private GameObject soldier;
    private GameObject goods1;
    private GameObject goods2;
    private GameObject goods3;

    public AudioSource dropBrush;
    public AudioSource tree;
    public AudioSource cutTree;
    public AudioSource grass;
    public AudioSource horse;

    private Animator animatorHorse;

    private bool actionTree1 = true;
    private bool actionTree2 = true;
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
        obj1 = GameObject.FindGameObjectWithTag("obj1");//brush
        obj2 = GameObject.FindGameObjectWithTag("obj2");//axe
        obj3 = GameObject.FindGameObjectWithTag("obj3");//tree1
        obj4 = GameObject.FindGameObjectWithTag("obj4");//tree2
        obj5 = GameObject.FindGameObjectWithTag("obj5");//BrushOnTree1
        obj6 = GameObject.FindGameObjectWithTag("obj6");//BrushOnTree2
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
    public void Intro()
    {
        animatorHorse.SetFloat("Status", 1);
        animator2.SetFloat("Status", 1);
        var Tween1 = wheel1.transform.DORotate(new Vector3(0, 0, -360), 1, RotateMode.FastBeyond360).SetLoops(-1, LoopType.Restart).SetEase(Ease.Linear);
        var Tween2 = wheel2.transform.DORotate(new Vector3(0, 0, -360), 1, RotateMode.FastBeyond360).SetLoops(-1, LoopType.Restart).SetEase(Ease.Linear);
        obj.transform.DOMoveX(2f, 3).SetEase(Ease.Linear).OnComplete(() =>
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
    public void TouchBrush()
    {
        if (GameManager.countAction == 0 && GameManager.action)
        {
            MoveRaoundLight(obj2.transform.position);
            grass.Play();
            GameManager.action = false;
            obj1.transform.DOMove(new Vector3(8, -0.15f), 0.5f).OnComplete(() =>
            {
                obj1.transform.DOMove(new Vector3(15, 2f), 0.5f).OnComplete(() =>
                {
                    GameManager.action = true;
                    GameManager.countAction++;
                });
            });
        }
        else
        {
            touchUI.Play();
        }
    }
    public void TouchAxe()
    {
        Debug.Log(123);
        if (GameManager.countAction == 1 && GameManager.action)
        {
            MoveRaoundLight(new Vector3(-5.6f, -3.5f, 0));
            touchUI.Play();
            GameManager.action = false;
            obj2.transform.DORotate(new Vector3(0, 180, 10), 0.2f);
            obj2.transform.DOMove(new Vector3(-5.29f, 2.29f, obj2.transform.position.z), 0.5f).OnComplete(() =>
            {
                obj2.transform.DORotate(new Vector3(0, 180, 90), 0.1f).SetEase(Ease.InOutSine).OnStepComplete(PlayAudioAxe).SetLoops(6, LoopType.Yoyo).OnComplete(() =>
                {
                    dropBrush.Play();
                    obj6.transform.DOMoveY(-9, 0.5f);
                    obj2.transform.DOMove(new Vector3(-7f, 1f, obj2.transform.position.z), 0.5f).OnComplete(() =>
                    {
                        obj2.transform.DORotate(new Vector3(0, 180, 90), 0.1f).SetEase(Ease.InOutSine).OnStepComplete(PlayAudioAxe).SetLoops(6, LoopType.Yoyo).OnComplete(() =>
                        {
                            dropBrush.Play();
                            obj2.transform.DORotate(new Vector3(0, 0, 10), 0.1f);
                            obj5.transform.DOMoveY(-9, 0.5f);
                            obj2.transform.DOMove(new Vector3(-6f, -3.5f, obj2.transform.position.z), 0.5f).OnComplete(() =>
                            {
                                GameManager.action = true;
                                GameManager.countAction++;
                            });
                        });
                    });
                });
            });
        }
        else if (GameManager.countAction == 2 && GameManager.action)
        {
            MoveRaoundLight(obj4.transform.position);
            obj2.transform.DORotate(new Vector3(0, 180, 10), 0.2f);
            obj2.transform.DOMove(new Vector3(-5.6f, -2.5f, obj2.transform.position.z), 0.5f).OnComplete(() =>
            {

                obj2.transform.DORotate(new Vector3(0, 180, 70), 0.1f).SetEase(Ease.InOutSine).OnStepComplete(PlayAudioAxe).SetLoops(6, LoopType.Yoyo).OnComplete(() =>
                 {
                     obj2.transform.DOMoveX(-8f, 0.5f).OnComplete(() =>
                      {
                          obj2.transform.DORotate(new Vector3(0, 180, 70), 0.1f).SetEase(Ease.InOutSine).OnStepComplete(PlayAudioAxe).SetLoops(6, LoopType.Yoyo).OnComplete(() =>
                                 {
                                     obj2.transform.DOMove(new Vector3(-6f, -3.5f, obj2.transform.position.z), 0.5f);
                                     GameManager.countAction++;
                                 });
                      });
                 });
            });
        }
        else
        {
            touchUI.Play();
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
    public void TouchTrees_1()
    {
        if (GameManager.countAction == 3 && GameManager.action && actionTree1 || GameManager.countAction == 4 && GameManager.action && actionTree1)
        {
            MoveRaoundLight(obj4.transform.position);
            actionTree1 = false;
            GameManager.action = false;
            obj3.transform.DORotate(new Vector3(0, 0, 90), 0.2f);
            obj3.transform.DOMove(new Vector3(4.52f, -2f), 0.5f).OnComplete(() =>
            {
                obj3.transform.DOMoveY(-4f, 0.5f).OnComplete(() =>
                {
                    tree.Play();
                    GameManager.countAction++;
                    GameManager.action = true;
                    if (GameManager.countAction == 5)
                    {
                        animatorHorse.SetFloat("Status", 1);
                        animator2.SetFloat("Status", 1);
                        var Tween1 = wheel1.transform.DORotate(new Vector3(0, 0, -360), 1, RotateMode.FastBeyond360).SetLoops(-1, LoopType.Restart).SetEase(Ease.Linear);
                        var Tween2 = wheel2.transform.DORotate(new Vector3(0, 0, -360), 1, RotateMode.FastBeyond360).SetLoops(-1, LoopType.Restart).SetEase(Ease.Linear);
                        textBox.SetActive(false);
                        GameManager.done = true;
                    }
                });

            });
        }
        else
        {
            touchUI.Play();
        }

    }
    public void TouchTrees_2()
    {
        if (GameManager.countAction == 3 && GameManager.action && actionTree2 || GameManager.countAction == 4 && GameManager.action && actionTree2)
        {
            MoveRaoundLight(obj3.transform.position);
            actionTree2 = false;
            GameManager.action = false;
            obj4.transform.DORotate(new Vector3(0, 0, -90), 0.2f);
            obj4.transform.DOMove(new Vector3(4.52f, -2f), 0.5f).OnComplete(() =>
            {
                obj4.transform.DOMoveY(-4f, 0.5f).OnComplete(() =>
                {
                    tree.Play();

                    GameManager.countAction++;
                    GameManager.action = true;
                    if (GameManager.countAction == 5)
                    {
                        animatorHorse.SetFloat("Status", 1);
                        animator2.SetFloat("Status", 1);
                        var Tween1 = wheel1.transform.DORotate(new Vector3(0, 0, -360), 1, RotateMode.FastBeyond360).SetLoops(-1, LoopType.Restart).SetEase(Ease.Linear);
                        var Tween2 = wheel2.transform.DORotate(new Vector3(0, 0, -360), 1, RotateMode.FastBeyond360).SetLoops(-1, LoopType.Restart).SetEase(Ease.Linear);
                        GameManager.done = true;
                        textBox.SetActive(false);
                    }
                });
            });
        }
        else
        {
            touchUI.Play();
        }
    }
}
