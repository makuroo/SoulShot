using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Key : MonoBehaviour
{
    public bool HaveKey;
    public AudioManager manager;
    // Start is called before the first frame update
    void Start()
    {
        HaveKey = false;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            manager.PlayClickSound();
            HaveKey = true;
            gameObject.SetActive(false);
        }
    }
}
