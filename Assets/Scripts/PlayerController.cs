using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public GameObject laserShot;
    public Transform shotSpawn;
    public float fireRate = 0.5f;
    private float nextFire = 0.0f;
   
    Rigidbody rb;
    public float tilt = 2f;
    public float speed = 10f;
    private float xMin = -9f;
    private float xMax = 9f;
    private float zMin =-1.2f;
    private float zMax = 30f;


    public AudioClip laserShotClip;
    public AudioClip turboSound;
    AudioSource audioS;
    public void Start()
    {
        rb = GetComponent<Rigidbody>();
        audioS = GetComponent<AudioSource>();
    }
    public void Update()
    {
        if (Input.GetButton("Fire1") && Time.time > nextFire)
        {
            nextFire = Time.time + fireRate;
            Instantiate(laserShot, shotSpawn.position, shotSpawn.rotation);
            audioS.clip = laserShotClip;
            audioS.Play();
        }
        
    }
    private void FixedUpdate()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical);
        rb.velocity = movement * speed;
        rb.position = new Vector3(Mathf.Clamp(rb.position.x,xMin, xMax), 0.0f, Mathf.Clamp(rb.position.z, zMin, zMax));
        rb.rotation = Quaternion.Euler(0.0f ,180f , rb.velocity.x * tilt);
    }
    
}
