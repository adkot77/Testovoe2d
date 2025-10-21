using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DealDamage :MonoBehaviour
{

   
    

    protected void TryDealDamage(GameObject target,int damage)
    {
       if (target.TryGetComponent(out Health health))
        {
            health.TakeDamage(damage);
        }
    }
}
