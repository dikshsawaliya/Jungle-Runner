using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleTouching : MonoBehaviour
{
    private void OnCollisionEnter (Collision col)
    {
        if(col.gameObject.tag == "Player")
        {
            col.gameObject.GetComponent<PlayerController>().enabled = false;
        }
    }
}
