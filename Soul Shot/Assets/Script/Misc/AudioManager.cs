using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public AudioSource moveSound;
    public AudioSource shotSound;
    public AudioSource attackedSound;
    public AudioSource clickSound;
    public AudioSource enemyLaser;
    public AudioSource platformSound;

    public void PlayMoveSound()
    {
        moveSound.Play();
    }

    public void PlayShotSound()
    {
       shotSound.Play();
    }

    public void PlayAttackedSound()
    {
        attackedSound.Play();
    }

    public void PlayClickSound()
    {
        clickSound.Play();
    }

    public void PlayEnemyShootSound()
    {
        enemyLaser.Play();
    }

    public void PlayPlatformSound()
    {
        platformSound.Play();
    }
}
