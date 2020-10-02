using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class Weapon : MonoBehaviour
{
    public Transform firePoint;
    public GameObject bulletPrefab;
    private Animator _animator;
    private static readonly int IsShooting = Animator.StringToHash("IsShooting");
    public AudioSource audioSource;
    
    private bool _currentlyFiring;

    public float fireDelta = 0.5F;
    private float _nextFire = 0.5F;
    private float _myTime = 0.0F;
    private float _randomPitch;

    private void Awake()
    {
        _animator = gameObject.GetComponent<Animator>();
    }

    private void Start()
    {
        _currentlyFiring = false;
    }

    private void Update()
    {
        _randomPitch = Random.Range(0.8f, 1.2f);
        if (Input.GetButtonUp("Fire1"))
        {
            _animator.SetBool(IsShooting, false);
        }
    }

    void FixedUpdate()
    {
        _myTime = _myTime + Time.deltaTime;

        if (Input.GetButton("Fire1") && _myTime > _nextFire)
        {
            _nextFire = _myTime + fireDelta;
            Shoot();

            // create code here that animates the newProjectile
            _nextFire = _nextFire - _myTime;
            _myTime = 0.0F;
        }
    }

    private void Shoot()
    {
        audioSource.pitch = _randomPitch;
        audioSource.Play();
        
        CinemachineShake.Instance.ShakeCamera(0.5f, .1f);
        Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
        _animator.SetBool(IsShooting, true);
    }
}