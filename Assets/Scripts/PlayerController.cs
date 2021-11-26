using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] float moveSpeed = 5;

    Rigidbody playerRb;

    void Start()
    {
        playerRb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        ProcessMovement();
    }

    void ProcessMovement()
    {
        float moveZ = Input.GetAxis("Horizontal");

        playerRb.position += transform.forward * moveZ * moveSpeed * Time.deltaTime;
    }
}
