using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class itemPickupScript : MonoBehaviour
{
    public BoxCollider2D playerRadius;
    // Start is called before the first frame update
    void Awake()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.transform.name == "magnet")
        {
            //increase radius
            playerRadius.edgeRadius += 0.5f;
            Destroy(collision.gameObject);
        }
    }
}
