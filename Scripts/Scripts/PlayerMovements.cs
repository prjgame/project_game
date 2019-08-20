using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovements : MonoBehaviour
{
    [SerializeField]
    float moveSpeed = 10f;

    public GameObject bulletToRight, bulletToLeft;
    Vector2 bulletPos;
    public float fireRate = 0.5f;
    float nextFire = 0f;

    private bool facingRight;

    public bool isGrounded = false;

    private AmmoText ammo = new AmmoText();

    public static int levelUp = 0;
    // Start is called before the first frame update
    void Start()
    {
        facingRight = true;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 movement = new Vector3(Input.GetAxis("Horizontal"), 0f , 0f);
        transform.position += movement * Time.deltaTime * moveSpeed;
    }

    //todo spastare in una classe apposita
    private void OnCollisionEnter(Collision coll){
        if (coll.gameObject.tag.Equals("Ammo")){
            Debug.Log("Ammo Reloaded!!!");
            ammo.SetAmmoAmount(ammo.GetAmmoAmount() + 6);
            Destroy(coll.gameObject);
        } else if (coll.gameObject.tag.Equals("Health")){
            Debug.Log("Health Reloaded!!!");
            HealthText.healthAmount += 10;
            Destroy(coll.gameObject);
        }
    }

    void FixedUpdate(){

        float horizontal = Input.GetAxis("Horizontal");

        flip(horizontal);

        if (Input.GetButtonDown("Jump") && isGrounded) {
            gameObject.GetComponent<Rigidbody>().AddForce(new Vector2(0f , 7f), ForceMode.Impulse); 
        }
        if (Input.GetButtonDown("Fire1") && Time.time > nextFire && ammo.GetAmmoAmount() > 0){
            ammo.SetAmmoAmount(ammo.GetAmmoAmount()-1);
            nextFire = Time.time + fireRate;
            fire();
        }   
    }

    void fire(){
       bulletPos = transform.position; 
        if (facingRight){
            bulletPos += new Vector2(+1f, -0.043f);
            Instantiate (bulletToRight, bulletPos , Quaternion.identity);
        } else {
            bulletPos += new Vector2(-1f, -0.043f);
            Instantiate (bulletToLeft, bulletPos , Quaternion.identity);
        }
    }

    private void flip(float horizontal){
        Vector3 theScale = transform.localScale;
        if (horizontal > 0){
            facingRight = true;
        } else if (horizontal < 0){
            facingRight = false;
        }
        if ((facingRight && theScale.x < 0) || (!facingRight && theScale.x > 0)){
            theScale.x *= -1;
        }
        transform.localScale = theScale;
    }
}
