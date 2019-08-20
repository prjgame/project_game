using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grounded : MonoBehaviour
{
    private PlayerMovements movements;

    void Start(){
        movements = gameObject.GetComponentInParent<PlayerMovements>();
    }

    void OnTriggerEnter(Collider coll){
        movements.isGrounded = true;
    }

    void OnTriggerStay(Collider coll){
        movements.isGrounded = true;
    }


    void OnTriggerExit(Collider coll){
        movements.isGrounded = false;
    }
}
