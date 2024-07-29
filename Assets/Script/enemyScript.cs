using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyScript : MonoBehaviour
{
    float moveSpeed = 0.5f;
    playerSctipt ps;
    GameObject player;
    Rigidbody2D rb;
    manager gameManager;
    Animator anim;
    SpriteRenderer sr;
    public float currentHealth;
    public float maxHealth;
    public GameObject bloodSplatter;
    public GameObject loot;


    // Start is called before the first frame update
    void Awake()
    {
        player = GameObject.Find("Player");
        sr = GetComponent<SpriteRenderer>();
        ps = player.GetComponent<playerSctipt>();
        rb = GetComponent<Rigidbody2D>();
        gameManager = GameObject.Find("gameMaster").GetComponent<manager>();
        currentHealth = maxHealth;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, player.transform.position, Time.deltaTime * moveSpeed);
        changeDirection();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.transform.tag == "player")
        {
            ps.loseHealth();
        }
    }

    void OnDestroy()
    {
        Debug.Log("Enemy died");
        gameManager.RemoveEnemyFromList(gameObject);
        
    }

    public void addHealth()
    {
        currentHealth += 1;
    }

    public void loseHealth(int damage)
    {
        currentHealth -= damage;
        if (currentHealth <= 0)
        {
            Destroy(gameObject);
            Instantiate(bloodSplatter, transform.position, transform.rotation);
            Instantiate(loot, transform.position, transform.rotation);
        }
    }

    public void upgradeHealth()
    {
        maxHealth += 2.5f;
    }

    void changeDirection()
    {
        if (transform.position.x > player.transform.position.x)
        {
            sr.flipX = false;
        } else
        {
            sr.flipX = true;
        }
        
    }
}
