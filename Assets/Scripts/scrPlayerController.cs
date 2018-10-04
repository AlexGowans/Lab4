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
        float moveJump = 0.0f;

        if(rb.velocity.y == 0 && Input.GetKeyDown(KeyCode.Space) ) {
            moveJump = jumpPower;
        }

        Vector3 movement = new Vector3(moveHorizontal, moveJump, moveVertical);

        rb.AddForce(movement * speed);

    }

    void OnTriggerEnter(Collider other) {
        if (other.gameObject.CompareTag("Pick Up")) {
            other.gameObject.SetActive(false);
        }
    }
}