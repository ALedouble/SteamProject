using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireworkLauncher : Interactable {

    public float cooldownMaxValue;
    float cooldown;
    public GameObject[] fireworks;
    int whichFirework;

    protected override void Start()
    {
        cooldown = cooldownMaxValue;
    }

    private void Update()
    {
        if (burning && whichFirework<fireworks.Length-1)
        {
            if (cooldown > 0)
            {
                cooldown -= Time.deltaTime;
            }
            else
            {
                LaunchFirework();
                cooldown = cooldownMaxValue;
                whichFirework++;
            }
        }
    }

    void LaunchFirework()
    {
        fireworks[whichFirework].SetActive(false);
    }
}
