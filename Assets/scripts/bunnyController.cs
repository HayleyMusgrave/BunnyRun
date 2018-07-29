using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class bunnyController : MonoBehaviour {

    private Rigidbody2D myRigidBody;
    private Animator myAnim;
    public float bunnyJumpForce = 500f;
    private float bunnyHurtTime = -1;
    
	void Start () {
        myRigidBody = GetComponent<Rigidbody2D>();
        myAnim = GetComponent<Animator>();
	}
	
	void Update () {
        if (bunnyHurtTime == -1)
        {
            if (Input.GetButtonUp("Jump"))
            {
                myRigidBody.AddForce(transform.up * bunnyJumpForce);
            }
            myAnim.SetFloat("vVelocity", myRigidBody.velocity.y);
        }
        else
        {
            if (Time.time > bunnyHurtTime + 2)
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
            }
            
        }
	}

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.gameObject.layer == LayerMask.NameToLayer("Enemy"))
        {
            bunnyHurtTime = Time.time;
            myAnim.SetBool("bunnyHurt", true);
        }
    }
}
