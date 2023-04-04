using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SoundManager : MonoBehaviour
{
    [SerializeField] Slider volumeSlider;

    // Start is called before the first frame update
    void Start()
    {
        if(!PlayerPrefs.HasKey("vol"))
        {
            PlayerPrefs.SetFloat("vol", 0.5f);
            Load();
        }
        else
        {
            Load();
        }
    }

    public void changeVolume()
    {
        AudioListener.volume = volumeSlider.value;
    }

    public void Load()
    {
        volumeSlider.value = PlayerPrefs.GetFloat("vol");
    }

    public void Save()
    {
        PlayerPrefs.SetFloat("vol", volumeSlider.value);
    }
}
