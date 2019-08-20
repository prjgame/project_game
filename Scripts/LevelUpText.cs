using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelUpText : MonoBehaviour
{

    Text levelUp;
    // Start is called before the first frame update

    public static int nextlevelUp = 10;
    public static int level = 0;
    void Start()
    {
        levelUp = GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        levelUp.text = "LevelUp: " + level;
    }
}
