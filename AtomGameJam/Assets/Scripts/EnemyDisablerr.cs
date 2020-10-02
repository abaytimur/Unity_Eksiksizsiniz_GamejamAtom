using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDisablerr : MonoBehaviour
{
    private EnemyHealth _eh;
    public GameObject explosionPrefab;
    public Transform explosionTransform;
    private void Start()
    {
        _eh = GetComponentInChildren<EnemyHealth>();
    }

    private void Update()
    {
        if (_eh.currentHealth <= 0)
        {
            Die();
        }
    }

    private void Die()
    {
        
        GameObject exp = Instantiate(explosionPrefab, explosionTransform.position, Quaternion.identity);
        
        Destroy(exp,1f);
        gameObject.SetActive(false);
        Destroy(gameObject, 2f);
    }
}