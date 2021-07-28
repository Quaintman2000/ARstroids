using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public Health playerHealth;
    public Slider healthSlider;
    public Text rocketsCounter;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        healthSlider.value = (playerHealth.health / playerHealth.maxHealth);
        rocketsCounter.text = playerHealth.gameObject.GetComponent<Pawn>().rockets.ToString();
    }
}
