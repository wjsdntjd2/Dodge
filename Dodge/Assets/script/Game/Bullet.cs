using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    Rigidbody rb;
    public Transform test;
    public float BulletSpeed;
    private void Start()
    {
        Destroy(gameObject, 5.0f);

        Init();
    }

    void Init()
    {
        //transform.SetParent(null);
        //Invoke("DestoryBullet", 5.0f);
        rb = GetComponent<Rigidbody>();
        rb.AddForce(transform.forward * BulletSpeed);
    }

    void DestoryBullet()
    {
        Destroy(gameObject);
    }
}
