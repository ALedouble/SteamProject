using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonTurningPlate : Interactable
{
    public Transform turningPlateTransform;
    float targetYRotation;
    public AudioSource myAudioSourceButton;
    public AudioSource audioSourcePlatform;
    public AudioClip rotationClip;
    public AudioClip toggleButtonClip;

    public override void Activate()
    {
        targetYRotation += 90;
        myAudioSourceButton.PlayOneShot(toggleButtonClip);
        audioSourcePlatform.Stop();
        audioSourcePlatform.PlayOneShot(rotationClip);
    }

    private void Update()
    {
        turningPlateTransform.rotation = Quaternion.Lerp(turningPlateTransform.rotation, Quaternion.Euler(0, targetYRotation, 0), 0.1f);
    }
}
