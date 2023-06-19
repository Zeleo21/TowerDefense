using System.Security.Cryptography;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    private Transform target;

    private float speed = 70; // To test

    public GameObject impactEffect;

    // Update is called once per frame
    void Update()
    {
        if (target == null)
        {
            Destroy(gameObject);
            return;
        }

        Vector3 dir = target.position - transform.position;
        float distance = speed * Time.deltaTime;
        if (dir.magnitude <= distance)
        {
            HitTarget();
            return;
        }
        transform.Translate(dir.normalized * distance, Space.World);
    }
    public void Seek(Transform _target)
    {
        target = _target;
    }

    public void HitTarget()
    {
        GameObject particles =  Instantiate(impactEffect, transform.position, transform.rotation);
        Destroy(particles, 2f);
        Destroy(target.gameObject);
        Destroy(gameObject);
    }
}
