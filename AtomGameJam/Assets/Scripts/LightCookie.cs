using System;
using UnityEngine;
using UnityEngine.Experimental.Rendering.Universal;

public class LightCookie : MonoBehaviour
{
    [SerializeField] private GameObject player;
    private Light2D _light;
    private float _targetIntensity;

    [Header("Intensity Change Settings")]
    
    [Range(0, 1)] [SerializeField] private float lerpAmount = 0.05f;

    [Range(0, 3)] [SerializeField] private float lightIntensityStart = 0.01f;

    [Range(0, 30)] [SerializeField] private float lightIntensityEnd = 0.02f;

    private void Awake()
    {
        _light = gameObject.GetComponent<Light2D>();
    }

    void LateUpdate()
    {
        gameObject.transform.position = player.transform.position;
    }

    private void FixedUpdate()
    {
        ChangeIntensity();
    }

    private void ChangeIntensity()
    {
        if (_light.intensity >= (lightIntensityEnd - 0.01))
        {
            _targetIntensity = lightIntensityStart;
        }
        else if (_light.intensity <= (lightIntensityStart + 0.01))
        {
            _targetIntensity = lightIntensityEnd;
        }

        _light.intensity = Mathf.Lerp(_light.intensity, _targetIntensity, lerpAmount * Time.deltaTime * 100f);
    }
}