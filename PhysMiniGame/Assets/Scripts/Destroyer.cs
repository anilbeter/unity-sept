using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destroyer : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collison)
    {
        Destroy(collison.gameObject, 0.5f);
    }
}
