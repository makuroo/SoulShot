using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class gate : MonoBehaviour
{
    public Key KeyStatus;
    public Animator Anim;

    public void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.transform.CompareTag("Player") && KeyStatus.HaveKey == true)
        {
            collision.gameObject.SetActive(false);
            Anim.SetBool("KeyStatus", true);
        }
    }

    public void nextscene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
