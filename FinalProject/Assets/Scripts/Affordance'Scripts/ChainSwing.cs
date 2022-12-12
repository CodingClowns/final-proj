using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChainSwing : MonoBehaviour
{
    [SerializeField] Rigidbody2D rigidbody2D;

    [SerializeField] private float SwingSpeed;
    [SerializeField] private float leftAngle;
    [SerializeField] private float rightAngle;

    bool movingClockwise;
    // Start is called before the first frame update
    void Start()
    {
        movingClockwise = true; 
    }
    

    // Update is called once per frame
    void Update()
    {
        changeDiretion();
        Swing();
    }

    public void changeDiretion()
    {
        if (transform.rotation.z>rightAngle)
        {
            movingClockwise = false;
        }
        if (transform.rotation.z<leftAngle)
        {
            movingClockwise = true;
        }
    }
    public void Swing()
    {
        if (movingClockwise)
        {
            rigidbody2D.angularVelocity = SwingSpeed;
        }
        if (!movingClockwise)
        {
            rigidbody2D.angularVelocity = -1 * SwingSpeed;
        }
    }

}
