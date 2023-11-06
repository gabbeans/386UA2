using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System;


public class Enemy : MonoBehaviour {
    public static event Action<Enemy> OnEnemyDeath;
    [SerializeField] float health, maxHealth = 3f;

    [SerializeField] FloatingHealthBar healthBar;
    private Rigidbody2D rb;
    private Transform target;

    int expAmount = 100;

    private void Awake()
    {
        rb = this.GetComponent<Rigidbody2D>();
        healthBar = GetComponentInChildren<FloatingHealthBar>();
    }

    private void Start()
    {
        rb = this.GetComponent<Rigidbody2D>();
        health = maxHealth;
        healthBar.UpdateHealthBar(health, maxHealth);
        target = GameObject.Find("Player").transform;
    }

    public void TakeDamage(float damage)
    {
        health -= damage;
        healthBar.UpdateHealthBar(health, maxHealth);
        if (health <= 0)
        {
           Die();
        }
    }

    void Die() {
        ExperienceManager.Instance.AddExperience(expAmount);
        Destroy(gameObject);
    }


    public Transform player;
    public float movespeed = 5f;
    //private Rigidbody2D rb;
    private Vector2 movement;
    // Start is called before the first frame update
    /*void Start()
    {
        rb = this.GetComponent<Rigidbody2D>();
    }*/

    // Update is called once per frame
    void Update()
    {
        Vector3 direction = player.position - transform.position;
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        rb.rotation = angle;
        direction.Normalize();
        movement = direction;
    }
    void FixedUpdate()
    {
        moveEnemy(movement);
    }
    void moveEnemy(Vector2 direction)
    {
        rb.MovePosition((Vector2)transform.position + (direction * movespeed * Time.deltaTime));
    }

    void onCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            Destroy(gameObject);
            SceneManager.LoadScene(2);

        }
    }
}
