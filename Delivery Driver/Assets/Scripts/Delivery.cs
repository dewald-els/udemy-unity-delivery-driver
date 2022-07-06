using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Delivery : MonoBehaviour
{
    [SerializeField] Color32 packageCollectedColour;

    private bool hasPackage = false;

    [Header("Components")]
    private SpriteRenderer sprite;

    private void Start()
    {
        sprite = GetComponent<SpriteRenderer>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision == null) return;

        if (collision.tag == "Package" && hasPackage == false)
        {
            Debug.Log("Package Collected");
            hasPackage = true;
            Destroy(collision.gameObject);
            sprite.color = packageCollectedColour;
        }

        if (collision.tag == "Customer" && hasPackage)
        {
            Debug.Log("Delivered Package to customer");
            hasPackage = false;
            Destroy(collision.gameObject);
            sprite.color = new Color(1, 1, 1, 1);
        }
        
    }
}
