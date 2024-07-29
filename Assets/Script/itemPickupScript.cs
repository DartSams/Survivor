using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class itemPickupScript : MonoBehaviour
{
    public BoxCollider2D playerRadius;
    playerSctipt pc;
    // Start is called before the first frame update
    void Awake()
    {
        pc = GetComponent<playerSctipt>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        Destroy(collision.gameObject);
        if (collision.transform.name == "magnet")
        {
            //increase radius
            playerRadius.edgeRadius += 0.5f;
        }
        if (collision.transform.name == "sprint boost")
        {
            pc.moveSpeed += 1;
        }
        
    }
}
