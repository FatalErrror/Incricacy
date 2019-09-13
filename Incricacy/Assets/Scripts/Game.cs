using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SimpleInputNamespace;
/*data
 data[0] = X
 data[1] = Y
 data[2] = HP
 data[3] = key
 data[4-12] = Инвентарь
 data[13-16] = двери
 data[17-50] = что в сундуке?    
 */
public class Game : MonoBehaviour
{
    public Color Light = new Color(255,255,255), Dark= new Color(127,127,127);
    Rigidbody2D rigidbody;
    public AudioSource Step,Cave;
    public SpriteRenderer hert1, hert2, hert3, key1, key2, key3, key4,pers;
    public SpriteRenderer[] inv = new SpriteRenderer[8];
    public UnityEngine.UI.Toggle PM;
    public Sprite[] Sp = new Sprite[8];
    public SimpleInputNamespace.Joystick Controler;
    public Transform Pers,invent,Rule;
    public float Speed, HP, key,Dificlt,time;
    public float[] data = new float[51];
    public int[,] where_chase = new int[26, 26];
    public bool Hert,Sound,Music,Message,ij = false, message = true;
    public GameObject GO,gameObject,tab;
    string[] data1 = new string[51];
    int timer = -20;
    // Start is called before the first frame update
    public void Message_(bool i = false)
    {
        if (!Message || i)
        {
            Rule.localPosition = new Vector3(0, 0.5f, 5);
            PM = GameObject.FindGameObjectWithTag("Message").GetComponent<UnityEngine.UI.Toggle>();
            PM.isOn = Message;
            message = true;
            ij = i;
        }
        else end();
    }
    public void end()
    {
        Rule.localPosition = new Vector3(0, 10, 5);
        if (!ij) message = false;
    }
    public void CHM()
    {
        Message = PM.isOn;
        PlayerPrefs.SetFloat("6",System.Convert.ToInt32(Message));
        PlayerPrefs.Save();
    }
    void Start()
    {
        string[] Set = { "1", "2", "3", "4", "5" ,"6"};
        time = 90 - ( PlayerPrefs.GetFloat(Set[0], 1)*30);
        Dificlt = PlayerPrefs.GetFloat(Set[1], 1);
        Speed = PlayerPrefs.GetFloat(Set[2], 1);
        Sound = System.Convert.ToBoolean(PlayerPrefs.GetFloat(Set[3], 1));
        Music = System.Convert.ToBoolean(PlayerPrefs.GetFloat(Set[4], 1));
        Message = System.Convert.ToBoolean(PlayerPrefs.GetFloat(Set[5], 0));
        for (int i = 0; i < 51; ++i) { data1[i] = "Data" + i; }
        for (int i = 0; i < 51; ++i) data[i] = PlayerPrefs.GetFloat(data1[i]);
        transform.position = new Vector3(data[0], data[1],-12f);
        CHhert(data[2]);
        CHkey( data[3]);
        rigidbody = GetComponent<Rigidbody2D>();
        if (!Sound) Step.clip = null;
        chase();
    }
    public void Pause()
    {
        data[0] = transform.position.x;
        data[1] = transform.position.y;
        data[2] = HP;
        data[3] = key;
        for (int i = 0; i < 51; ++i) { PlayerPrefs.SetFloat(data1[i], data[i]); }
        PlayerPrefs.Save();
        Application.LoadLevel(0);
    }
    public void Game_Over()
    {
        PlayerPrefs.DeleteKey("Data0");
        Application.LoadLevel(3);
    }
    // Update is called once per frame
    void Update()
    {

        if (Music) Cave.volume = 1f; else Cave.volume = 0;
        if (HP < 1) GameOver();
        transform.Translate( Controler.xAxis.value * Speed * Time.deltaTime, Controler.yAxis.value * Speed * Time.deltaTime,0);
        if (Controler.xAxis.value < 0) Pers.localScale = new Vector3(-1,1,1); else if (Controler.xAxis.value > 0) Pers.localScale = new Vector3(1, 1, 1);
        if (Controler.xAxis.value!=0 || Controler.yAxis.value != 0) Step.volume = 1; else Step.volume = 0;
    }
    private void FixedUpdate()
    {
        if (--timer <= 0 && timer>-10) { Application.LoadLevel(0); }
        
    }
    void chase()
    {
        where_chase[10, 1] = 1;
        where_chase[21, 1] = 2;
        where_chase[8, 3] = 3;
        where_chase[3, 4] = 4;
        where_chase[9, 6] = 5;
        where_chase[13, 7] = 6;
        where_chase[4, 8] = 7;
        where_chase[9, 8] = 8;
        where_chase[4, 9] = 9;
        where_chase[10, 10] = 10;
        where_chase[3, 11] = 11;
        where_chase[14, 11] = 12;
        where_chase[18, 11] = 13;
        where_chase[23, 11] = 14;
        where_chase[7, 13] = 15;
        where_chase[9, 13] = 16;
        where_chase[3, 14] = 17;
        where_chase[10, 14] = 18;
        where_chase[17, 14] = 19;
        where_chase[8, 15] = 20;
        where_chase[1, 16] = 21;
        where_chase[21, 16] = 22;
        where_chase[22, 16] = 23;
        where_chase[5, 17] = 24;
        where_chase[10, 18] = 25;
        where_chase[13, 18] = 26;
        where_chase[7, 19] = 27;
        where_chase[5, 20] = 28;
        where_chase[19, 20] = 29;
        where_chase[22, 20] = 30;
        where_chase[2, 21] = 31;
        where_chase[7, 23] = 32;
        where_chase[3, 24] = 33;
        where_chase[18, 25] = 34;
    }
    public void In_Inventory(float obj)
    {
        if (obj == 5) CHkey(1);
        else
        {
            int i = 4;
            while ((data[i] != 0) && (data[i] < 12)) { i += 1; }
            data[i] = obj;
        }
    }
    public void GameOver()
    {
        GameObject.Instantiate(GO, transform);
        HP = 1;
        PlayerPrefs.DeleteKey("Data0");
        timer = 200;
    }
    public void CHhert(float value)
    {
        if (HP > 3) HP = 3;
        HP += value;
        
        switch(HP)
        {
            case 0: hert1.color = Dark; hert2.color = Dark; hert3.color = Dark; break;
            case 1: hert1.color = Light; hert2.color = Dark; hert3.color = Dark; break;
            case 2: hert1.color = Light; hert2.color = Light; hert3.color = Dark; break;
            case 3: hert1.color = Light; hert2.color = Light; hert3.color = Light; break;
        }
    }
    public void CHkey(float value)
    {

        key += value;
        switch (key)
        {
            case 0: key1.color = Dark; key2.color = Dark; key3.color = Dark; key4.color = Dark; break;
            case 1: key1.color = Light; key2.color = Dark; key3.color = Dark; key4.color = Dark; break;
            case 2: key1.color = Light; key2.color = Light; key3.color = Dark; key4.color = Dark; break;
            case 3: key1.color = Light; key2.color = Light; key3.color = Light; key4.color = Dark; break;
            case 4: key1.color = Light; key2.color = Light; key3.color = Light; key4.color = Light; break;
        }
    }
    public void Inventory(int numb)
    {
        switch(numb)
        {
            case 0: if (invent.position.x != transform.position.x ) { invent.position = transform.position;invent.Translate(0,0,10f); for (int hdfg = 0; hdfg < 8; ++hdfg) { inv[hdfg].sprite = Sp[Mathf.CeilToInt(data[4 + hdfg])]; } } else { invent.position = new Vector3(-10, 0, 0); } break;
            default:
                {
                    switch (data[3 + numb])
                    {
                        case 1: inv[numb-1].sprite = Sp[0];CHhert(1);data[3 + numb] = 0; break;
                    } 

                    break;
                }

        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.transform.position.y > -7) gameObject = GameObject.Instantiate<GameObject>(tab,transform);
        
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.transform.position.y > -7) GameObject.Destroy(gameObject);
    }
}


