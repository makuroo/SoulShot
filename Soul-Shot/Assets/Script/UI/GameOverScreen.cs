using UnityEngine;

public class GameOverScreen : MonoBehaviour
{
    public Health health;
    public GameObject GameOver;

    private void Update()
    {
        if (health.currentHp == 0)
        {
            GameOver.SetActive(true);
        }        
    }
}
