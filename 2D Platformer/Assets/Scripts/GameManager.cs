using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private static GameManager GM;
    private Fader fader;
    private Door theDoor;

    private List<Gem> gems;

    void Awake()
    {
        if (GM == null)
        {
            GM = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }

        gems = new List<Gem>();
    }

    public static void RegisterDoor(Door door)
    {
        if (GM = null)
            return;
        GM.theDoor = door;
    }

    public static void RegisterFader(Fader fD)
    {
        if (GM == null)
        {
            return;
        }
        GM.fader = fD;
    }

    public static void ManagerLoadLevel(int index)
    {
        if (GM == null)
            return;
        GM.fader.SetLevel(index);
    }

    public static void ManagerRestartLevel()
    {
        if (GM == null)
            return;
        GM.fader.RestartLevel();
    }
}
