using UnityEngine;
using System.Collections;

public class scrPlayerController : MonoBehaviour {

    public float speed;
    public float jumpPower;

    private Rigidbody rb;

    void Start() {
        rb = GetComponent<Rigidbody>();
    }

    void FixedUpdate() {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");
        float moveJump = 0.0f; //so you dont always get a jump

        if(rb.velocity.y == 0 && Input.GetKeyDown(KeyCode.Space) ) { // only jump if on ground
            moveJump = jumpPower;
        }

        Vector3 movement = new Vector3(moveHorizontal, moveJump, moveVertical);

        rb.AddForce(movement * speed); // add the final total force

    }

    void OnTriggerEnter(Collider other) {
        if (other.gameObject.CompareTag("Pick Up")) { //makesure its the right object
            other.gameObject.SetActive(false); 
        }
    }
}