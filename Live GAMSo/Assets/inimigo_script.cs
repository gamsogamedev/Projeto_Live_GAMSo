using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class inimigo_script : MonoBehaviour
{

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "Player")
        {
            other.GetComponent<movimento>().HP -= 10;
            Debug.Log("perdeu vida " + other.GetComponent<movimento>().HP);
        }
    }

}
