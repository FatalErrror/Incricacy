using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spin : MonoBehaviour
{
    public Transform s1, s2, s3;
    int time,Value;
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
        if ((time == 0)&&( s1.rotation.z * s1.rotation.z > 0.95) && (s2.rotation.z * s2.rotation.z > 0.95) && (s3.rotation.z * s3.rotation.z > 0.95))
        {
            PlayerPrefs.SetInt("Completed", 1);
            PlayerPrefs.Save();
        }
        switch(Value)
        {
            case 1: ++time; s1.Rotate(0, 0, -1.2f); s3.Rotate(0, 0, -1.2f); if (time > 24) { time = 0; Value = 0; } break;
            case 2: ++time; s1.Rotate(0, 0, -1.2f); s2.Rotate(0, 0, -1.2f); if (time > 24) { time = 0; Value = 0; } break;
            case 3: ++time; s2.Rotate(0, 0, -1.2f); s3.Rotate(0, 0, -1.2f); if (time > 24) { time = 0; Value = 0; } break;
        }
    }
    public void spin(int value)
    {
        if (time == 0) Value = value;
    }
    
    
}
