using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fireball : DealDamage
{
    private Rigidbody2D rb;
    
    [SerializeField] private  float speed=5;
    [SerializeField] private  int damage=5;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.AddForce(transform.right*speed,ForceMode2D.Impulse);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        TryDealDamage(collision.gameObject,damage);
        Destroy(gameObject);
    }
}
