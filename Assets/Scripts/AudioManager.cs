using UnityEngine;

public class AudioManager : MonoBehaviour
{

    [SerializeField] private AudioSource deathSound;
    [SerializeField] private AudioSource winSound;
    [SerializeField] private AudioSource jumpSound;
    [SerializeField] private AudioSource dashSound;


    public void PlaySound(int sound)
    {
        switch (sound)
        {
            case 0:
                deathSound.Play();
                break;
            case 1:
                winSound.Play();
                break;
        }
    }
    
    public void PlayJumpSound()
    {
        jumpSound.Play();
    }

    public void PlayDashSound()
    {
        dashSound.Play();
    }
}
