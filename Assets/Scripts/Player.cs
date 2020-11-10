using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{

    Rigidbody playerRigidBody;

    // Start is called before the first frame update
    void Start()
    {
        playerRigidBody = GetComponent<Rigidbody>();
    }

    void FixedUpdate()
    {
        float xPos = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, 0, -50)).x;
        playerRigidBody.MovePosition(new Vector3(xPos, -18, 0));
    }
}
