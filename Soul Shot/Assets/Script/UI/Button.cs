using UnityEngine;
using UnityEngine.SceneManagement;

public class Button : MonoBehaviour
{
    public GameObject Panel;
    public GameObject PausePanel;
    [SerializeField] public static bool GameIsPaused = false;
    [SerializeField] public bool attack = true;
//    public AudioSource cliksound;
    public void StartGame()
    {
        transform.GetComponent<AudioSource>().Play();
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
    
    public void Retry()
    {
        transform.GetComponent<AudioSource>().Play();
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void MainMenu()
    {
        transform.GetComponent<AudioSource>().Play();
        SceneManager.LoadScene(0);
        Time.timeScale = 1f;
    }

    public void Quit()
    {
        transform.GetComponent<AudioSource>().Play();
        Application.Quit();
    }
    
    public void Close()
    {
        transform.GetComponent<AudioSource>().Play();
        Panel.SetActive(false);
    }

    public void Help()
    {
        transform.GetComponent<AudioSource>().Play();
        Panel.SetActive(true);
    }

    public void Attack()
    {
        attack = false;
    }

    public void Pause()
    {
        transform.GetComponent<AudioSource>().Play();
        Time.timeScale = 0f;
        GameIsPaused = true;
        PausePanel.SetActive(true);
    }

    public void Resume()
    {
        transform.GetComponent<AudioSource>().Play();
        attack = true;
        GameIsPaused = false;
        Time.timeScale = 1f;
        PausePanel.SetActive(false);
    }
}
