using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chase : MonoBehaviour
{
    public Sprite sprite;
    public GameObject Tabl2;
    Transform Camera, Sector;
    SpriteRenderer Doorr;
    GameObject gameObject, camera;
    Game Player;
    float Enter;
    bool In;
    // Start is called before the first frame update
    void Start()
    {
        Doorr = GetComponent<SpriteRenderer>();
        camera = GameObject.Find("Main Camera");
        Camera = camera.GetComponent<Transform>();
        Player = camera.GetComponent<Game>();
        Sector = transform.root;
        if (Player.data[16 + Player.where_chase[Mathf.CeilToInt(Sector.position.x / 7), -(Mathf.CeilToInt(Sector.position.y / 7))]] == 0) {  In = true;OnMouseUp(); }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (Enter == 0)
        { gameObject = GameObject.Instantiate(Tabl2, Camera);In = true; }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (Enter == 0)
        { GameObject.Destroy(gameObject); In = false;}
    }
    private void OnMouseUp()
    {
        if (In)
        {
            Doorr.sprite = sprite;
            if (Enter == 0)
            {
                Player.In_Inventory(Player.data[16 + Player.where_chase[Mathf.CeilToInt(Sector.position.x / 7), -(Mathf.CeilToInt(Sector.position.y / 7))]]);
                Player.data[16 + Player.where_chase[Mathf.CeilToInt(Sector.position.x / 7), -(Mathf.CeilToInt(Sector.position.y / 7))]] = 0;
                GameObject.Destroy(gameObject);
            }
            Enter = 1;
        }
    }
}
