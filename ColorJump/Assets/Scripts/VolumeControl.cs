using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class VolumeControl : MonoBehaviour
{
    [SerializeField] private Slider volumeSlider;

    private void Awake()
    {

    }
    void Start()
    {
        //AudioManager.instance.ChangeMasterVolume(volumeSlider.value);

        volumeSlider.onValueChanged.AddListener(value => AudioManager.instance.ChangeMasterVolume(value));//checks for change in value on slider and changes volume based on slider change



    }

    // Update is called once per frame
    void Update()
    {
        volumeSlider.value = AudioManager.instance.volumeHolder;//get volume value from volume holder to update slider info after reloading scene
    }
}
