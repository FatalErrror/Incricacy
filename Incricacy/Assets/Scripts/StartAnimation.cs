using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartAnimation : MonoBehaviour
{
    public AudioSource Stepp, Forest, Stret;
    float Speedx=0,Speedy=0,Speed=2;
    public Transform Street;
    public RectTransform rect;
    public Sprite Pers, Shoper;
    bool pers_say,Dialog_end=true;
    public GameObject z, dialog,Loading,Camera;
    public SpriteRenderer icon;
    public UnityEngine.UI.Text words;
    int Dialog_String=-1,boolen=1;
    
    // Start is called before the first frame update
    void Start()
    {
        if (!System.Convert.ToBoolean(PlayerPrefs.GetFloat("4"))) { Stepp.clip = null; Forest.clip = null;  }
        if (!System.Convert.ToBoolean(PlayerPrefs.GetFloat("5"))) Stret.clip = null;
        Forest.volume = 0;
        Dialog();
    }

    // Update is called once per frame
    void Update()
    {
        Street.Translate(-Speed * Time.deltaTime, 0, 0);
        transform.Translate(Speedx*Time.deltaTime, Speedy * Time.deltaTime, 0);
        if (boolen == 1)
        {
            if (Street.position.x <= -3.87) { Speed = 0; Speedx = 2; }
            if (transform.position.x >= 1) { Speedy = 2.1f; Speedx = 2; }
            if (transform.position.y >= -1.8) { Speedy = 0; Speedx = 0; transform.localScale = new Vector3(-2.44f, 2.44f, 1); Dialog1(); Stepp.Stop();  }
        }
        if (boolen == 2)
        {
            if (transform.position.y <= -3.19) { Speedy = 0; }
            if (transform.position.x >= 10) { F(); }
        }
        if (boolen == 3) { if (transform.position.x <= -5.82f) H(); }
        if (boolen== 4) { if (transform.position.y <= -23) Skip(); }
    }
    void F()
    {
        boolen = 3;
        transform.localScale = new Vector3(-2.44f, 2.44f, 1);
        Camera.transform.position = new Vector3(0,-16.55f,-10);
        transform.position = new Vector3(10,-19,-0.1f);
        Speedy = 0;
        Speedx = -2;
        Stret.volume = 0;
        Forest.volume = 1;
    }
    void H()
    {
        boolen = 4;
        Camera.transform.position = new Vector3(25f, -16.55f, -10);
        transform.position = new Vector3(25,-10,-0.1f);
        transform.localScale = new Vector3(1,1,1);
        Speedy = -2;
        Speedx = 0;
        Forest.volume = 0;
    }
    public void Skip()
    {
        Camera.transform.position= new Vector3(-200,0,-10);
        GameObject.Instantiate(Loading, new Vector3(-200, 0, 0), new Quaternion(0, 0, 0, 0));
        Application.LoadLevel(2);
    }
    void Dialog1()
    {
       if (!Stepp.isPlaying) rect.position = new Vector3(0, 0, -0.1f); 
    }
    public void Dialog()
    {
       Dialog_String = Dialog_String + 1;
       switch (Dialog_String)
        {
            case 0: { words.text = "Ооо. Какие люди!"; pers_say = false; break; }
            case 1: { words.text = "Ага, привет!"; pers_say = true; break; }
            case 2: { words.text = "Ну что? Добыл что-нибудь ценное?"; pers_say= false; break; }
            case 3: { words.text = "Сейчас ничего полезного, но я ищу"; pers_say= true; break; }
            case 4: { words.text = "Слушай, ты же сейчас всё равно ничем особо не занят"; pers_say= false; break; }
            case 5: { words.text = "Хочешь работёнку подкину?"; pers_say= false; break; }
            case 6: { words.text = "А что делать надо?"; pers_say= true; break; }
            case 7: { words.text = "Да так... В шахту заброшенную сходить, там, говорят, куча золота осталась. Cо старой его выработки."; pers_say = false; break; }
            case 8: { words.text = "Заманчиво, но почему его ещё не забрали?"; pers_say= true; break; }
            case 9: { words.text = "Нуу...Понимаешь..."; pers_say= false; break; }
            case 10: { words.text = "Из-за жадных владельцев шахты, в старые времена  там было оставлено очень много ловушек"; pers_say = false; break; }
            case 11: { words.text = "И никто не может их пройти живым"; pers_say= false; break; }
            case 12: { words.text = "Говорят, что даже самый искусный искатель приключений не вернулся от туда"; pers_say= false; break; }
            case 13: { words.text = "Занятно. И  зачем ты рассказал мне об этом?"; pers_say= true; break; }
            case 14: { words.text = "Я же знаю, ты согласишся на любую работёнку, какой бы опасной она не была. А мне с этого прибыль и не малая"; pers_say = false; break; }
            case 15: { words.text = "Нуу... Есть такое"; pers_say= true; break; }
            case 16: { words.text = "Вот и я о том же. Ну так ты согласен?"; pers_say= false; break; }
            case 17: { words.text = "Раз я всё равно без денег и работы, то почему бы и нет. "; pers_say= true; break; }
            case 18: { words.text = "Вот и супер, если сможешь вернуться хоть с чем-то, то за каждый грамм золота заплачу по две сотни центов"; pers_say = false; break; }
            case 19: { words.text = "Больше чем обычно... Это очень хорошо."; pers_say= true; break; }
            case 20: { words.text = "Ну что ж, приятно иметь с тобой дело."; pers_say= true; break; }
            case 21: { words.text = "Говори, где эта шахта?"; pers_say= true; break; }
            case 22: { words.text = "Ща... Знаешь, на востоке, за янтарной горой, в лесу,  перед водопадом есть заросший карьер. Вот там, внизу и находится вход в шахту"; pers_say = false; break; }
            case 23: { words.text = "Но хочу предупредить, буть осторожен! Как я уже говорил, там очень много ловушек."; pers_say= false; break; }
            case 24: { words.text = "Хотя помимо лувушек там так же есть сундуки, в которых можно найти много чего полезного."; pers_say = false; break; }
            case 25: { words.text = "В принципе, это всё. Хотя... Погоди..."; pers_say= false; break; }
            case 26: { words.text = "На вот зелье здоровья, если вдруг понадобится использовать. Это мой тебе подарок ";z.transform.position=new Vector3(1.4f,-1); break; }
            case 27: { words.text = "Смотри, не пропади";GameObject.Destroy(z); pers_say= false; break; }
            case 28: { words.text = "Ага, не дождёшься."; pers_say= true; break; }
            case 29: { Dialog_end = false;boolen = 2; GameObject.Destroy(dialog); break; }
        }
       if (pers_say&&Dialog_end) icon.sprite = Pers; else if (Dialog_end)icon.sprite = Shoper;
       if (!Dialog_end) { Speedx = 2;Speedy = -2; transform.localScale = new Vector3(2.44f, 2.44f, 1);Stepp.Play(); }
    }
}
