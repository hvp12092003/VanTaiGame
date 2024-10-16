using DG.Tweening;
using System;
using System.Threading.Tasks;
using UnityEngine;
public class OBJ_Bird : MonoBehaviour
{
    private Vector3 originPos;
    public AudioSource Bird;
    public int waitDuration = 15;
    // Start is called before the first frame update
    void Start()
    {
        this.transform.position = new Vector3(this.transform.position.x, 3.5f);
        originPos = this.transform.position;
        AcinMove(waitDuration);
    }
    public async Task AcinMove(int delayInSeconds)
    {
       //Bird.Play();
        this.transform.DOMoveY(this.transform.position.y + 0.5f, 2).SetEase(Ease.Linear).SetLoops(-1, LoopType.Yoyo);
        this.transform.DOMoveX(10, 8f).SetEase(Ease.Linear).OnComplete(() =>
        {
            this.transform.position = originPos;
        });
        await Task.Delay(delayInSeconds * 1000);
        await AcinMove(delayInSeconds);
    }
}
