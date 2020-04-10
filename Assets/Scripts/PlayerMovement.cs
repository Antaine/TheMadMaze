using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Windows.Speech;

public class PlayerMovement : MonoBehaviour
{
    public CharacterController controller;
    public float speed = 12f;
    public float gravity = - 18.81f;
    public float jumpHeight = 3f;

    public Transform groundCheck;
    public float groundDistance = 0.04f;
    public LayerMask groundMask;

    Vector3 velocity;
    bool isGrounded;

    public string[] keywords = new string[] { "jump", "pause", "play", "run","brake" };
    public ConfidenceLevel confidence = ConfidenceLevel.Medium;
    public Text results;
    protected PhraseRecognizer recognizer;
    protected string word = "";

    private void Start()
    {
        if (keywords != null)
        {
            recognizer = new KeywordRecognizer(keywords, confidence);
            recognizer.OnPhraseRecognized += Recognizer_OnPhraseRecognized;
            recognizer.Start();
        }
    }

    //Turn into feedback to verify command
    private void Recognizer_OnPhraseRecognized(PhraseRecognizedEventArgs args)
     {
         word = args.text;
        // results.text = "You said: <b>" + word + "</b>";
     }

    // Update is called once per frame
    void Update()
    {
        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);
        if(isGrounded && velocity.y < 0)
        {
            //Debug.Log("Grounded Button");
            velocity.y = -2f;
        }
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        Vector3 move = transform.right * x + transform.forward * z;
        controller.Move(move * speed * Time.deltaTime);

        if(Input.GetButtonDown("Jump") && isGrounded)
        {
            //Debug.Log("Grounded Button Down");
            velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity);
        }

        switch (word)
        {
            case "jump":
                Debug.Log("Jump");
                velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity);
                word = "";
                break;
            case "run":
                Debug.Log("Sprint");
                speed +=8;
                word = "";
                break;
            case "pause":
                Debug.Log("Stop");
                speed = 0f;
                word = "";
                break;

        }
        velocity.y += gravity * Time.deltaTime;
        controller.Move(velocity * Time.deltaTime);

    }
}
