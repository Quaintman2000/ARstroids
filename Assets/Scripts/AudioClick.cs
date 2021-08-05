using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioClick : MonoBehaviour
{
    public AudioSource SoundFX;
    public AudioClip PressSoundFX;

    public void PressSound()
    {
        SoundFX.PlayOneShot(PressSoundFX);
    }

}
