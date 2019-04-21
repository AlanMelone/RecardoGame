using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RecardoMovement : MonoBehaviour
{
    public CharacterController2D RicardoController;
    public Animator animator;

    public float runSpeed = 40f;

    float horizontalMove = 0f;

    bool jump = false;

    // Start is called before the first frame update
    void Start()
    {

    }
    
    // Update is called once per frame
    void Update()
    {
        if (this.gameObject.transform.position.x > 110f)
        {
            horizontalMove = -1f * runSpeed;
        }
        else if (this.gameObject.transform.position.x < -110f)
        {
            horizontalMove = 1f * runSpeed; 
        }
        else
        {
            horizontalMove = Input.GetAxisRaw("Horizontal") * runSpeed;
        }

        animator.SetFloat("Speed", Mathf.Abs(horizontalMove));

        if (Input.GetButtonDown("Jump"))
        {
            jump = true;
            animator.SetBool("IsJump", true);
        }
    }

    public void OnLanding()
    {
        animator.SetBool("IsJump", false);
    }

    private void FixedUpdate()
    {
        RicardoController.Move(horizontalMove * Time.fixedDeltaTime, false, jump);
        jump = false;
    }
}
