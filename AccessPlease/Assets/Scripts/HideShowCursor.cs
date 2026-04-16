using UnityEngine;

public class HideShowCursor : MonoBehaviour
{
    public AudioSource audioSource;
    public GameObject gameMusic;
    public GameObject leftPanel;
    public GameObject rightPanel;
    public void ShowCursor()
    {
        Cursor.visible = true;
    }
    
    public void HideCursor()
    {
        Cursor.visible = false;
    }

    public void PlayOnce(AudioClip audio)
    {
        audioSource.PlayOneShot(audio);
    }

    public void startPlayingGameMusic()
    {
        gameMusic.SetActive(true);
    }

    public void startTheGame()
    {
        leftPanel.SetActive(true);
        rightPanel.SetActive(true);
    }
}
