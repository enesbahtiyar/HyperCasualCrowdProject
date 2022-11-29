using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SettingsManager : MonoBehaviour
{
    [Header(" Elements ")]
    [SerializeField] Image soundButtonImage;
    [SerializeField] Image hapticButtonImage;
    [SerializeField] Sprite optionOnSprite;
    [SerializeField] Sprite optionOffSprite;

    [Header(" Settings ")]
    bool soundsState = true;
    bool hapticState = true;
    public void ChangeSoundsState()
    {
        if (soundsState)
            DisableSounds();
        else
            EnableSounds();

        soundsState = !soundsState;
    }

    private void DisableSounds()
    {

    }

    private void EnableSounds()
    {

    }
}
