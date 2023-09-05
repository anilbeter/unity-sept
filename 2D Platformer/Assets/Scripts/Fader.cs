using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.SceneManagement;

public class Fader : MonoBehaviour
{
    private Animator anim;
    private int lvlToLoad;

    void Start()
    {
        anim = GetComponent<Animator>();

        GameManager.RegisterFader(this);
    }

    public void SetLevel(int lvl)
    {
        lvlToLoad = lvl;
        anim.SetTrigger("Fade");
    }

    public void LoadLevel()
    {
        SceneManager.LoadScene(lvlToLoad);
    }

    private void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    // When I call RestartLevel function, actually I call Restart function with 1.5s delay
    public void RestartLevel()
    {
        // 1.5f -> 1.5s delay
        Invoke("Restart", 1.5f);
    }
}
