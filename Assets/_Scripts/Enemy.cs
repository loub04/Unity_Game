using UnityEngine;
public class Enemy : MonoBehaviour
{
    [SerializeField]
    private float speed = 1;
    private Rigidbody2D rb2D;
    private Transform playerTransform;
    public bool stopped = false;

    [SerializeField]
    private GameObject deadCrab;

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

    void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Weapon"))
        {
            Instantiate(deadCrab, transform.position, Quaternion.identity);
            Destroy(gameObject);
        }
    }
}
