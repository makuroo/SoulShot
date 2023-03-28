using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tower : MonoBehaviour
{
    public GameObject laser;
    private bool stopSpawn = false;
    [SerializeField] private float spawnTime;
    [SerializeField] private float spawnDelay;
    [SerializeField] private AudioManager manager;

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("Shoot", spawnTime, spawnDelay);
    }

    private void Shoot()
    {
        manager.PlayEnemyShootSound();
        Instantiate(laser, transform.position, transform.rotation);

        if (stopSpawn)
        {
            CancelInvoke("shoot");
        }
    }
}
