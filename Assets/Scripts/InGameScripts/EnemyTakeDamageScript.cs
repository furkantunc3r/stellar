using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyTakeDamageScript : MonoBehaviour
{
    public float health;
    public float maxHealth = 100f;

    // Start is called before the first frame update
    void Start()
    {
        health = maxHealth;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "bullet")
        {
            Destroy(collision.gameObject);
            health -= 50f;
        }
        if (health <= 0)
            Destroy(gameObject);
    }
}
