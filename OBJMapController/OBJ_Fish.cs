using DG.Tweening;
using UnityEngine;

public class OBJ_Fish : MonoBehaviour
{
    private Vector3 originPos;
    public AudioSource Fish;
    private float jumpHeight = 3f; // Chiều cao của cú nhảy
    private float jumpDuration = 1f; // Thời gian của cú nhảy
    public float waitDuration = 15f; // Thời gian chờ trước khi nhảy
    private Tween action1;
    public bool Right;
    private int x;
    void Start()
    {
        originPos = this.transform.position;
        SetAction1();
        Jump();      
    }
    public void SetAction1()
    {
        action1 = this.transform.DOMoveY(this.transform.position.y + 0.5f, 2).SetEase(Ease.Linear).SetLoops(-1, LoopType.Yoyo);
    }
    void Jump()
    {
        if (Right) x = -1;
        else x = 1;
        Sequence jumpSequence = DOTween.Sequence();
        jumpSequence.AppendInterval(waitDuration)
                    .Append(transform.DORotate(new Vector3(0, 0, -30 * x), jumpDuration / 2).SetEase(Ease.OutQuad))
                    .AppendCallback(() =>
                    {
                        action1.Kill();
                    })
                    .Join(transform.DOMoveY(originPos.y + jumpHeight, jumpDuration / 2).SetEase(Ease.OutQuad))
                    .Append(transform.DORotate(new Vector3(0, 0, 30 * x), jumpDuration / 2).SetEase(Ease.InQuad))
                    .Append(transform.DORotate(new Vector3(0, 0, 0), jumpDuration / 2).SetEase(Ease.InQuad))
                    .Join(transform.DOMoveY(originPos.y, jumpDuration / 2).SetEase(Ease.InQuad))
                    .AppendCallback(SetAction1)
                    .OnComplete(() =>
                    {
                        Fish.Play();
                        Jump();
                    });
    }
}
