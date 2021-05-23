using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MobileHealthController : MonoBehaviour
{
    public float playerHealth;
    [SerializeField] private Text healthText;

    void Start()
    {
        UpdateHealth();
    }

    public void UpdateHealth()
    {
        healthText.text = playerHealth.ToString("0");

        if(playerHealth <= 0)
        {
            Destroy(gameObject);
        }
        else
        {
            if(playerHealth > 100)
            {
                playerHealth = 100;
                UpdateHealth();
            }
        }
    }
}
