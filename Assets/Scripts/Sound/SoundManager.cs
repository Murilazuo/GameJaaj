using UnityEngine;
using System;

public class SoundManager : MonoBehaviour
{
    [SerializeField] Sound[] sounds;
    public static SoundManager soundManager;
    void Start()
    {
        DontDestroyOnLoad(this);
        
        soundManager = this;

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

    public void PlaySound(string name)
    {
        print(name);
        Array.Find(sounds, s => s.name == name).audioSource.Play();
    }
}
