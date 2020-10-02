using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class Bullet : MonoBehaviour
{
    [SerializeField] private float speed = 20f;
    private Rigidbody2D _rb;
    [SerializeField] private GameObject hitEffectPrefab;

    private void Awake()
    {
        _rb = gameObject.GetComponent<Rigidbody2D>();
    }

    void Start()
    {
        _rb.velocity = transform.right * speed;

        Destroy(gameObject, 3f);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        Instantiate(hitEffectPrefab, transform.position, Quaternion.Euler(0f, 0f, Random.Range(0f, 360f)));
        if (other.gameObject.CompareTag("Enemy"))
        {
            var hb = other.gameObject.GetComponent<EnemyHealth>();
            hb.TakeDamage();
        }
        Destroy(gameObject);
    }
}