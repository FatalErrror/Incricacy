using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class End : MonoBehaviour
{
    Transform Botton;
    // Start is called before the first frame update
    void Start()
    {
        Botton = GameObject.Find("GameOver").GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Botton.localPosition = new Vector3(0, 390, 0);
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        Botton.localPosition = new Vector3(0, 1390, 0);
    }
}
