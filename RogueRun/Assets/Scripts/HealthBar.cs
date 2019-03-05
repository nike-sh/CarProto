using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthBar : MonoBehaviour {

    private HealthSystem healthSystem;

    public void Setup(HealthSystem healthSystem)
    {
        healthSystem.OnHealthChange += HealthSystem_OnHealthChanged; ;
    }
	
    private void HealthSystem_OnHealthChanged(object sender, System.EventArgs e)
    {
        transform.Find("Bar").localScale = new Vector3(healthSystem.GetHealthPercent(), 1);
    }
	
}
