using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveControl : MonoBehaviour
{
    [SerializeField]
    GameObject BonusWave1;
    [SerializeField]
    GameObject BonusWave2;


    // Start is called before the first frame update
    void Start()
    {
        BonusWave1.SetActive(false);
        BonusWave2.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void BonusWave1Trigger ()
    {
        BonusWave1.SetActive(true);
    }

    void BonusWave2Trigger()
    {
        BonusWave2.SetActive(true);
    }
}
