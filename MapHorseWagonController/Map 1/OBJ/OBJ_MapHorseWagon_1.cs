using DG.Tweening;
using UnityEngine;

public class OBJ_MapHorseWagon_1 : OBJBase
{
    public AudioSource horseWagon;
    public AudioSource goods;
    public AudioSource horse;

    private bool actionBag1 = true;
    private bool actionBag2 = true;
    private bool actionBag3 = true;
    // Start is called before the first frame update
    void Start()
    {
        GetObj();
    }

    public override void GetObj()
    {
        base.GetObj();
        obj1 = GameObject.FindGameObjectWithTag("obj1");// HorseButton
        obj2 = GameObject.FindGameObjectWithTag("obj2");// Goods
        obj3 = GameObject.FindGameObjectWithTag("obj3");// HorseWagon
        obj4 = GameObject.FindGameObjectWithTag("obj4");// PlayerBT
        obj5 = GameObject.FindGameObjectWithTag("obj5");// Goods
        obj6 = GameObject.FindGameObjectWithTag("obj6");// Goods
        obj7 = GameObject.FindGameObjectWithTag("obj7");// Horse
        obj8 = GameObject.FindGameObjectWithTag("obj8");// Player
        wheel1 = GameObject.FindGameObjectWithTag("Wheel1");
        wheel2 = GameObject.FindGameObjectWithTag("Wheel2");
        animator = obj7.GetComponent<Animator>();
        animator2 = obj8.GetComponent<Animator>();
        textBox.SetActive(true);
    }
    public void Touch_Horse_Wagon()
    {

        if (GameManager.countAction == 0 && GameManager.action)
        {
            MoveRaoundLight(obj7.transform.position);
            horseWagon.Play();
            GameManager.action = false;
            obj3.transform.DORotate(new Vector3(0, 0, 0), 1f).OnComplete(() =>
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
    public void Touch_Horse()
    {
        if (GameManager.countAction == 1 && GameManager.action)
        {
            MoveRaoundLight(obj5.transform.position);
            horse.Play();
            GameManager.action = false;

            animator.SetFloat("Status", 1);
            obj7.transform.localScale = new Vector3(120f, 120f, 120f);
            obj7.transform.DOMoveX(-2.5f, 1f).OnComplete(() =>
            {
                animator.SetFloat("Status", 0);
                obj7.transform.localScale = new Vector3(-120f, 120f, 120f);
            });

            obj1.transform.DOMoveX(-2.5f, 1f).OnComplete(() =>
            {
                Debug.Log(obj1.transform.position);
                GameManager.action = true;
                GameManager.countAction++;
            });
        }
        else
        {
            horse.Play();
            animator.Play("Pedal");
        }

    }
    public void Touch_Goods1()
    {
        if (GameManager.countAction == 2 && GameManager.action && actionBag1 || GameManager.countAction == 3 && GameManager.action && actionBag1 || GameManager.countAction == 4 && GameManager.action && actionBag1)
        {
            MoveRaoundLight(obj5.transform.position);
            if (GameManager.countAction == 4) MoveRaoundLight(obj8.transform.position);
            else SetTime();
            actionBag1 = false;
            GameManager.action = false;
            obj2.transform.DOMove(new Vector3(-7.2f, 2f, 0), 1f).OnComplete(() =>
            {
                obj2.transform.DOMoveY(-0.5f, 0.5f).OnComplete(() =>
                {
                    goods.Play();
                    GameManager.action = true;
                    GameManager.countAction++;
                });
            });
        }
        else
        {
            OnTouchBike(obj2.transform);
        }

    }
    public void Touch_Goods2()
    {
        if (GameManager.countAction == 2 && GameManager.action && actionBag2 || GameManager.countAction == 3 && GameManager.action && actionBag2 || GameManager.countAction == 4 && GameManager.action && actionBag2)
        {
            MoveRaoundLight(obj5.transform.position);
            if (GameManager.countAction == 4) MoveRaoundLight(obj8.transform.position);
            else SetTime();
            actionBag2 = false;
            GameManager.action = false;
            obj5.transform.DOMove(new Vector3(-6.2f, 2f, 0), 1f).OnComplete(() =>
            {
                obj5.transform.DOMoveY(-1.2f, 0.5f).OnComplete(() =>
                {
                    goods.Play();
                    GameManager.action = true;
                    GameManager.countAction++;
                });
            });
        }
        else
        {
            OnTouchBike(obj5.transform);
        }

    }
    public void Touch_Goods3()
    {
        if (GameManager.countAction == 2 && GameManager.action && actionBag3 || GameManager.countAction == 3 && GameManager.action && actionBag3 || GameManager.countAction == 4 && GameManager.action && actionBag3)
        {
            MoveRaoundLight(obj5.transform.position);
            if (GameManager.countAction == 4) MoveRaoundLight(obj8.transform.position);
            else SetTime();
            actionBag3 = false;
            GameManager.action = false;
            obj6.transform.DOMove(new Vector3(-8.2f, 2f, 0), 1f).OnComplete(() =>
            {
                obj6.transform.DOMoveY(-1.2f, 0.5f).OnComplete(() =>
                {
                    goods.Play();
                    GameManager.action = true;
                    GameManager.countAction++;
                });
            });
        }
        else
        {
            OnTouchBike(obj6.transform);
        }

    }
    public void Touch_Player()
    {
        if (GameManager.countAction == 5 && GameManager.action)
        {
            textBox.SetActive(false);
            MoveRaoundLight(Vector3.zero);
            GameManager.action = false;
            animator2.SetFloat("Status", 1);
            obj8.transform.DOScaleX(-this.obj8.transform.localScale.x, 0);
            obj8.transform.DOMoveX(-1.25f, 2f).OnComplete(() =>
            {
                obj8.transform.DOScaleX(-this.obj8.transform.localScale.x, 0);
                wheel1.transform.DORotate(new Vector3(0, 0, -360), 1, RotateMode.FastBeyond360).SetLoops(-1, LoopType.Restart).SetEase(Ease.Linear);
                wheel2.transform.DORotate(new Vector3(0, 0, -360), 1, RotateMode.FastBeyond360).SetLoops(-1, LoopType.Restart).SetEase(Ease.Linear);
                animator.SetFloat("Status", 1);
                GameManager.action = true;
                GameManager.countAction++;
                GameManager.done = true;
            });
        }
        else
        {
            OnTouchBike(obj4.transform);
        }
    }
}
