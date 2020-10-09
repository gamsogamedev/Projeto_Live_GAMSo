using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movimento : MonoBehaviour
{

    public int HP = 100;
    public float vel = 1f;

    Rigidbody2D rb2d;

    // Start is called before the first frame update
    void Start()
    {
        rb2d = gameObject.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetAxis("Horizontal") != 0)
        {
            rb2d.velocity = new Vector2(Input.GetAxis("Horizontal")*vel, rb2d.velocity.y);
        }

        if(Input.GetKey(KeyCode.Space))
        {
            rb2d.AddForce(Vector2.up*10f);

        }

        if(HP <= 0)
        {
            Destroy(this.gameObject);
        }

    }
}
