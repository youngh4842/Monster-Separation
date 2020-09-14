using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundM : MonoBehaviour {   //배경음악과 효과음에 관여한다.

    public AudioSource efxSource;
    public AudioSource musicSource;

    public static SoundM instance = null;

    void Awake()
    {
        if (instance == null)
            instance = this;
        else if(instance != this )
            Destroy(gameObject);

    }

    public void playSingle (AudioClip clip)
    {
        efxSource.clip = clip;
        efxSource.Play();
    }

}
