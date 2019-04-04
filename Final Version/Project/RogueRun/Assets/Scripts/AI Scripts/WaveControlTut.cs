using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveControlTut : MonoBehaviour
{
    [SerializeField]
    GameObject BonusWave1;



    void Start()
    {
        BonusWave1.SetActive(false);
    }

    void BonusWave1Trigger()
    {
        BonusWave1.SetActive(true);
    }

}
