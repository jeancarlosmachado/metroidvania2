using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MobileHealController : MonoBehaviour
{
    [SerializeField] private float touchHeal;
    [SerializeField] private MobileHealthController healthController;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Player"))
        {
            Damage();
        }
    }

    void Damage()
    {
        healthController.playerHealth = healthController.playerHealth + touchHeal;
        healthController.UpdateHealth();
    }
}
