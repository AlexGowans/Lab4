using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class scrPlayerController : MonoBehaviour {

    public float speed;
    public float jumpPower;
    public Text scoreText;
    public Text winText;

    private Rigidbody rb;
    private int pickUpCount;


    void Start() {
        rb = GetComponent<Rigidbody>();
        pickUpCount = 0;
        SetCountText();
        winText.text = "";
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
            other.gameObject.SetActive(false); //
            pickUpCount++; //increment score
            SetCountText();
        }
    }

    void SetCountText() {
        scoreText.text = "Scrolls: " + pickUpCount.ToString();
        if(pickUpCount >= 11) {
            winText.text = "YOU FOUND DE WEY";
        }
    }
}