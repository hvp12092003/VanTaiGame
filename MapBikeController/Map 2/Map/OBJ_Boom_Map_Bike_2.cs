using DG.Tweening;
using UnityEngine;

public class OBJ_Boom_Map_Bike_2 : MonoBehaviour
{
    public GameObject obj1;
    public GameObject obj2;
    public Animator animator;
    public AudioSource bang;
    // Start is called before the first frame update
    void Start()
    {
        GameManager.countAction = -1;
        obj1 = GameObject.FindGameObjectWithTag("obj1");
        obj2 = GameObject.FindGameObjectWithTag("obj2");
        animator = obj1.GetComponentInChildren<Animator>();


    }
    public void Update()
    {
        if (GameManager.countAction == 0)
        {
            GameManager.countAction = -1;
            ActionBoom();
        }
    }
    private void ActionBoom()
    {
        obj1.transform.DOMove(new Vector3(8.85f, 0f), 0.5f).SetEase(Ease.InOutSine).OnComplete(() =>
        {
            animator.Play("Explosion_Boom");
        });
    }
    public void AudioBang()
    {
        bang.Play();
    }
    public void DestroyBoomAndRoad()
    {
        GameManager.countAction = -0;
        Destroy(obj1.gameObject);
        Destroy(obj2.gameObject);
    }
}
