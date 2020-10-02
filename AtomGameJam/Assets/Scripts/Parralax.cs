using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Parralax : MonoBehaviour
{
    private float _length, _startPosition;
    [SerializeField] private GameObject cam;
    [SerializeField] private float parralaxEffect;

    private void Awake()
    {
        _length = GetComponent<SpriteRenderer>().bounds.size.x;
    }

    void Start()
    {
        _startPosition = transform.position.x;
    }

    void Update()
    {
        float temp = (cam.transform.position.x * (1 - parralaxEffect));
        float distance = (cam.transform.position.x * parralaxEffect);

        transform.position = new Vector3(_startPosition + distance, transform.position.y, transform.position.z);

        if (temp > _startPosition + _length)
        {
            _startPosition += _length;
        }
        else if (temp < _startPosition - _length)
        {
            _startPosition -= _length;
        }
    }
}