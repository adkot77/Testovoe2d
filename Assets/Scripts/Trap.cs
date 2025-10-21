using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trap : DealDamage
{
    [SerializeField] int damage = 1;
    private void OnCollisionEnter2D(Collision2D collision)
    {
        TryDealDamage(collision.gameObject, damage);
    }
}
