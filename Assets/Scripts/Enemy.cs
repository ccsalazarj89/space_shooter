using System.IO;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] float speed = 1f;
    Vector3 linearVelocity = Vector3.left;

    const float increaseRate = 1f;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(linearVelocity * speed * Time.deltaTime);
        if (transform.position.x < -6.0)
        {
            linearVelocity = Vector3.right;
            speed += increaseRate;
        }
        if (transform.position.x > 6.0)
        {
            linearVelocity = Vector3.left;
            speed += increaseRate; 
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("PlayerShot")) {
            Destroy(gameObject);
        }
    }
}
