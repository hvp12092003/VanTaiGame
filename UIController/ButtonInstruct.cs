using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonInstruct : MonoBehaviour
{
    private GameObject obj1;
    private GameObject obj2;
    private GameObject obj3;

    private bool activeInstruct = false;
    private bool actionTutorio = true;
    public AudioSource audioSource;

    // Start is called before the first frame update
    void Start()
    {
        obj1 = GameObject.FindGameObjectWithTag("obj1");
        obj2 = GameObject.FindGameObjectWithTag("obj2");
        obj3 = GameObject.FindGameObjectWithTag("obj3");
    }
    public void ButtonActive()
    {
        audioSource.Play();
        if (!activeInstruct)
        {
            activeInstruct = true;
            obj1.transform.DOMoveY(0, 1).OnComplete(() =>
            {
                obj2.transform.DOMoveY(0, 1).OnComplete(() =>
                {
                    actionTutorio = false;
                    obj3.transform.DOMoveY(0, 1);
                    ;
                });
            });
        }
        else
        {
            activeInstruct = false;
            obj1.transform.DOMoveY(-5f, 1);
            obj2.transform.DOMoveY(-5f, 1);
            obj3.transform.DOMoveY(-5f, 1);
        }
    }
    public void ButtonNextScene()
    {
        audioSource.Play();
        obj1.transform.DOMoveX(-15, 0.5f);
        obj2.transform.DOMoveY(-5, 0.5f);
        obj3.transform.DOMoveX(15, 0.5f).OnComplete(() => { SceneManager.LoadScene(2); });
    }
}
