using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReactorLevelController : MonoBehaviour
{
    [Header("Room Elements")]
    public GameObject vent;
    public GameObject entranceVent;
    public Light spot1;
    public Light spot2;
    public Light plateLight1;
    public Light plateLight2;
    public PressurePlate plate1;
    public PressurePlate plate2;
    public LightPulse reactor;
    public ButtonController panel1;
    public ButtonController panel2;
    public ButtonController newBox;
    public RayShooting turret1;
    public RayShooting turret2;
    public GameObject box;
    public ActivateComponent newBoxConveyor;

    [Header("Fine Tuning")]
    public float ventPush;

    public float timePaused = 3.0f;

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
            vent.GetComponent<Rigidbody>().AddForce(Vector3.up * ventPush);
            vent.GetComponent<Rigidbody>().AddForce(Vector3.back * ventPush);
            plateLight1.intensity = 3.0f;
            plateLight1.color = Color.red;
            if (plate2.GetState())
            {
                spot1.intensity = 0.0f;
                spot2.intensity = 0.0f;
                plateLight2.intensity = 3.0f;
                plateLight2.color = Color.red;
                reactor.Finale();
                turret1.enabled = false;
                turret2.enabled = false;
                //Voice line
                //Delay
                entranceVent.GetComponent<Rigidbody>().AddForce(Vector3.up * ventPush * 3);
                entranceVent.GetComponent<Rigidbody>().AddForce(Vector3.left * ventPush * 3);

                if(panel1.GetState())
                {
                    if (panel2.GetState())
                    {
                        Debug.Log("congrats");
                    }
                }
            }
            else
            {
                plateLight2.intensity += 0.01f;
            }
        }
        else
        {
            plateLight1.intensity += 0.01f;
        }

        //Generate new cube on button press
        if (newBox.GetState())
        {
            Instantiate(box, gameObject.transform).gameObject.transform.position = newBoxConveyor.gameObject.transform.position + Vector3.up;
            newBox.SetState();
            Debug.Log("box made");
            newBoxConveyor.SetState(true);
            float timeCheck = Time.time;
            if (Time.time > timeCheck + timePaused)
            {
                newBoxConveyor.SetState(false);
            }
        }
    }
}
