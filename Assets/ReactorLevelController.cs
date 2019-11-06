using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReactorLevelController : MonoBehaviour
{
    public GameObject vent;
    public Light spot1;
    public Light spot2;
    public PressurePlate plate1;
    public PressurePlate plate2;
    public LightPulse reactor;

    // Start is called before the first frame update
    void Start()
    {
        spot2.intensity = 0;

    }

    // Update is called once per frame
    void Update()
    {
        if (plate1.GetState())
        {
            spot2.intensity = 4.55f;
            vent.transform.Translate(vent.transform.position + (Vector3.forward * 1.5f));
            if (plate2.GetState())
            {
                spot1.intensity = 0.0f;
                spot2.intensity = 0.0f;
                reactor.Finale();
            }
        }
    }
}
