using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Door : MonoBehaviour
{
    public int lvlToLoad;

    public Sprite unlockedSprite;
    private BoxCollider2D boxCol;

    void Start()
    {
        GameManager.RegisterDoor(this);
        boxCol = GetComponent<BoxCollider2D>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            GetComponent<BoxCollider2D>().enabled = false;
            collision.GetComponent<GatherInput>().DisableControls();

            PlayerStats playerStats = collision.GetComponentInChildren<PlayerStats>();
            PlayerPrefs.SetFloat("HealthKey", playerStats.health);

            GameManager.ManagerLoadLevel(lvlToLoad);
        }
    }

    public void UnlockDoor()
    {
        GetComponent<SpriteRenderer>().sprite = unlockedSprite;
        boxCol.enabled = true;
    }
}
