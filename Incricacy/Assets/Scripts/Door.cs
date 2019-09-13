using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
    public Sprite sprite;
    public GameObject Tabl2;
    Transform Camera,Sector;
    SpriteRenderer Doorr;
    GameObject gameObject,camera;
    BoxCollider2D box;
    Game Player;float Enter;
    // Start is called before the first frame update
    void Start()
    {
        Doorr = GetComponent<SpriteRenderer>();
        box = GetComponent<BoxCollider2D>();
        camera = GameObject.Find("Main Camera");
        
        Camera = camera.GetComponent<Transform>();
        Player = camera.GetComponent<Game>();
        Sector = transform.root;//GetComponent<Transform>();
        if ((Sector.position.y == -112) && (transform.position.y == -110))
        {
            Enter = Player.data[13];
        }
        else
        {
            if ((Sector.position.y == -112) && (transform.position.y == -113))
            {
                Enter = Player.data[14];
            }
            else
            {
                if ((Sector.position.y == -119) && (transform.position.y == -117))
                {
                    Enter = Player.data[15];
                }
                else
                {
                    if ((Sector.position.y == -119) && (transform.position.y == -120))
                    {
                        Enter = Player.data[16];
                    }
                }
            }
        }
        if (Enter == 1) Open();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (Player.key > 0) Open(); else gameObject = GameObject.Instantiate(Tabl2, Camera);
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        
        GameObject.Destroy(gameObject);
    }
    public void Open()
    {
        if ((Sector.position.y == -112) && (transform.position.y == -110))
        {
            Player.data[13]=1;
        }
        else
        {
            if ((Sector.position.y == -112) && (transform.position.y == -113))
            {
                Player.data[14]=1;
            }
            else
            {
                if ((Sector.position.y == -119) && (transform.position.y == -117))
                {
                    Player.data[15]=1;
                }
                else
                {
                    if ((Sector.position.y == -119) && (transform.position.y == -120))
                    {
                        Player.data[16]=1;
                    }
                }
            }
        }
        Doorr.sprite = sprite;
        transform.Translate(0,-0.3f,0);
        box.isTrigger = true;
        if (Enter == 0) Player.CHkey(-1);
    }
}
