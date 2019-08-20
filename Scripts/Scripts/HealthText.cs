using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthText : MonoBehaviour
{
    Text Health;

    public static int healthAmount = 30; 
    void Start()
    {
        Health = GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
       if (healthAmount > 0) {
           Health.text = "Health: " + healthAmount;
       } else {
           Health.text = "You're dead!!!";
       }
    }
}
