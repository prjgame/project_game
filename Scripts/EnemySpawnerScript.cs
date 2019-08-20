using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawnerScript : MonoBehaviour
{
    public GameObject enemy;
    public bool isActive = true;
    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("Spawn" , 2f , 4f);
    }

    // Update is called once per frame
    void Update()
    {

    }

    void Spawn(){
        if (isActive){
            Instantiate(enemy, transform.position, Quaternion.identity);
        }
    }


}
