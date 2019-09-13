using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndAnimate : MonoBehaviour
{
    public int timer= 300;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void FixedUpdate()
    {
        if (--timer <= 0) { Application.LoadLevel(0); } 
    }
}
