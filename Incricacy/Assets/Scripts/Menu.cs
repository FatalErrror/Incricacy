using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Menu : MonoBehaviour
{
    public RectTransform Menu1;
    public GameObject Loading;
    public SpriteRenderer Intro;
    public AudioSource Cave;
    bool start = true;
    public float ij = 0;
    public UnityEngine.UI.Slider slider1, slider2, slider3;
    public UnityEngine.UI.Toggle Sound, Music;
    // Start is called before the first frame update
    void Start()
    {

        //ca-app-pub-1856399869516725~3014447510  ca-app-pub-1856399869516725~4877908114
        //ca-app-pub-1856399869516725/3748944684  ca-app-pub-1856399869516725/6501980977

    }
    private void FixedUpdate()
    {
        if (start) Intro.color = new Color(ij+=0.001f, ij += 0.001f, ij += 0.001f);
        if (ij >1)
        {
            start = false;
            GameObject.Destroy(Intro.gameObject);
            ij = 0;
        }
    }
    // Update is called once per frame
    void Update()
    {
        if (Music.isOn) Cave.volume = 1f; else Cave.volume = 0;
    }
    public void Out() { Application.Quit(); }
    public void Play() { Menu1.position = new Vector3(-14.445f, -0.64f); }
    public void Setting()
    {
        Menu1.position = new Vector3(14.445f,-0.64f);
        string[] Set = {"1","2","3","4","5" };
        slider1.value = PlayerPrefs.GetFloat(Set[0],1);
        slider2.value = PlayerPrefs.GetFloat(Set[1], 1);
        slider3.value = PlayerPrefs.GetFloat(Set[2], 1); 
        Sound.isOn  = System.Convert.ToBoolean( PlayerPrefs.GetFloat(Set[3], 1)); 
        Music.isOn = System.Convert.ToBoolean(PlayerPrefs.GetFloat(Set[4], 1)); 

    }
    public void Back()
    {
        Menu1.position = new Vector3(0, -0.64f);
        string[] Set = { "1", "2", "3", "4", "5" };
        PlayerPrefs.SetFloat(Set[0],slider1.value);
        PlayerPrefs.SetFloat(Set[1], slider2.value);
        PlayerPrefs.SetFloat(Set[2], slider3.value);
        PlayerPrefs.SetFloat(Set[3],System.Convert.ToInt32( Sound.isOn));
        PlayerPrefs.SetFloat(Set[4], System.Convert.ToInt32( Music.isOn));
        PlayerPrefs.Save();
    }
    public void NewGame()
    {
        GameObject.Instantiate<GameObject>(Loading);
        Data();
        Application.LoadLevel(1);
    }
    public void LoadGame()
    {
        GameObject.Instantiate<GameObject>(Loading);
        if (!PlayerPrefs.HasKey("Data0"))
        {
            Data();
            Application.LoadLevel(1);
        }
        else
        {
            Application.LoadLevel(2);
        }
    }
    public void Data()
    {
        int[] what_in_chase = new int[34];
        int i=0, q=0, i1=0, i2=0, i3=0, i4=0;
        string[] data = new string[51];
        for (i = 0; i < 51; ++i) { data[i] = "Data" + i; }
        int[] GD = new int[51];
        GD[0]=91;
        GD[1] = -7;
        GD[2] = (3);
        GD[3] = (0);
        GD[4] = (1);
        for (i = 0; i < 8; ++i) { GD[5+i] = (0); }
        for (i = 0; i < 4; ++i) { GD[13+i] = (0); }
        //заполнение сундуков вещами
        for (i = 0; i < 34; ++i) what_in_chase[i] = 1;
        for (q = 0;q< 3; ++q)
        {
            i= 0;
            while ((i == 0) || (i == 9) || (i == 19) || (i == i1) || (i == i2) || (i == i3)) { i = Random.Range(0, 34); if (!((i == 0) || (i == 9) || (i == 19) || (i == i1) || (i == i2) || (i == i3))) {what_in_chase[i] = 5; } }
            if (q == 0) i1 = i;
            if (q == 1) i2 = i;
            if (q == 2) i3= i;
        }
        what_in_chase[9] = 2;
        what_in_chase[19] = 5;
        i= 0;
        while ((i == 0) || (i == 9) || (i == 19) || (i == i1) || (i == i2) || (i == i3)) { i = Random.Range(0, 34); if (!((i == 0) ||(i == 9) ||(i == 19) ||(i == i1) ||(i == i2) ||(i == i3))) { what_in_chase[i] = 4; } }
        i4 = i;
        i= 0;
        while ((i == 0) || (i == 9) || (i == 19) || (i == i1) || (i == i2) || (i == i3) || (i == i4)) { i = Random.Range(0, 34); if (!((i == 0) || (i == 9) || (i == 19) || (i == i1) || (i == i2) || (i == i3) || (i == i4))) { what_in_chase[i] = 3; } }
        ////
        for (i = 0; i < 34; ++i) { GD[17+i] = (what_in_chase[i]); }

        for (i = 0; i < 51; ++i) { PlayerPrefs.SetFloat(data[i],GD[i]); }
        PlayerPrefs.SetFloat("6", System.Convert.ToInt32(false));
        PlayerPrefs.Save();
        //GD.WriteLine();
    }
}
