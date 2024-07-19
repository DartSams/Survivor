using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyScript : MonoBehaviour
{
    public float moveSpeed = 0.5f;
    playerSctipt ps;
    GameObject player;
    Rigidbody2D rb;
    manager gameManager;

    // Start is called before the first frame update
    void Awake()
    {
        player = GameObject.Find("Player");
        ps = player.GetComponent<playerSctipt>();
        rb = GetComponent<Rigidbody2D>();
        gameManager = GameObject.Find("gameMaster").GetComponent<manager>();
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, player.transform.position, Time.deltaTime * moveSpeed);

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
        gameManager.RemoveEnemyFromList(gameObject);
    }
}
