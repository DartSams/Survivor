using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gunScript : MonoBehaviour
{
    public GameObject bullet;
    public GameObject gunBarrell;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void shoot()
    {
        GameObject b = Instantiate(bullet, gunBarrell.transform.position, gunBarrell.transform.rotation);
    }
}
