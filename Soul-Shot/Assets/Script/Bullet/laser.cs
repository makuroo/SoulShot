using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class laser : MonoBehaviour
{
    [SerializeField] private float laserSpeed = 30f;

    private void FixedUpdate()
    {
        float moveSpeed = laserSpeed * Time.deltaTime * transform.localScale.x;
        transform.Translate(moveSpeed, 0, 0);
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("left") || collision.gameObject.CompareTag("right") || collision.gameObject.CompareTag("Player"))
        {
            Destroy(gameObject);
        }
    }
}
