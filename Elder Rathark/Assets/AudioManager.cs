using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class AudioManager : MonoBehaviour
{
    // You can acess AM through this class with any other place in code.  Simply use AudioManager.AM for some of the following expressions . . .
    public static AudioManager AM;
    public AudioSource musicTrack;
    public AudioClip musicLoop;
    
    void Start()
    {
        if(AM = null)
        {
            AM = this;
        }
        musicTrack.PlayDelayed(2.0f); //Play after two seconds so it doesnt jumpscare upon loading...
    }

    // Update is called once per frame
    void Update()
    {
        if(!musicTrack.isPlaying)
        {
            musicTrack.PlayOneShot(musicLoop);
        }
    }
}
