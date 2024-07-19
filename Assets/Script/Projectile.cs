using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    playerSctipt ps;
    // Start is called before the first frame update
    void Start()
    {
        ps = GameObject.Find("Player").GetComponent<playerSctipt>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.transform.tag == "enemy")
        {
            ps.addCoin();
            Destroy(gameObject);
            Destroy(collision.gameObject);
        }
    }
}
