using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.SceneManagement;

public class Door : MonoBehaviour
{
    public int lvlToLoad;


    void Start()
    {

    }

    private void LoadLevel()
    {
        SceneManager.LoadScene(lvlToLoad);
    }

    private void RestartLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            GetComponent<BoxCollider2D>().enabled = false;
            collision.GetComponent<GatherInput>().DisableControls();

            LoadLevel();
        }
    }
}
