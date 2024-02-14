using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class canon : MonoBehaviour
{
    [SerializeField] GameObject bulletPrefab;
    [SerializeField] Transform bulletSpawnPoint;
    [SerializeField] float bulletSpeed = 1f;
    [SerializeField] GameObject flash;
    private Animator _animator;
    private void Awake()
    {
        _animator = GetComponent<Animator>();
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            var bullet = Instantiate(bulletPrefab, bulletSpawnPoint.position, bulletSpawnPoint.rotation);
            bullet.GetComponent<Rigidbody>().velocity = bulletSpawnPoint.up*bulletSpeed ;
            Instantiate(flash, bulletSpawnPoint.position, Quaternion.identity);
            _animator.SetBool("trigger", true);
        }
        if (Input.GetKey(KeyCode.Space))
        {
            //Instantiate(flash, bulletSpawnPoint.position, Quaternion.identity);

            _animator.SetBool("trigger", true);
        }
    }
}
