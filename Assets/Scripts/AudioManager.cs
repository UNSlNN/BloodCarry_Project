using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public SoundSet[] sounds;   // Sound list
    public bool isPlayed;
    void Start()
    {
        foreach(SoundSet soundset in sounds)
        {
            soundset.source = gameObject.AddComponent<AudioSource>();
            soundset.source.clip = soundset.clip;
            soundset.source.loop = soundset.loop;
            soundset.source.volume = soundset.volume;
        }
    }
    public void PlaySound(string name)
    {
        foreach (SoundSet soundset in sounds)
        {
            if(soundset.name == name)
            {
                isPlayed = true;
                soundset.source.Play();
            }
        }
    }
    public void StopPlay(string name)
    {
        foreach (SoundSet soundset in sounds)
        {
            if (soundset.name == name)
            {
                isPlayed = false;
                soundset.source.Stop();
            }
        }
    }
}
