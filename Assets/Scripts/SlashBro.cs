using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;

public class SlashBro : NetworkBehaviour
{
    public float moveSpeed = 100;
    public float rotateSpeed = 100;
    private Rigidbody rb;
    [SerializeField]
    private GameObject playerCamera;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void FixedUpdate()
    {
        //if (isLocalPlayer)
            MovePlayer();
    }

    private void MovePlayer()
    {
        rb.velocity = transform.forward * Input.GetAxisRaw("Vertical") * moveSpeed * Time.fixedDeltaTime;
       float rotation = Input.GetAxisRaw("Horizontal") * rotateSpeed;
        transform.Rotate(0, rotation, 0);
    }
}
