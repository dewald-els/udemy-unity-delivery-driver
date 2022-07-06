using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;

public class Player : MonoBehaviour
{
    [Header("Movement")]
    [SerializeField]
    private float steerSpeed = 1.0f;
    [SerializeField]
    private float moveSpeed = 10.0f;
    private float currentSpeed = 0;
    [SerializeField]
    private float slowSpeed = 5.0f;
    [SerializeField]
    private float boostSpeed = 15.0f;

    // Start is called before the first frame update
    void Start()
    {
        currentSpeed = moveSpeed;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        float steerAmount = Input.GetAxis("Horizontal") * steerSpeed * Time.deltaTime;
        // float moveAmount = Input.GetAxis("Vertical") * moveSpeed * Time.deltaTime;
        float moveAmount = 0f;
        if (Input.GetButton("Fire1"))
        {
            moveAmount = 1f * currentSpeed * Time.deltaTime;
        }
        if (Input.GetButton("Fire2"))
        {
            moveAmount = -1f * currentSpeed * Time.deltaTime;
        }
        
        transform.Rotate(0,0, -steerAmount);
        transform.Translate(0, moveAmount, 0);
    }

    void RestoreSpeed()
    {
        currentSpeed = moveSpeed;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision == null) return;
        currentSpeed = slowSpeed;
        Task.Delay(2000).ContinueWith(tag => RestoreSpeed());
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision == null) return;

        if (collision.tag == "SpeedBoost")
        {
            Debug.Log("Speed Boost!");
            currentSpeed = boostSpeed;
            Task.Delay(2000).ContinueWith(tag => RestoreSpeed());
        }
    }
}
