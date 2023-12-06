using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AudioControl : MonoBehaviour
{
    private Toggle audioToggle;
    // Start is called before the first frame update
    void Start()
    {
        audioToggle = GetComponent<Toggle>();
        if (AudioListener.volume == 0)
        {
            audioToggle.isOn = false;
        }
    }

    // Update is called once per frame
    void Update()
    {

    }
    public void ToggleAudioOnValueChange(bool audioIn)
    {
        if (audioIn)
            AudioListener.volume = 1;
        else
            AudioListener.volume = 0;
    }
}
