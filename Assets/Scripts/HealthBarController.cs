using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * Class to control health bars for units
 */
public class HealthBarController : MonoBehaviour
{
    private HealthSystem healthSystem;

    public void Setup(HealthSystem healthSystem)
    {
        this.healthSystem = healthSystem;

        healthSystem.onHealthChanged += HealthSystem_onHealthChanged;
    }

    private void HealthSystem_onHealthChanged(object sender, System.EventArgs e)
    {
        //TODO: Code to manipulate healthbar when health changes
        //transform.Find("Bar").localScale = new Vector3(healthSystem.getHealthPercent(), 1);
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
