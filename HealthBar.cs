using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    private Image healthbar;
    public float currenthealth;
    private float maxhealth = 5f;
    Submarine player;

    void Start() 
    {
        healthbar = GetComponent<Image>();
        player = FindObjectOfType<Submarine>();
    }

    void Update()
    {
        currenthealth = player.health;
        healthbar.fillAmount = currenthealth/maxhealth;

        if (currenthealth >= 4)
        {
            new Color32(135,212,123,255);
        }
        else if (currenthealth >= 2 && currenthealth < 4)
        {
            healthbar.color = new Color32(255,198,40,255);
        }
        else if (currenthealth <= 1)
        {
            healthbar.color = new Color32(255,82,40,255);
        }
    }
}
