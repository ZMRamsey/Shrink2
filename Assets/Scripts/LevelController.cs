using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelController : MonoBehaviour
{
    //This script is basically just GlaDos
    public PressurePlate conPlate;
    public PressurePlate winPlate;
    public Conveyor con1;
    public Conveyor con2;
    public Conveyor con3;
    
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if (conPlate.GetState())
        {
            Debug.Log("Firing up conveyors");
            con1.SetActivate(true);
            con2.SetActivate(true);
            con3.SetActivate(true);
        }
        else
        {
            con1.SetActivate(false);
            con2.SetActivate(false);
            con3.SetActivate(false);
        }
        if (winPlate.GetState())
        {
            Debug.Log("YOU WIN");
        }
    }
}
