using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player : MonoBehaviour {
    Rigidbody2D body;

    float horizontal;
    float vertical;
    float facing=-1;

    bool hit = false;

    Vector3 move;

    float RunSpeed = 3.5f;

    public Animator Animator;

    public GameObject PlayerCorpse;

    void Start() {
        body = GetComponent<Rigidbody2D>();    
    }


    void Update() {
        horizontal = Input.GetAxisRaw("Horizontal");
        vertical = Input.GetAxisRaw("Vertical");
        
        // if(Input.GetKeyDown(KeyCode.Space) && !hit) {
        //     this.Die();
        // }

        Animator.SetBool("GotHit",hit);
        Animator.SetFloat("Horizontal",horizontal);
        Animator.SetFloat("Facing",facing);
        Animator.SetFloat("Speed",(new Vector2(horizontal,vertical)).sqrMagnitude);
    }


    void FixedUpdate() {
        // Determin wich side the player is facing
        if(horizontal > 0.0f) {
            facing = 1;
        } else if( horizontal < 0.0f) {
            facing = -1;
        }

        // Check for diagonal movement
        move = new Vector3(horizontal,vertical,0).normalized;
        body.velocity = new Vector2(move.x * RunSpeed, move.y * RunSpeed);
    }

    public void Die() {
        if(!hit) {
            hit = true;
            BecomeGhost();
        }
    }

    void SpawnCorpse() {
        GameObject corpse = Instantiate(PlayerCorpse) as GameObject;
        corpse.transform.position = transform.position;
        //transform.position = new Vector3(transform.position.x,transform.position.y+0.1f,transform.position.z);
        if(facing < 0) {
            corpse.GetComponent<SpriteRenderer>().flipX = true;
        }
        RunSpeed=4f;
        this.enabled = true;
    }

    private void BecomeGhost() {
        gameObject.GetComponent<BoxCollider2D>().enabled = false;
        RunSpeed=0.0f;
    }
}
