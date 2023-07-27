using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackGroundMusic : MonoBehaviour
{
    private static BackGroundMusic backGroundMusic;

    private void Awake()
    {
        if (backGroundMusic == null)
        {
            backGroundMusic = this;
            DontDestroyOnLoad(backGroundMusic);
        }
        else
            Destroy(gameObject);
    }
    public void StopAudio()
    {
        if (!(PlayerPrefs.GetInt("muted2") == 1))
            GetComponent<AudioSource>().Play();
        else
            GetComponent<AudioSource>().Pause();
    }


}
