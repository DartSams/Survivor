using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class radiusSCript : MonoBehaviour
{
    playerSctipt ps;
    public GameObject player;
    // Start is called before the first frame update
    void Awake()
    {
        ps = player.GetComponent<playerSctipt>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.transform.tag == "coin")
        {
            ps.addCoin();
            Destroy(collision.gameObject);
        }
    }
}
