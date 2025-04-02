using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gate2 : MonoBehaviour
{
    public Key KeyStatus;
    public Animator Anim;
    public GameObject tbcPanel;

    public void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.transform.CompareTag("Player") && KeyStatus.HaveKey == true)
        {
            collision.gameObject.SetActive(false);
            Anim.SetBool("KeyStatus", true);
        }
    }

    public void ToBeContinue()
    {
        Time.timeScale = 0f;
        tbcPanel.SetActive(true);
    }
}
