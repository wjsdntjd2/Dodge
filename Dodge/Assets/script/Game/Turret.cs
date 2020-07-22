using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Turret : MonoBehaviour
{
    public Transform Body;
    public Transform Target;
    public Transform muzzel;
    public GameObject Bullet;
    public Transform m_bulletParent;
    public AudioSource ShotSound;

    public float Dmg;
    public float StartShooTime;

    bool Start;

    public IEnumerator Shoot(float s)
    {
        while(Start)
        {
            float Rand = Random.Range(0.1f, 2f) + s;
            GameObject go = Instantiate(Bullet, muzzel);
            go.transform.parent = m_bulletParent;
            ShotSound.Play();
            yield return new WaitForSeconds(Rand);
        }
    }

    public void Init()
    {
        Start = false;
    }

    private void Update()
    {
        LookTarget();
    }

    void LookTarget()
    {
        Vector3 dir = Target.transform.position - Body.position;
        dir = new Vector3(dir.x, 0, dir.z);
        Quaternion rot = Quaternion.LookRotation(dir);
        Body.rotation = Quaternion.Lerp(Body.rotation, rot, 0.15f);
    }

    public void BulletShoot()
    {
        Start = true;
        StartCoroutine(Shoot(StartShooTime));
    }
}
