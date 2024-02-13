using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class bullet : MonoBehaviour
{
    public float life = 100f;
    public GameObject explosions;
    public GameObject fumer;
    // Start is called before the first frame update
    void Awake()
    {
        //Destroy(gameObject, life);
    }

    private void Update()
    {
        Instantiate(fumer, transform.position, Quaternion.identity);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "destroy") 
        {
            Destroy(collision.gameObject);
        }
        Instantiate(explosions,transform.position,Quaternion.identity);
        Destroy(gameObject);
    }
}
