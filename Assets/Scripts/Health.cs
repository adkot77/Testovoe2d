using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class Health : MonoBehaviour
{
    public UnityEvent OnDeath;
    [SerializeField] private Slider healthSlider;
    [SerializeField] private int maxHealth;
    [SerializeField] private AudioClip takeDamageSFX;

        // Start is called before the first frame update
    void Start()
    {
        healthSlider.maxValue = maxHealth;
        healthSlider.value = healthSlider.maxValue;
       
            OnDeath.AddListener(() => { Destroy(gameObject); });
        
    }

    public void TakeDamage(int damage)
    {
        if (takeDamageSFX != null)
        {
            AudioSFX.instance.PlaySFX(takeDamageSFX);
        }
        healthSlider.value -= damage;
        if (healthSlider.value == 0)
        {
          OnDeath?.Invoke();

        }
        
    }
    public void TakeHealth(int amount)
    {
        healthSlider.value +=amount;

       
    }

}
