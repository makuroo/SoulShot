using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    [SerializeField] private float attackCooldown;
    [SerializeField] private Transform firePoint;
    [SerializeField] private GameObject[] bullets;
    [SerializeField] private Movement playerMovement;
    [SerializeField] private float cooldownTimer = Mathf.Infinity;
    [SerializeField] private Health decreaseHp;
    [SerializeField] private AudioManager manager;

    private void Awake()
    {
        playerMovement = GetComponent<Movement>();
        decreaseHp = GetComponent<Health>();
    }

    private void FixedUpdate()
    {
        if(Input.GetMouseButtonDown(0) && cooldownTimer > attackCooldown && playerMovement.CanAttack())
        {
            Attack();
            manager.PlayShotSound();
            decreaseHp.TakeDamage(1);
            decreaseHp.Die();
        }

        cooldownTimer += Time.deltaTime;
    }

    void Attack()
    {
        cooldownTimer = 0;
        if(gameObject.GetComponent<SpriteRenderer>().flipX == false)
        {

            bullets[FindBullet()].transform.position = firePoint.position;
            bullets[FindBullet()].GetComponent<Bullet>().SetDirection(Mathf.Sign(transform.localScale.x));
        }
        else
        {
            bullets[FindBullet()].transform.position = new Vector2(firePoint.position.x, firePoint.position.y);
            bullets[FindBullet()].GetComponent<Bullet>().SetDirection(Mathf.Sign(- transform.localScale.x));
        }
    }

    private int FindBullet()
    {
        for (int i =0; i<bullets.Length; i++)
        {
            if (!bullets[i].activeInHierarchy)
            {
                return i;
            }
        }

        return 0;
    }
}
