using System;
using UnityEngine;
public class Enemy : MonoBehaviour
{
    [SerializeField]
    private float basespeed = 1;
    private float speed;
    private Rigidbody2D rb2D;
    private Transform playerTransform;
    public bool stopped = false;

    [SerializeField]
    private GameObject deadCrab;

    public event Action OnDie = null;
    public static event Action OnAnyDie;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb2D = GetComponent<Rigidbody2D>();
        Player player = FindAnyObjectByType<Player>();
        if(player != null)
        {
            playerTransform = player.transform;
        }
        else
        {
            stopped = true;
        }
    }

    // Update is called once per frame
    void Update()
    {
        Move();
    }

    private void Move()
    {
        if(stopped || playerTransform == null)
        {
            rb2D.linearVelocity = Vector3.zero;
            return;
        }
        Vector3 directionToPlayer = playerTransform.position - transform.position;
        rb2D.linearVelocity = directionToPlayer.normalized * speed;
    }

    [Obsolete]
    void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Weapon"))
        {
            Instantiate(deadCrab, transform.position, Quaternion.identity);
            GameManager.Instance.increaseKilled();
            FindObjectOfType<EnemyController>().DeregisterEnemy(gameObject);
            Destroy(gameObject);
            Debug.Log(speed);
            if(OnDie != null)
            {
                OnAnyDie();
                OnDie();
            }
        }
    }
    public void IncreaseSpeed(float multiplier)
    {
        speed = basespeed * multiplier;
    }
    public void DecreaseSpeed(float multiplier)
    {
        speed = basespeed * multiplier;
    }
}
