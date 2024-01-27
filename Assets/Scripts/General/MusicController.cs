using UnityEngine;

public class MusicController : MonoBehaviour
{
    [SerializeField]
    public AudioClip MainMenuTheme;
    [SerializeField]
    public AudioClip GameTheme;
    [SerializeField]
    public AudioClip Roster;

    private static MusicController instance;

    private void Awake()
    {
        if (instance != null && instance != this)
        {
            Destroy(gameObject);
            return;
        }

        instance = this;
    }

    public static void PlayMainMenuTheme()
    {
        instance.GetComponent<AudioSource>().clip = instance.MainMenuTheme;
        instance.GetComponent<AudioSource>().Play(0);
    }

    public static void PlayRoster()
    {
        instance.GetComponent<AudioSource>().clip = instance.Roster;
        instance.GetComponent<AudioSource>().Play(0);
    }

    public static void PlayGameTheme()
    {
        instance.GetComponent<AudioSource>().clip = instance.GameTheme;
        instance.GetComponent<AudioSource>().Play(0);
    }
}
