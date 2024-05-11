using UnityEngine;

public class MusicController : MonoBehaviour
{
    void Start()
    {
        DontDestroyOnLoad(gameObject);  // 只有在需要跨场景保持音乐播放时才添加这一行
    }

    public void StopMusic()
    {
        GetComponent<AudioSource>().Stop();
    }

    public void PlayMusic()
    {
        GetComponent<AudioSource>().Play();
    }

    public void ToggleMusic(bool isPlaying)
    {
        if (isPlaying)
            PlayMusic();
        else
            StopMusic();
    }
}
