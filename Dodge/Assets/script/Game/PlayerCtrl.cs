using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCtrl : MonoBehaviour
{
    public float speed;
    [HideInInspector] public bool Death;
    Rigidbody rb;
    public ParticleSystem DeathEffect;
    public AudioSource DeathSound;

    public void Init()
    {
        rb = GetComponent<Rigidbody>();
        transform.position = new Vector3(0, transform.position.y, 0);
        Death = false;
    }

    private void Start()
    {
        Init();
    }

    private void FixedUpdate()
    {
        if (!Death)
        {
            PlayerMove();
        }
    }

    void PlayerMove()
    {
        float hor = Input.GetAxis("Horizontal");
        float ver = Input.GetAxis("Vertical");

        Vector3 playerMove = new Vector3(hor, 0, ver) * speed;
        rb.velocity = playerMove;

        if (hor > 0.2f)
            transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.Euler(0, 90, 0), 0.1f);
        if (hor < -0.2f)
            transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.Euler(0, -90, 0), 0.1f);
        if (ver > 0.2f)
            transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.Euler(0, 0, 0), 0.1f);
        if (ver < -0.2f)
            transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.Euler(0, 180, 0), 0.1f);
    }

    void Die()
    {
        Death = true;
        DeathEffect.Play();
        rb.velocity = Vector3.zero;
        DeathSound.Play();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Bullet"))
        {
            Destroy(other.gameObject);
            if (!Death)
            {
                Die();
                StopAllCoroutines();
                Mng.Ins.GameScene.Battle1.SetResult();
            }
        }
    }
}
