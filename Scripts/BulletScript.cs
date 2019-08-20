using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletScript : MonoBehaviour
{

    public float velX = 5f;
    float velY = 0f;
    Rigidbody rb;

    public GameObject[] itemToDrop;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        rb.velocity = new Vector2(velX , velY);
        Destroy(gameObject, 3);
    }

    private void OnCollisionEnter(Collision coll){
        if (coll.gameObject.tag.Equals("Monster")){
            Debug.Log("Monster Destroyed!!!");
            PlayerMovements.levelUp += MonsterControl.exp;
            Debug.Log("Exp:" + PlayerMovements.levelUp);
            if (PlayerMovements.levelUp >= LevelUpText.nextlevelUp) {
                LevelUpText.level++;
                PlayerMovements.levelUp = 0;
            }
            Destroy(gameObject);
            Destroy(coll.gameObject);
            Instantiate(itemToDrop[Random.Range(0,2)], coll.gameObject.transform.position, Quaternion.identity);
            
        }
    }
}
