using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class soundmanagerscript : MonoBehaviour
{
    public static soundmanagerscript Instance;
    public AudioSource source;
    public AudioSource effectos;
    public AudioClip cajita;
    public AudioClip mancha;
                                
    private void Awake()

    {
        if (Instance != null && Instance != this)
        {
            Destroy(this.gameObject);

        }
        else
        {
            Instance = this;
        }

        DontDestroyOnLoad(this);
        source = GetComponent<AudioSource>();
    }
    public void PlaySound(AudioClip clip)
    {
        source.loop = false;
        source.PlayOneShot(clip);
    }
    public void voidUno(float volume)
    {
        
        source.volume = volume;

    }
    public void voidDos(float volume)
    {
        effectos.volume = volume;

    }
}
