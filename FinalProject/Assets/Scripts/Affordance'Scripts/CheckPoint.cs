using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckPoint : MonoBehaviour
{
    [SerializeField] GameObject Player;
    [SerializeField] List<GameObject> Checkpoints;
    [SerializeField] Vector3 VectorPoints;
    [SerializeField] float killzonepos;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Player.transform.position.y < -killzonepos)
        {
            Player.transform.position = VectorPoints;
        }

    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("CheckPoint"))
        {
            VectorPoints = Player.transform.position;
            Destroy(collision.gameObject);
        }
    }
}
