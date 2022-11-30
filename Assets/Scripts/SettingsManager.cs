using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SettingsManager : MonoBehaviour
{
    [Header(" Elements ")]
    [SerializeField] SoundsManager soundsManager;
    [SerializeField] Image soundButtonImage;
    [SerializeField] Image hapticButtonImage;
    [SerializeField] Sprite optionOnSprite;
    [SerializeField] Sprite optionOffSprite;

    [Header(" Settings ")]
    bool soundsState = true;
    bool hapticState = true;

    private void Start()
    {
        Setup();
    }

    public void ChangeSoundsState()
    {
        if (soundsState)
            DisableSounds();
        else
            EnableSounds();

        soundsState = !soundsState;

        //save the value of the sounds state
    }

    private void Setup()
    {
        if (soundsState)
            EnableSounds();
        else
            DisableSounds();

        if (hapticState)
            EnableHaptics();
        else
            DisableHaptics();
    }

    private void DisableSounds()
    {
        //tell the sounds manager to set the volume of all the sounds to 0 
        soundsManager.DisableSounds();
        //change the image of the sounds button
        soundButtonImage.sprite = optionOffSprite;
    }

    private void EnableSounds()
    {
        //tell the sounds manager to set the volume of all the sounds to 1
        soundsManager.EnableSounds();
        //change the image of the sounds button
        soundButtonImage.sprite = optionOnSprite;
    }

    private void EnableHaptics()
    {

    }

    private void DisableHaptics()
    {

    }
}
