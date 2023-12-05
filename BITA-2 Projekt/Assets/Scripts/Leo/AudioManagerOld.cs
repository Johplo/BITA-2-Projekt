using UnityEngine.Audio;
using UnityEngine;
using System;

#region leo 

public class AudioManagerOld : MonoBehaviour {
    
    public Sound[] sounds;

    public static AudioManagerOld instance;

    void Awake() {

        if (instance == null)
            instance = this;
        else
        {
            Destroy(gameObject);
            return;
        }
        
        DontDestroyOnLoad(gameObject);

        foreach(Sound s in sounds)
        {
            s.source = gameObject.AddComponent<AudioSource>();
            s.source.clip = s.clip;
            
            s.source.volume = s.volume;
            s.source.pitch = s.pitch;
            s.source.loop = s.loop;
        }
    }

    void Start()
    {
        Play("Theme");
        Play("Theme1"); 

    }


    public void Play (string name)
    {
        Sound s = Array.Find(sounds, sound => sound.name == name);
        if (s == null)
        {
            Debug.LogWarning("Sound: " + name + " konte nicht gefunden werden!");
            return;
        }
        s.source.Play();
    }
}
#endregion