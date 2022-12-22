using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public AudioSource AudioSource;

    // Start is called before the first frame update
    void Start()
    {
        int mute = PlayerPrefs.GetInt("audio");
        AudioSource.mute = mute == 1;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.M))
        {
            AudioSource.mute = !AudioSource.mute;
            int mute = 0;
            if (AudioSource.mute)
            {
                mute = 1;
            }
            PlayerPrefs.SetInt("audio", mute);
            PlayerPrefs.Save();
        }
    }
}
