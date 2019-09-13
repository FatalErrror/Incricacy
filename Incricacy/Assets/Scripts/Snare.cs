using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Snare : MonoBehaviour
{
    Transform Arrovs, camera, canvas1;
    public GameObject Sn2, Timer1;
    GameObject Sn2_1, Camera, arrovs, Timer2, canvas;
    UnityEngine.UI.Text Timer3;
    Game game;
    BoxCollider2D boxCollider;
    int[] Need = new int[6];
    int time = 0, timer, resetTime;
    public Color Red;
    bool activ, fall;
    bool Message = false;
    Spin spin;
    // Start is called before the first frame update
    void Start()
    {
        Camera = GameObject.Find("Main Camera");
        arrovs = GameObject.Find("Arrows(B)");
        camera = Camera.GetComponent<Transform>();
        Arrovs = arrovs.GetComponent<Transform>();
        game = Camera.GetComponent<Game>();
        boxCollider = GetComponent<BoxCollider2D>();
        canvas = GameObject.Find("Canvas");
        canvas1 = canvas.GetComponent<Transform>();
        spin = GameObject.Find("horoscope-1_0").GetComponent<Spin>();
        
    }
    // Update is called once per frame
    void Update()
    {
        if (Message && !game.message) Work();
    }
    private void FixedUpdate()
    {
        if (!Message && ++resetTime > 500 && boxCollider.enabled != true) { resetTime = 0; boxCollider.enabled = true; }
        if (activ)
        {
            resetTime = 0;
            if (++time > 49) { time = 0; --timer; Timer3.text = System.Convert.ToString(Mathf.CeilToInt(timer / 60)) + ":" + System.Convert.ToString(timer % 60); }//// System.Convert.ToString(spin.vector);}
            if (timer <= 0) { End(true); }
            if (PlayerPrefs.GetInt("Completed", 0) == 1) { End(false); }
            if (timer <= 10) { Timer3.color = Red; }
        }
        if (fall)
        {
            game.Pers.localScale = new Vector3(game.Pers.localScale.y - 0.005f, game.Pers.localScale.y - 0.005f, 1);
            //game.pers.color = new Color(game.pers.color.b - 0.15f, game.pers.color.b - 0.15f, game.pers.color.b - 0.15f);
            if (game.Pers.localScale.y <= 0.5f)
            {
                fall = false;
                game.Controler.valueMultiplier = 1;
                game.Pers.localScale = new Vector3(1, 1, 1);
                game.pers.color = new Color(255, 255, 255);
                GameObject.Destroy(Sn2_1);
                game.CHhert(-1);
                resetTime = 0;
            }
        }
    }
    public void Work()
    {
        activ = true;
        Message = false;
        camera.position = new Vector3(transform.position.x, transform.position.y, -12);
        game.message = true;
        boxCollider.enabled = false;
        resetTime = 0;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (Random.Range(System.Convert.ToInt32(game.Dificlt - 2), 1) == 0)
        {
            timer = System.Convert.ToInt32(game.time);
            game.Controler.valueMultiplier = 0;
            Arrovs.localPosition = new Vector3(0, 0, -637);
            Timer2 = GameObject.Instantiate(Timer1, canvas1);
            Timer3 = Timer2.GetComponent<UnityEngine.UI.Text>();
            Timer3.text = System.Convert.ToString(Mathf.CeilToInt(timer / 60)) + ":" + System.Convert.ToString(timer % 60);
            Message = true;
            game.Message_();
        }
        else
        {
            boxCollider.enabled = false;
            resetTime = 0;
        }
        

    }
    void End(bool Fail)
    {
        activ = false;
        PlayerPrefs.SetInt("Completed", 0);
        PlayerPrefs.Save();
        Arrovs.localPosition = new Vector3(0, 2000, -637);
        for (int i = 0; i < 3; ++i)
        {
            spin.s1.Rotate(0, 0, Random.Range(0, 6) * 60);
            spin.s2.Rotate(0, 0, Random.Range(0, 6) * 60);
            spin.s3.Rotate(0, 0, Random.Range(0, 6) * 60);
        }
        timer = System.Convert.ToInt32(game.time);
        GameObject.Destroy(Timer2);
        if (Fail)
        {
            fall = true;
            Sn2_1 = GameObject.Instantiate(Sn2, transform);
        }
        else
        {
            game.Controler.valueMultiplier = 1;

        }

        resetTime = 0;
    }
}

