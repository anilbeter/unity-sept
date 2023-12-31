using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerStats : MonoBehaviour
{
    public float maxHealth;
    public float health;

    public bool canTakeDamage = true;

    private Animator anim;
    private PlayerMoveControls playerMove;

    public Image healthUI;

    void Start()
    {
        anim = GetComponentInParent<Animator>();
        playerMove = GetComponentInParent<PlayerMoveControls>();
        // health = maxHealth;
        health = PlayerPrefs.GetFloat("HealthKey", maxHealth);

        UpdateHealthUI();
    }

    public void TakeDamage(float damage)
    {
        if (canTakeDamage)
        {
            health -= damage;
            anim.SetBool("Damage", true);
            playerMove.hasControl = false;

            UpdateHealthUI();

            if (health == 0)
            {
                GetComponent<PolygonCollider2D>().enabled = false;
                GetComponentInParent<GatherInput>().DisableControls();

                PlayerPrefs.SetInt("GemNumber", 0);
                PlayerPrefs.SetFloat("HealthKey", maxHealth);
                GameManager.ManagerRestartLevel();
            }

            StartCoroutine(DamagePrevention());
        }
    }

    private IEnumerator DamagePrevention()
    {
        canTakeDamage = false;
        yield return new WaitForSeconds(0.15f);
        if (health > 0)
        {
            canTakeDamage = true;
            playerMove.hasControl = true;
            anim.SetBool("Damage", false);
        }
        else
        {
            anim.SetBool("Death", true);
        }
    }

    public void UpdateHealthUI()
    {
        healthUI.fillAmount = health / maxHealth;
    }

    public void IncreaseHealth(float heal)
    {
        health += heal;
        if (health > maxHealth)
        {
            health = maxHealth;
        }
        UpdateHealthUI();
    }

    // reset health when player exit from game
    private void OnApplicationQuit()
    {
        PlayerPrefs.DeleteKey("HealthKey");
    }
}
