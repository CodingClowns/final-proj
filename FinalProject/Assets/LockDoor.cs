using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LockDoor : MonoBehaviour
{
    [SerializeField] BoxCollider2D triggerTrapDoor;
    [SerializeField] Vector3 trapPosition;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            gameObject.transform.position = trapPosition;
        }
    }
}