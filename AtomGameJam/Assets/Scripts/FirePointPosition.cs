using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FirePointPosition : MonoBehaviour
{
    [SerializeField] private BoxCollider2D boxCollider2D;
    [SerializeField] private GameObject crouchPos, runPos, shootPos;
    [SerializeField] private Animator animator;
    
    private static readonly int IsShooting = Animator.StringToHash("IsShooting");
    private static readonly int Speed = Animator.StringToHash("Speed");
    private static readonly int IsCrouching = Animator.StringToHash("IsCrouching");

    private void Start()
    {
        gameObject.transform.position = shootPos.transform.position;
    }

    void Update()
    {
        if (animator.GetBool(IsShooting) && animator.GetFloat(Speed) > 0.01f)
        {
            gameObject.transform.position = runPos.transform.position;
        }

        if (animator.GetBool(IsShooting) && animator.GetFloat(Speed) <= 0.01f)
        {
            gameObject.transform.position = shootPos.transform.position;
        }

        if (animator.GetBool(IsCrouching))
        {
            gameObject.transform.position = crouchPos.transform.position;
        }
    }
}