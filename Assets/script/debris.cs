using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class debris : MonoBehaviour
{
    public float speed = 1f;
    private float time = 0.0f;
    public GameObject explosions;
    public GameObject fumer;
    public Rigidbody rb;
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.velocity = new Vector3(5, 30, 6);
    }

    // Update is called once per frame
    void Update()
    {
        Instantiate(fumer, transform.position, Quaternion.identity);
        time = time + Time.fixedDeltaTime;
        if (time > 10.0f)
        {
            Instantiate(explosions, transform.position, Quaternion.identity);
            Destroy(gameObject);
            time = 0.0f;
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "destroy")
        {
            Destroy(collision.gameObject);
        }
        Vector3 movement = new Vector3(15, 10, 0);
        //Instantiate(explosions, transform.position, Quaternion.identity);
        if(collision.gameObject.tag == "Ground")
        {
            Instantiate(explosions, transform.position, transform.rotation);
            Destroy(gameObject);
        }
        //Destroy(gameObject);
    }
}
