using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerKarmaPoint : MonoBehaviour
{
    public float karmaPoint = 0;

    public void GainKarmaPoint(float amount)
    {
        karmaPoint += amount;
    }
    public void LoseKarmaPoint(float amount)
    {
        karmaPoint -= amount;
    }
}

