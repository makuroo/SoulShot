using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class HealthUi : MonoBehaviour
{
    public Health health;
    public TextMeshProUGUI currentHealth;
    // Start is called before the first frame update
    void Start()
    {
        currentHealth = GetComponent<TextMeshProUGUI>();
    }

    // Update is called once per frame
    void Update()
    {
        currentHealth.text = "X " + health.currentHp.ToString();
    }
}
