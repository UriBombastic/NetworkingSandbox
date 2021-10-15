using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;

public class SlashBro : NetworkBehaviour
{
    public float moveSpeed = 100;
    public float rotateSpeed = 100;
    public GameObject sword;
    public GameObject eyes;
    public Transform respawnPoint;
    public float respawnRange = 0;
    private Rigidbody rb;
    [SerializeField]
    private GameObject playerCamera;
    [SerializeField]
    private AudioSource aud;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
        aud = GetComponent<AudioSource>();
    }

    private void Start()
    {
        eyes.SetActive(isLocalPlayer);
    }

    private void FixedUpdate()
    {
        if (isLocalPlayer)
            MovePlayer();
    }

    private void MovePlayer()
    {
        rb.velocity = transform.forward * Input.GetAxisRaw("Vertical") * moveSpeed * Time.fixedDeltaTime;
       float rotation = Input.GetAxisRaw("Horizontal") * rotateSpeed;
        transform.Rotate(0, rotation, 0);
    }

    public void Die()
    {
        aud.Play();
        Respawn();
    }

    public void Respawn()
    {
        Vector3 pointToSpawn = new Vector3(
            respawnPoint.position.x + Random.Range(-respawnRange, respawnRange),
            respawnPoint.position.y,
            respawnPoint.position.z + Random.Range(-respawnRange, respawnRange));

        transform.position = pointToSpawn;
    }
}
