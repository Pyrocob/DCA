using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.Windows;

public class bullet : MonoBehaviour
{
    public float life = 100f;
    public GameObject explosions;
    public GameObject fumer;
    public GameObject debris;
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
        Vector3 movement = new Vector3(0, 1, 0);
        Instantiate(explosions,transform.position,Quaternion.identity);
        Instantiate(debris,transform.position+movement, Quaternion.identity);
        Instantiate(debris, transform.position + movement, Quaternion.identity);
        Instantiate(debris, transform.position + movement, Quaternion.identity);
        Instantiate(debris, transform.position + movement, Quaternion.identity);
        Destroy(gameObject);
    }
}
