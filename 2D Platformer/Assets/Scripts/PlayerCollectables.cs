using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerCollectables : MonoBehaviour
{
    public int gemNumber;
    private Text textComponent;

    // Start is called before the first frame update
    void Start()
    {
        gemNumber = PlayerPrefs.GetInt("GemNumber", 0);

        textComponent = GameObject.FindGameObjectWithTag("GemUI").GetComponentInChildren<Text>();
        UpdateText();
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void UpdateText()
    {
        textComponent.text = gemNumber.ToString();
    }

    public void GemCollected()
    {
        gemNumber += 1;
        UpdateText();
    }

    private void OnApplicationQuit()
    {
        PlayerPrefs.DeleteKey("GemNumber");
    }
}
