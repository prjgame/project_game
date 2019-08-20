using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterControl : MonoBehaviour
{
    Rigidbody rb;
    GameObject target;
    float moveSpeed;
    Vector3 directionToTarget;
    public static int exp = 5;

    // Start is called before the first frame update
    void Start()
    {
        target = GameObject.Find("Player");
        rb = GetComponent<Rigidbody>();
        moveSpeed = Random.Range(1f,3f);
    }

    // Update is called once per frame
    void Update()
    {
        moveMonster();
    }

    private void OnCollisionEnter(Collision coll){
        if (coll.gameObject.name == "Player"){
            Debug.Log("Monster Attack !!!");
            HealthText.healthAmount -= 5;
            if (HealthText.healthAmount <= 0){
                Debug.Log("You're lose!!!");
                Destroy(coll.gameObject);
            }
        } else if (coll.gameObject.tag.Equals("Health") || coll.gameObject.tag.Equals("Ammo")) {
            Destroy(coll.gameObject);
        }
    }

    void moveMonster(){
        if (target != null){
            directionToTarget = (target.transform.position - transform.position).normalized;
            rb.velocity = new Vector2(directionToTarget.x * moveSpeed , directionToTarget.y * moveSpeed);
        } else {
            rb.velocity = Vector3.zero;
        }
    }
}
