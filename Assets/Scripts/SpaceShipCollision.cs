using UnityEngine;

public class SpaceShipCollision : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("Colisión con: " + collision.gameObject.name);

        if (collision.gameObject.CompareTag("Enemy"))
        {
            Debug.Log("Enemigo detectado. Destruyendo nave...");
            GetComponent<PlayerHealth>().TakeDamage();
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
