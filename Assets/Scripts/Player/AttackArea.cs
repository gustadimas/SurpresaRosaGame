using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackArea : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.GetComponent<BartPatrol>() != null)
        {
            BartPatrol bart = collider.gameObject.GetComponent<BartPatrol>();
            bart.DestroyBart();
        }

        if (collider.GetComponent<BebumScript>() != null)
        {
            BebumScript bebum = collider.gameObject.GetComponent<BebumScript>();
            bebum.DestroyBebum();
        }

        if (collider.GetComponent<XaigaiChase>() != null)
        {
            XaigaiChase xaiGai = collider.gameObject.GetComponent<XaigaiChase>();
            xaiGai.DestroyXaiGai();
        }
    }
}
