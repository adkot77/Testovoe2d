using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
    [SerializeField] private int value=1;
    [SerializeField] private AudioClip sfx;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.TryGetComponent(out PlayerController player))
        {
            AudioSFX.instance.PlaySFX(sfx);
            ResourcesManager.Instance.CoinUp(value);
            Destroy(gameObject);
        }
    }
}
