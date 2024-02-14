using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class charactermouvement : MonoBehaviour
{
    private float speed;
    [SerializeField] private float horizontalSpeed;

    private Vector2 input;
    [SerializeField] Rigidbody rigidbody;
    [SerializeField] Camera cam;
    [SerializeField] int fovValue;
    int aiming = 0;

    public float velocity;

    private void Start()
    {

        rigidbody = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        if (Input.GetKey(KeyCode.Mouse1))
        {
            
            aiming = 1;
        }
        else if (Input.GetKeyUp(KeyCode.Mouse1))
        {

            aiming = 2;
        }

        input = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
    }
    void FixedUpdate()
    {

        Vector3 desireRotationx = new Vector3(0, input.x * horizontalSpeed * Time.deltaTime, 0);
        rigidbody.MoveRotation(rigidbody.rotation * Quaternion.Euler(desireRotationx));

        Vector3 desireRotationy = new Vector3(input.y * horizontalSpeed * Time.deltaTime, 0, 0);
        rigidbody.MoveRotation(rigidbody.rotation * Quaternion.Euler(desireRotationy));


        //Vector3 movement = new Vector3(transform.forward.x * input.y * speed * Time.deltaTime, 0, transform.forward.z * input.y * speed * Time.deltaTime);
        //rigidbody.MovePosition(transform.position + movement);

        if (aiming == 1)
        {
            cam.fieldOfView = Mathf.MoveTowards(cam.fieldOfView, fovValue - fovValue * 40 / 100, 2f);
        }
        else if (aiming == 2)
        {
            cam.fieldOfView = Mathf.MoveTowards(cam.fieldOfView, fovValue, 2f);
            if (cam.fieldOfView == fovValue)
            {
                aiming = 0;
            }
        }
        else
        {
            cam.fieldOfView = Mathf.MoveTowards(cam.fieldOfView, fovValue, 0.5f);
        
        }


        velocity = rigidbody.velocity.y;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.layer == 3)
        {
           
        }
    }
}
