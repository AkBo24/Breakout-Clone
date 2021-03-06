﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{

    private float speed;
    Rigidbody rigidbodyComponent;
    Vector3 velocity;
    Renderer ballRender;

    // Start is called before the first frame update
    void Start()
    {
        speed = 20f;
        rigidbodyComponent = GetComponent<Rigidbody>();
        Invoke("Launch", 0.5f);
        ballRender = GetComponent<Renderer>();
    }

    void Launch() {
        rigidbodyComponent.velocity = Vector3.up * speed;
    }

    // FixedUpdate is called once per phisycs update
    void FixedUpdate()
    {
        rigidbodyComponent.velocity = rigidbodyComponent.velocity.normalized * speed;
        velocity = rigidbodyComponent.velocity;

        if(!ballRender.isVisible) {
            GameManager.Instance.Balls--;
            Destroy(gameObject);
        }
    }

    private void OnCollisionEnter(Collision collision) {
        rigidbodyComponent.velocity = Vector3.Reflect(velocity, collision.contacts[0].normal);
    }
}
