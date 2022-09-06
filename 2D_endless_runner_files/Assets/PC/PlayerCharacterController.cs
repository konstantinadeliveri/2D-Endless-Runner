using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCharacterController : MonoBehaviour
{
    //comments are *all* ours, a bit of a mess, unlike other script files since some was taken from internet, some was our work, and we wanted to make sure it was clear what we did and did not add


    //Field in editor for refferencing what counts as ground
    [SerializeField] LayerMask groundLayers;                                                                                                            // NOT OURS, TAKEN FROM INTERNET
    //Variable for running speed of character
    [SerializeField] private float runSpeed = 8f;                                                                                                       // NOT OURS, TAKEN FROM INTERNET
    //Variable for jumping height of character
    [SerializeField] private float jumpHeight = 2f;                                                                                                     // NOT OURS, TAKEN FROM INTERNET
    //Variable for controlling StepOffset of character. StepOffset causes the character to "climb" and object infront of them if it's closer than X to ground
    [SerializeField] private float originalStepOffset = 0.3f;                                                                                       

    //3 fields for assigning points where char model checks for something (ex. ground)
    [SerializeField] private Transform[] groundChecks;                                                                                                  // NOT OURS, TAKEN FROM INTERNET
    [SerializeField] private Transform[] wallChecks;                                                                                                    // NOT OURS, TAKEN FROM INTERNET
    [SerializeField] private Transform[] ceilingChecks;

    //variable for gravity force
    private float gravity = -50f;                                                                                                                       // NOT OURS, TAKEN FROM INTERNET
    //variable for char controller
    private CharacterController characterController;                                                                                                    // NOT OURS, TAKEN FROM INTERNET
    //variable for velocity
    private Vector3 velocity;                                                                                                                           // NOT OURS, TAKEN FROM INTERNET
    //different variable for changing speed of char
    private float horizontalInput;
    //2 booleans/flags for the 2 types of checks, if char is touching ground and/or ceiling
    private bool isGrounded;                                                                                                                            // NOT OURS, TAKEN FROM INTERNET
    public bool Headache;
    //boolean for checking if player is pressing key for slide
    public bool isSliding;
    //refference to animator for animations
    private Animator animator;                                                                                                                          // NOT OURS, TAKEN FROM INTERNET
    //static boolean to check if char is dead, important to solve scene loading issues
    public static bool dead;
    //variable for the jumping effect sound
    AudioSource JumpSound;

    // Start is called before the first frame update
    void Start()
    {
        //assigning refferences for animator and charcontroller component of main character                                                             // NOT OURS, TAKEN FROM INTERNET
        characterController = GetComponent<CharacterController>();
        animator = GetComponent<Animator>();
        //get refference for audiosource component of character
        JumpSound = GetComponent<AudioSource>();
    }

    void Awake()
    {
        //reset for dead check/bool
        dead = false;
    }

    // Update is called once per frame
    void Update()
    {
        //move character forward constantly, causes endlessly running effect                                                                            // NOT OURS, TAKEN FROM INTERNET
        horizontalInput = 1;
        transform.forward = new Vector3(horizontalInput, 0, Mathf.Abs(horizontalInput) - 1);

        //by-default character is not touching ground,ceiling or sliding, gets reset each update
        isGrounded = false;                                                                                                                             // NOT OURS, TAKEN FROM INTERNET
        
        isSliding = false;
        Headache = false;

        //check area around checks to see if char is touching ground    // NOT OURS, TAKEN FROM INTERNET
        foreach (var groundCheck in groundChecks)
        {
            if (Physics.CheckSphere(groundCheck.position, 0.1f, groundLayers, QueryTriggerInteraction.Ignore))
            {
                isGrounded = true;
                break;
            }
        }

        //same as above, for ceilings. different checks used
        foreach (var ceilingCheck in ceilingChecks)
        {
            if (Physics.CheckSphere(ceilingCheck.position, 0.1f, groundLayers, QueryTriggerInteraction.Ignore))
            {
                Headache = true;
                break;
            }
        }

        //dont apply gravity if player is touching ground, or do if they aren't       // NOT OURS, TAKEN FROM INTERNET
        if (isGrounded && velocity.y < 0)
        {
            velocity.y = 0;
        }
        else
        {
            velocity.y += gravity * Time.deltaTime;
        }

        //for some reason if step offset is >0 and the character runs into a 1-block high space, it gets stuck.
        //this makes step offset (which otherwise helps the player not feel cheated by missing a jump by a tiny bit) 0 if it detects a 1 block high space in front
        if (isGrounded && !Headache)
        {
            characterController.stepOffset = originalStepOffset;
        }
        else
        {
            characterController.stepOffset = 0;
        }

        //stops char from moving forward if checks detect wall in front. helps with not glitching out if player jumps while stuck from front        // NOT OURS, TAKEN FROM INTERNET
        var blocked = false;
        foreach (var wallCheck in wallChecks)
        {
            if (Physics.CheckSphere(wallCheck.position, 0.1f, groundLayers, QueryTriggerInteraction.Ignore))
            {
                blocked = true;
                break;
            }
        }

        if (!blocked)
        {
            characterController.Move(new Vector3(horizontalInput * runSpeed, 0, 0) * Time.deltaTime);
        }

        //allows player to jump if they're touching ground and press a key (space by default)       // NOT OURS, TAKEN FROM INTERNET
        if (isGrounded && Input.GetButtonDown("Jump"))
        {
            velocity.y += Mathf.Sqrt(jumpHeight * -2 * gravity);
            //plays jumping sound | ours
            JumpSound.Play();
        }

        //allows player to slide if they press a key (z by default)
        if (Input.GetKey("z"))
        {
            isSliding = true;
        }

        //apply gravity each frame. if player is touching ground velocity = 0 as shown above        // NOT OURS, TAKEN FROM INTERNET
        characterController.Move(velocity * Time.deltaTime);

        //passes variables to the animator so it can know the characters state                      // NOT OURS, TAKEN FROM INTERNET
        animator.SetFloat("Speed", horizontalInput);

        animator.SetBool("isGrounded", isGrounded);

        animator.SetFloat("VertSpeed", velocity.y);

        animator.SetBool("isSliding", isSliding);
    }
}
