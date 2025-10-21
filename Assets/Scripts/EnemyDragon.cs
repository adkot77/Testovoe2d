using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDragon : Enemy
{
    [SerializeField] private float pushingForce=10;
    [SerializeField] private int damage=1;
    public void Death()
    {
        Destroy(gameObject);
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.rigidbody)
        {
            Vector2 forceDirection = (transform.position - collision.transform.position).normalized + Vector3.up;
            collision.rigidbody.AddForce(forceDirection * pushingForce, ForceMode2D.Impulse);
        }
      
        TryDealDamage(collision.gameObject, damage );
        
    }
}
    
