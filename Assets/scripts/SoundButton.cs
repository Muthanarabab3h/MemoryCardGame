using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class SoundButton : MonoBehaviour
{
    [SerializeField] private Image SoundOn;
    [SerializeField] private Image SoundOff;
    private bool mute = false;

    // Start is called before the first frame update
    void Start()
    {
        if (!PlayerPrefs.HasKey("muted2"))
        {
            PlayerPrefs.SetInt("muted2", 0);
            Load();
        }

        else
        {
            Load();
        }
        UpdateButtonIcon();
        FindObjectOfType<BackGroundMusic>().StopAudio();

    }

    private void UpdateButtonIcon()
    {
        if (mute == false)
        {
            SoundOn.enabled = true;
            SoundOff.enabled = false;
        }

        else
        {
            SoundOn.enabled = false;
            SoundOff.enabled = true;
        }
    }
    public void OnButtonPress()
    {
        mute = !mute;
        AudioListener.pause = mute;
        Save();
        FindObjectOfType<BackGroundMusic>().StopAudio();
        UpdateButtonIcon();
    }

    private void Load()
    {

        mute = PlayerPrefs.GetInt("muted2") == 1;
    }

    private void Save()
    {
        PlayerPrefs.SetInt("muted2", mute ? 1 : 0);
    }
}