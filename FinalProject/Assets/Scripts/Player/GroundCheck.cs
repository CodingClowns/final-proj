using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundCheck : MonoBehaviour
{
    [SerializeField] PlayerMovement pm;
    [SerializeField] GameObject player;
    // Start is called before the first frame update
    void Start()
    {
    }
    // Update is called once per frame
    void Update()
    {

    }
    // GroundCheck
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Platform")
        {
                Debug.Log("Player jumpable");
                pm.IsOnGround();
        }
    }
}
