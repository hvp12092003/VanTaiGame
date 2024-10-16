using UnityEngine;
using DG.Tweening;
using Unity.VisualScripting;

public class OBJ_MapBike_1 : OBJBase
{
    public GameObject armL, armR;

    private Animator soldier;

    private bool actionObj1 = true;
    private bool actionObj2 = true;
    // Start is called before the first frame update
    void Start()
    {
        GetObj();
        textBox.SetActive(true);
    }
    public override void GetObj()
    {
        base.GetObj();
        obj1 = GameObject.FindGameObjectWithTag("obj1");
        obj2 = GameObject.FindGameObjectWithTag("obj2");
        obj3 = GameObject.FindGameObjectWithTag("obj3");
        obj4 = GameObject.FindGameObjectWithTag("obj4");
        wheel1 = GameObject.FindGameObjectWithTag("Wheel1");
        wheel2 = GameObject.FindGameObjectWithTag("Wheel2");

        soldier = obj4.GetComponent<Animator>();
    }
    public void OnTouchOBJ1()
    {
        if (GameManager.countAction == 0 && actionObj1 && GameManager.action || GameManager.countAction == 1 && actionObj1 && GameManager.action)
        {
           if(GameManager.countAction==0) MoveRaoundLight(obj2.transform.position);
           else MoveRaoundLight(obj3.transform.position);
            GameManager.action = false;
            obj1.transform.DOMove(new Vector3(0f, 1f, obj1.transform.position.z), 0.5f).OnComplete(() =>
            {
                obj1.transform.DOMoveY(-1f, 0.2f).OnComplete(() =>
                {
                    audioSource1.Play();
                    actionObj1 = false;
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
    public void OnTouchOBJ2()
    {
        if (GameManager.countAction == 1 && actionObj2 && GameManager.action || GameManager.countAction == 0 && actionObj2 && GameManager.action)
        {
            if (GameManager.countAction == 1) MoveRaoundLight(obj3.transform.position);
            GameManager.action = false;
            obj2.transform.DOMove(new Vector3(0.2f, 1f, obj2.transform.position.z), 0.5f).OnComplete(() =>
            {
                obj2.transform.DOMoveY(-1.2f, 0.2f).OnComplete(() =>
                {
                    audioSource1.Play();
                    actionObj2 = false;
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
    public void OnTouchOBJ3()
    {

        if (GameManager.countAction == 2 && GameManager.action)
        {
            GameManager.action = false;
            textBox.SetActive(false);
            soldier.SetFloat("Status", 1);
            obj3.transform.DOMoveX(1.1f, 1f).OnComplete(() =>
            {
                armL.SetActive(true);
                armR.SetActive(true);
                soldier.SetFloat("Status", 3);

                wheel1.transform.DORotate(new Vector3(0, 0, -360), 1, RotateMode.FastBeyond360).SetLoops(-1, LoopType.Restart).SetEase(Ease.Linear);
                wheel2.transform.DORotate(new Vector3(0, 0, -360), 1, RotateMode.FastBeyond360).SetLoops(-1, LoopType.Restart).SetEase(Ease.Linear);
                GameManager.countAction++;
                GameManager.action = true;
                GameManager.done = true;
            });
        }
        else
        {
            OnTouchBike(obj3.transform);
        }
    }

}
