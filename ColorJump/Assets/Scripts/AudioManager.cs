using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager instance;
    public float volumeHolder;
    private float max = 1;

    [SerializeField] private AudioSource musicSource, sfxSource;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void Start()
    {
        volumeHolder = max;//initial volume holder value = max value of slider(hardcoded)
    }

    public void PlayAudio(AudioClip sfxClip)
    {
        sfxSource.PlayOneShot(sfxClip);
    }

    public void ChangeMasterVolume(float value)
    {
        musicSource.volume = value;//change bgm music volume
        volumeHolder = value;//save value from slidervaluechange event to volumeholder
    }




}
