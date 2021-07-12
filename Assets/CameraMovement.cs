using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour {
    public GameObject Player;
    public float Height;
    public float Width;

    // Start is called before the first frame update
    // Start is called before the first frame update
    void Start() {

    }

    // Update is called once per frame
    void Update() {
        if(!Player.GetComponent<Renderer>().isVisible) {
            if(Player.transform.position.x < transform.position.x - Width/2) {
                // Camera moves to the left screen
                transform.position = new Vector3(transform.position.x - Width, transform.position.y, transform.position.z);
            } else if(Player.transform.position.x > transform.position.x + Width/2) {
                // Camera moves to the right screen
                transform.position = new Vector3(transform.position.x + Width, transform.position.y, transform.position.z);
            } else if(Player.transform.position.y < transform.position.y - Height/2) {
                // Camera moves to the botton screen
                transform.position = new Vector3(transform.position.x, transform.position.y - Height, transform.position.z);
            } else if(Player.transform.position.y > transform.position.y + Height/2) {
                // Camera moves to the top screen
                transform.position = new Vector3(transform.position.x, transform.position.y + Height, transform.position.z);
            }
        } 
    }
}
