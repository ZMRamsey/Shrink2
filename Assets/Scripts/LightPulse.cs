using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightPulse : MonoBehaviour
{
    public float duration;

    bool finale = false;

    Light lt;

    // Start is called before the first frame update
    void Start()
    {
        lt = GetComponent<Light>();
    }

    public void Finale()
    {
        lt.intensity = 10.0f;
        lt.color = Color.red;
    }

    // Update is called once per frame
    void Update()
    {
        if (!finale)
        {
            float t = Mathf.PingPong(Time.time, duration) / duration;
            lt.color = Color.Lerp(Color.magenta, Color.blue, t);
        }
    }
}
