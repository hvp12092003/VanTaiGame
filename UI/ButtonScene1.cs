using UnityEngine;
using UnityEngine.SceneManagement;
using DG.Tweening;
using TMPro;
using UnityEngine.UI;

public class ButtonScene1 : MonoBehaviour
{
    private GameObject obj1;
    private GameObject obj2;
    private GameObject obj3;
    //private GameObject obj4;
    private GameObject obj5;

    //private DragController dragController;
    private TextMeshProUGUI instructText;
    public TextMeshProUGUI buttonStartText;
    public string VietText;
    public string EnglishText;
    public string FranceText;
    private Image imageCanvas1;
    private Image imageCanvas2;
    public Image[] imageButtonLanguage;
    public Sprite[] sprites;
    public Color[] color;
    private bool actionTutorio = true;
    public AudioSource audioSource;
    public void Start()
    {
        GetObj();
        Intro();
        Handler();
    }
    public void GetObj()
    {
        //dragController = FindFirstObjectByType<DragController>();
        obj1 = GameObject.FindGameObjectWithTag("obj1");
        obj2 = GameObject.FindGameObjectWithTag("obj2");
        obj3 = GameObject.FindGameObjectWithTag("obj3");
        //obj4 = GameObject.FindGameObjectWithTag("obj4");
        //instructText = obj4.GetComponent<TextMeshProUGUI>();
        obj5 = GameObject.FindGameObjectWithTag("obj5");
        imageCanvas1 = GameObject.FindGameObjectWithTag("obj6").GetComponent<Image>();
        imageCanvas2 = GameObject.FindGameObjectWithTag("obj7").GetComponent<Image>();
        buttonStartText = GameObject.FindGameObjectWithTag("obj8").GetComponentInChildren<TextMeshProUGUI>();
    }
    public void Intro()
    {
        obj5.transform.DOMoveY(0f, .5f);
        imageButtonLanguage[1].color = color[1];
    }
    public void ButtonInstruct()
    {
        obj1.transform.DOMoveY(0.25f, 1).OnComplete(() =>
        {
            obj2.transform.DOMoveY(0.25f, 1).OnComplete(() =>
            {
                actionTutorio = false;
                obj3.transform.DOMoveY(0.25f, 1);
                ;
            });
        });
    }
    public void ButtonNextScene()
    {
        audioSource.Play();
        obj1.transform.DOMoveX(-15, 0.5f);
        obj2.transform.DOMoveY(-5, 0.5f);
        obj3.transform.DOMoveX(15, 0.5f).OnComplete(() => { SceneManager.LoadScene(2); });
    }
    public void ButtonLanguageViet()
    {
        //change value
        objDDT.Instance.language = OBJ_DontDesTroy.Language.Viet;
        audioSource.Play();
        Handler();
    }
    public void ButtonLanguageEnglish()
    {
        //change value
        objDDT.Instance.language = OBJ_DontDesTroy.Language.English;
        audioSource.Play();
        Handler();
    }
    public void ButtonLanguageFrance()
    {
        //change value
        objDDT.Instance.language = OBJ_DontDesTroy.Language.France;
        audioSource.Play();
        Handler();
    }
    public void Handler()
    {
        switch (objDDT.Instance.language)
        {
            case OBJ_DontDesTroy.Language.Viet:

                // change color button
                imageButtonLanguage[0].color = color[0];
                imageButtonLanguage[1].color = color[1];

                //instructText.text = VietText;
                buttonStartText.text = "Bắt đầu";

                //change text 
                objDDT.Instance.language = OBJ_DontDesTroy.Language.Viet;
                //dragController.SetLanguage();

                // change panel
                imageCanvas1.sprite = sprites[0];
                imageCanvas2.sprite = sprites[0];
                break;
            case OBJ_DontDesTroy.Language.English:
                // change color button
                imageButtonLanguage[0].color = color[1];
                imageButtonLanguage[1].color = color[0];
                buttonStartText.text = "Start"; ;

                //change text
                objDDT.Instance.language = OBJ_DontDesTroy.Language.English;
                //dragController.SetLanguage();

                // change panel
                imageCanvas1.sprite = sprites[1];
                imageCanvas2.sprite = sprites[1];
                break;
            case OBJ_DontDesTroy.Language.France:
                // change color button
                // change panel
                imageCanvas1.sprite = sprites[2];
                imageCanvas2.sprite = sprites[2];
                buttonStartText.text = "Commencer";

                //change text
                objDDT.Instance.language = OBJ_DontDesTroy.Language.France;
                //dragController.SetLanguage();
                break;
        }
    }
}
