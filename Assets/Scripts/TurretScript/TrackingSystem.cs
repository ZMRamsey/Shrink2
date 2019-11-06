using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Used for tracking the Target.
public class TrackingSystem : MonoBehaviour
{

    public float speed = 3.0f;
    public GameObject m_target = null;
    Vector3 m_lastKnowPosition = Vector3.zero;
    Quaternion m_lookAtRotation;

    // Update is called once per frame
    void Update()
    {
        if (m_target)
        {
            if (m_lastKnowPosition != m_target.transform.position)
            {
                m_lastKnowPosition = m_target.transform.position;
                m_lookAtRotation = Quaternion.LookRotation(m_lastKnowPosition - transform.position);
            }

            if (transform.rotation != m_lookAtRotation)
            {
                transform.rotation = Quaternion.RotateTowards(transform.rotation, m_lookAtRotation, speed * Time.deltaTime);
               
            }
        }
    }

    bool SetTarget(GameObject target)
    {
        if (target)
        {
            return false;
        }

        m_target = target;

        return true;
    }
}
