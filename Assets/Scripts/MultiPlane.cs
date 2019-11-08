using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MultiPlane : MonoBehaviour
{
    [SerializeField] GameObject GO1;
    [SerializeField] GameObject GO2;
    [SerializeField] GameObject GO3;
    [SerializeField] GameObject GO4;
    private bool GO1Listner;
    private bool GO2Listner;
    private bool GO3Listner;
    private bool shouldOpen = true;
    // Update is called once per frame
    void Update()
    {
        GO1Listner = GO1.GetComponent<ActivateComponent>().GetState();
        GO2Listner = GO2.GetComponent<ActivateComponent>().GetState();
        GO3Listner = GO3.GetComponent<ActivateComponent>().GetState();
        if (GO1Listner && GO2Listner)
        {
            StartCoroutine(OpenEvent());
           
        }
        else
        {
            
            GO4.GetComponent<DoorActivator>().SetState(false);
        }
    }

    private IEnumerator OpenEvent()
    {
        if (shouldOpen)
        {
            GO4.GetComponent<DoorActivator>().SetState(true);
            shouldOpen = false;
            yield return new WaitForSeconds(15.0f);
            shouldOpen = true;
        }
    }
}