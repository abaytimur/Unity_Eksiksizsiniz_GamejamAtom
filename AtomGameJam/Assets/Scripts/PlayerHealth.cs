using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.Rendering.Universal;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField] private Light2D light2D;
    [SerializeField] Color first, second, last;
    [SerializeField] private Animator animator;
    private Rigidbody2D _rb;
    public int maxHealth = 100;
    public float currentHealth;
    public int pointIncreasedPerSecond = 2;
    private bool _faceR = true;
    public HealthBar healthBar;
   
    private static readonly int Hurt = Animator.StringToHash("Hurt");
    private static readonly int IsJumping = Animator.StringToHash("IsJumping");
    private static readonly int IsCrouching = Animator.StringToHash("IsCrouching");
    private static readonly int IsShooting = Animator.StringToHash("IsShooting");
    private static readonly int Speed = Animator.StringToHash("Speed");

    private void Awake()
    {
        _rb = GetComponent<Rigidbody2D>();
    }

    void Start()
    {
        _faceR = true;
        currentHealth = maxHealth;
        healthBar.SetMaxHealth(maxHealth);
    }

    void Update()
    {
        DamageTakenKnockback();

        // // BUNU KALDIR
        // if (Input.GetKeyDown(KeyCode.Y))
        // {
        //     TakeDamage();
        // }

        HealOverTime();
        
        HealthColors();
    }

    private void HealthColors()
    {
        if (currentHealth <= 60 && currentHealth > 40)
        {
            light2D.color = Color.Lerp(light2D.color, first, Mathf.PingPong(Time.time, .1f));
        }

        if (currentHealth <= 40 && currentHealth > 20)
        {
            light2D.color = Color.Lerp(light2D.color, second, Mathf.PingPong(Time.time, .1f));
        }

        if (currentHealth <= 20)
        {
            light2D.color = Color.Lerp(light2D.color, last, Mathf.PingPong(Time.time, .1f));
        }

        if (currentHealth <= 0)
        {
            gameObject.SetActive(false);
            transform.position = new Vector2(transform.position.x-10, transform.position.y +10);
            gameObject.SetActive(true);
            light2D.color = Color.white;

            // animator.SetBool(IsJumping, false);
            // animator.SetBool(IsCrouching,false);
            // animator.SetBool(IsShooting,false);
            // animator.SetFloat(Speed, 0f);
            
            currentHealth = 100f;
            // KARAKTERI YAKIN BIR YERDE RESPAWNLA
            // rengi orjinal haline getir
        }
    }

    private void DamageTakenKnockback()
    {
        if (Input.GetAxisRaw("Horizontal") == 1)
        {
            _faceR = true;
        }
        else if (Input.GetAxisRaw("Horizontal") == -1)
        {
            _faceR = false;
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Enemy"))
        {
            if (_faceR)
            {
                _rb.AddForce(Vector2.right * -50f, ForceMode2D.Impulse);
                TakeDamage();
            }

            if (!_faceR)
            {
                _rb.AddForce(Vector2.left * -50f, ForceMode2D.Impulse);
                TakeDamage();
            }
        }
    }


    public void HealOverTime()
    {
        currentHealth += pointIncreasedPerSecond * Time.deltaTime;
        if (currentHealth > 100)
        {
            currentHealth = 100f;
        }

        if (currentHealth < 0)
        {
            currentHealth = 0f;
        }

        healthBar.SetHealth(currentHealth);
    }

    public void TakeDamage()
    {
        // SES EKLE
        animator.SetTrigger(Hurt);

        currentHealth -= 10;
        healthBar.SetHealth(currentHealth);
    }
}