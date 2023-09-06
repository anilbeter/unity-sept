using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gem : MonoBehaviour
{
    void Start()
    {
        GameManager.RegisterGem(this);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            collision.GetComponent<PlayerCollectables>().GemCollected();

            GetComponent<AudioSource>().Play();
            GetComponent<SpriteRenderer>().enabled = false;
            GetComponent<CircleCollider2D>().enabled = false;
            // Destroy(gameObject);

            GameManager.RemoveGemFromList(this);
        }
    }

}
