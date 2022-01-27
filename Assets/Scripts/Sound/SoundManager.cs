using UnityEngine;
using UnityEngine.UI;
using System;

public class SoundManager : MonoBehaviour
{
    [SerializeField] Sound[] sounds;
    
    public static SoundManager soundManager;
    private void Awake()
    {
        if(soundManager == null)
        {
        soundManager = this;
        DontDestroyOnLoad(this);
        }
        else
        {
            Destroy(this);
        }
    }
    void Start()
    {
        

        foreach(Sound s in sounds)
        {
            s.audioSource = gameObject.AddComponent<AudioSource>();
            
            s.audioSource.volume = s.volume;
            s.audioSource.pitch = s.pitch;
            s.audioSource.loop = s.loop;

            s.audioSource.clip = s.clip;
        }

        PlaySound("Music");
    }
    public void SetVolumeFx(Slider slider)
    {
        foreach(Sound s in sounds)
        {
            if(s.name != "Music")
            {
                s.audioSource.volume = s.volume * slider.value;
            }
        }
    }
    public void SetVolumeMusic(Slider slider)
    {
        Sound sound = Array.Find(sounds, s => s.name == "Music");
        sound.audioSource.volume = sound.volume * slider.value;
    }
    public void PlaySound(string name)
    {
        Sound sound = Array.Find(sounds, s => s.name == name);

        sound.audioSource.Play();
    }
    public void StopSound(string name)
    {
        Array.Find(sounds, s => s.name == name).audioSource.Stop();
    }
    public AudioSource GetSound(string name)
    {
        return Array.Find(sounds, s => s.name == name).audioSource;
    }
}
