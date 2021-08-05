using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{

    public int maxHealth = 100;
    public int currentHealth;

    public int maxRockets = 5;
    public int currentRockets;

    public int maxShieldPower = 100;
    public int currentShieldPower;

    public HealthBarScript healthbar;
    public RocketAmmoBar rocketAmmo;
    public ShieldsBar shieldbar;

    public static bool GameIsOver = false;
    public GameObject gameOverMenuUI;
    public GameObject gameMenuUI;

    public AudioSource healthBoom;
    public AudioSource shieldBoom;
    public AudioSource deathSound;
    public AudioSource rocketSound;
    public AudioSource rocketPowerUpSound;
    public AudioSource healthPowerUpSound;
    public AudioSource shieldPowerUpSound;



    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth;
        healthbar.SetMaxHealth(maxHealth);

        currentRockets = maxRockets;
        rocketAmmo.SetMaxRockets(maxRockets);

        currentShieldPower = maxShieldPower;
        shieldbar.SetMaxShield(maxShieldPower);

    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Backspace))
        {
            if(currentShieldPower <= 0)
            {
                TakeDamage(20);
                healthBoom.Play();
            }
            else
            {
                damageShield(20);
                shieldBoom.Play();
            }
        }

        if(currentHealth <= 0)
        {
            deathSound.Play();
            Die();
        }

        if(Input.GetKeyDown(KeyCode.H))
        {
            healthPowerUpSound.Play();
            HealthPowerUp(20);
        }

        if(Input.GetKeyDown(KeyCode.F))
        {
            rocketSound.Play();
            ShootRocket(1);
        }

        if(Input.GetKeyDown(KeyCode.R))
        {
            rocketPowerUpSound.Play();
            RocketPowerUp(1);
        }

        if(Input.GetKeyDown(KeyCode.S))
        {
            shieldPowerUpSound.Play();
            ShieldPowerUp(10);
        }
    }

    void TakeDamage(int damage)
    {
        currentHealth -= damage;
        healthbar.SetHealth(currentHealth);
    }
    
    void Die()
    {
        gameOverMenuUI.SetActive(true);
        GameIsOver = true;
        gameMenuUI.SetActive(false);
        Time.timeScale = 0f;
    }

    void HealthPowerUp(int regen)
    {
        currentHealth += regen;
        healthbar.SetHealth(currentHealth);
    }

    public void ShootRocket(int rocketLeft)
    {
        currentRockets -= rocketLeft;
        rocketAmmo.SetRockets(currentRockets);
    }

    void RocketPowerUp(int reload)
    {
        currentRockets += reload;
        rocketAmmo.SetRockets(currentRockets);
    }

    void damageShield(int shieldDown)
    {
        currentShieldPower -= shieldDown;
        shieldbar.SetShieldPower(currentShieldPower);
    }

    void ShieldPowerUp(int shieldCharge)
    {
        currentShieldPower += shieldCharge;
        shieldbar.SetShieldPower(currentShieldPower);
    }
}
