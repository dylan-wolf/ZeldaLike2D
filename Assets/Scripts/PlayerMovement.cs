using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float speed;
    private Rigidbody2D myRigidbody;
    private Vector3 change; //Difference between Vector types?
    // Start is called before the first frame update

    private Animator animator;
    void Start()
    {
        animator = GetComponent<Animator>();
        myRigidbody = GetComponent<Rigidbody2D>();
        
    }

    // Update is called once per frame
    public void FixedUpdate()
    {
        change = Vector3.zero; //Every frame the amount player has changed will reset.
        //.GetAxisRaw does not slowly build up speed. Use .GetAxis for this
        change.x = Input.GetAxisRaw("Horizontal") * Time.deltaTime * speed; //Horizontal is defined by default
        change.y = Input.GetAxisRaw("Vertical") * Time.deltaTime * speed;
        if(change != Vector3.zero)
        {
            transform.Translate(new Vector3(change.x, change.y));
        } //the changes to the above four lines are required for Unity2019.3+
        UpdateAnimoationAndMove();
       
        Debug.Log(change); //Displays debugger for change
    }

    void UpdateAnimoationAndMove()
    {
        if (change != Vector3.zero)
        {
            MoveCharacter();
            animator.SetFloat("moveX", change.x);
            animator.SetFloat("moveY", change.y);
            animator.SetBool("moving", true);
        }
        else
        {
            animator.SetBool("moving", false);
        }
    }

    void MoveCharacter()
    {
        myRigidbody.MovePosition(transform.position + change.normalized * speed * Time.deltaTime);
        //Move position is going to be equal to position plus change times speed (4 obtained from Unity UI) times time passed so makes for smooth movement.
        //By definition, Time.deltaTime is the completion time in seconds since the last frame.
        //This helps us to make the game frame-independent.That is, regardless of the fps, the game will be executed at the same speed. 
    }
}
