using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public AudioClip[] musicTracks;
    private AudioSource audioSource;
    private int currentTrackIndex = 0;

    void Awake()
    {
        DontDestroyOnLoad(audioSource = GetComponent<AudioSource>());

        if (audioSource != null && musicTracks.Length > 0)
        {
            PlayNextTrack();
        }
        else
        {
            Debug.LogError("AudioSource or music tracks not properly set on AudioManager!");
        }
    }

    void PlayNextTrack()
    {
        if (currentTrackIndex < musicTracks.Length)
        {
            audioSource.clip = musicTracks[currentTrackIndex];
            audioSource.Play();

            // Ustaw zdarzenie dla zako�czenia odtwarzania utworu
            audioSource.SetScheduledEndTime(AudioSettings.dspTime + audioSource.clip.length);

            // Przejd� do nast�pnego utworu po zako�czeniu obecnego
            Invoke("PlayNextTrack", audioSource.clip.length);

            currentTrackIndex++;
        }
        else
        {
            Debug.Log("All tracks played.");
        }
    }
}
