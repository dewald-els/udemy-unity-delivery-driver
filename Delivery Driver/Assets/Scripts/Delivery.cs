using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Delivery : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision == null) return;

        if (collision.tag == "Package")
        {
            Debug.Log("Package Collected");
        }

        if (collision.tag == "Customer")
        {
            Debug.Log("Delivered Package to customer");
        }
        
    }
}
