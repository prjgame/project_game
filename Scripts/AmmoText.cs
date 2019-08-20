using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AmmoText : MonoBehaviour
{
    Text Ammo;
    public static int ammoAmount = 50;
    // Start is called before the first frame update
    void Start()
    {
        Ammo = GetComponent<Text>(); 
    }

    // Update is called once per frame
    void Update()
    {
        if (ammoAmount > 0){
            Ammo.text = "Ammo: " + ammoAmount;
        } else {
            Ammo.text = "Out of Ammo!!!";
        }
    }
}
