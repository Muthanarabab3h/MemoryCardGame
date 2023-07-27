using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class sounds : MonoBehaviour
{

    public AudioClip[] audioClip;

    public void SoundPlayer(int soundNumber, float timeBeforeDestroy)
    {

        GameObject audio = new GameObject();
        audio.AddComponent<AudioSource>();
        GameObject soundObject = Instantiate(audio, transform.position, Quaternion.identity, null);
        soundObject.GetComponent<AudioSource>().clip = audioClip[soundNumber];
        soundObject.GetComponent<AudioSource>().Play();
        Destroy(soundObject, timeBeforeDestroy);
        Destroy(audio, timeBeforeDestroy);



    }







    }