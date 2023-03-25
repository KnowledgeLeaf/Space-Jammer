using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Magnet : MonoBehaviour
{
    private int m_magnetSpeed = 2;

    private void OnTriggerStay2D(Collider2D other)
    {
        if(other.tag == "Pickup")
        {
            Vector2 targetDirection = (gameObject.transform.position - other.transform.position).normalized;
            other.attachedRigidbody.velocity = new Vector2(targetDirection.x, targetDirection.y) * m_magnetSpeed;
        }
    }
}
