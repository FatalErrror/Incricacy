using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CHpos : MonoBehaviour
{
    public Transform[] c = new Transform[8];
    public Transform Canvas;
    public RectTransform Completed;
    public Vector3 vector;
    int time,t, Value1, Value2, Value3;
    bool f;
    public bool II = true;
    // Start is called before the first frame update
    void Start()
    {
      spin(0);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void FixedUpdate() //50 - 0.86 / 25 - 1.72
    {
        if (f)
        {
            c[Value1].localPosition = new Vector3(c[Value1].localPosition.x, c[Value1].localPosition.y - 1.72f);
            if (c[Value1].localPosition.y < -343) c[Value1].localPosition = new Vector3(c[Value1].localPosition.x, 42);
            c[Value2].localPosition = new Vector3(c[Value2].localPosition.x, c[Value2].localPosition.y - 1.72f);
            if (c[Value2].localPosition.y < -343) c[Value2].localPosition = new Vector3(c[Value2].localPosition.x, 42);
            //c[Value3].localPosition = new Vector3(c[Value3].localPosition.x, c[Value3].localPosition.y - 1.72f);
            //if (c[Value3].localPosition.y < -343) c[Value3].localPosition = new Vector3(c[Value3].localPosition.x, 42);
            ++time; if (time > 24)
            {
                time = 0;
                f = false;
                c[Value1].localPosition = new Vector3(c[Value1].localPosition.x,Mathf.CeilToInt( c[Value1].localPosition.y));
                c[Value2].localPosition = new Vector3(c[Value2].localPosition.x, Mathf.CeilToInt(c[Value2].localPosition.y));
               // c[Value3].localPosition = new Vector3(c[Value3].localPosition.x, Mathf.CeilToInt(c[Value3].localPosition.y));
                if (++t < 10) spin(Random.Range(0,8));
            }
        }

        if (c[0].localPosition.y == -152 && c[1].localPosition.y == -152 && c[2].localPosition.y == -152 && c[3].localPosition.y == -152 && c[4].localPosition.y == -152 && c[5].localPosition.y == -152 && c[6].localPosition.y == -152 && c[7].localPosition.y == -152) Completed.position = new Vector3(0, 0, 0);
    
    }
    public void spin(int value)
    {
        if (time == 0)
        {
            Value1 = value;
           // if (value + 2 > 7) { Value2 = value - 6; }
           // else { Value2 = value + 2;  }
            if (value + 5 > 7) { Value2 = value - 3; }
            else { Value2 = value + 5;  }
            f = true;
        }
    }
}
