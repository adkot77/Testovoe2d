using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PotionHealth : MonoBehaviour
{
    [SerializeField] private int amount = 1;
    [SerializeField] private AudioClip sfx;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out Health player))
        {
            AudioSFX.instance.PlaySFX(sfx);
            player.TakeHealth(amount);
            Destroy(gameObject);
        }
    }
}
