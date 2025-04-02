using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Platform_Swap : MonoBehaviour
{
    [SerializeField] private Sprite sprite2;
    [SerializeField] private Sprite sprite1;
    [SerializeField] private AudioManager manager;
    [SerializeField] private float startTime;
    [SerializeField] private float repeatTime;
    [SerializeField] private float starttimeBroken;
    [SerializeField] private float repeatimeBroken;

    // Update is called once per frame
    private void Start()
    {
        InvokeRepeating("Swap", startTime, repeatTime);
        InvokeRepeating("SwapBroken", starttimeBroken, repeatimeBroken);
    }

    public void SwapBroken()
    {
        manager.PlayPlatformSound();
        transform.GetComponent<SpriteRenderer>().sprite = sprite2;
        transform.GetComponent<BoxCollider2D>().enabled = false;
    }

    public void Swap()
    {
        transform.GetComponent<SpriteRenderer>().sprite = sprite1;
        transform.GetComponent<BoxCollider2D>().enabled = true;
    }
}
