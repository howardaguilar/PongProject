using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    // Score Manager object
    public ScoreManager scoreManager;

    public Vector3 startPoint;
    private Rigidbody rb;
    public float amplify = 1;
    public float player1 = 0;
    public float player2 = 0;
    public float scoredOnR = 0;
    public float scoredOnL = 0;
    // Audio
    private AudioSource audioSource;
    public AudioClip clipDefault;
    public AudioClip clipPew;
    
    // Start is called before the first frame update
    void Start()
    {
        startPoint = this.transform.position;
        audioSource = GetComponent<AudioSource>();
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {

    }
    private void FixedUpdate()
    {
        // Start game
        if (Input.GetKeyDown(KeyCode.Space))
        {
            AddForce();
        }

        // Scoring rules based on position of ball
        if (rb.position.x > 10)
        {
            rb.velocity = Vector3.zero;
            rb.transform.position = startPoint;
            player1++;
            Debug.Log("Player 1 scored: " + player1 + " - " + player2);
            scoredOnR++;
            // Score text increment
            scoreManager.IncrementCount("player1");
            
 
        }
        else if (rb.position.x < -10)
        {
            rb.velocity = Vector3.zero;
            rb.transform.position = startPoint;
            player2++;
            Debug.Log("Player 2 scored: " + player1 + " - " + player2);
            scoredOnL++;
            // Score text increment
            scoreManager.IncrementCount("player2");
        }

        // End game 
        if (player1 == 11 | player2 == 11)
        {
            if (player1 > player2)
            {
                Debug.Log("Player 1 Left Paddle is the winner!!!");
            }
            else
            {
                Debug.Log("Player 2 Right Paddle is the winner!!!");
            }
            player1 = 0;
            player2 = 0;
            Debug.Log("Scores have been reset");
        }
    }

    // Surf Ball
    private void AddForce()
    {
        if (scoredOnR == 1)
        {
            rb.AddForce(new Vector3(15, 0, -5) * amplify);
            scoredOnR = 0;
        }
        else if (scoredOnL == 1)
        {
            rb.AddForce(new Vector3(-15, 0, 5) * amplify);
            scoredOnL = 0;
        }
        else
        {
            rb.AddForce(new Vector3(15, 0, 5) * amplify);
        }
        
    }

    // On collision change ball trajectory
    private void OnCollisionEnter(Collision collision)
    {
        PlayBoop();
        if (rb.position.x > 0)
        {
            rb.AddForce(new Vector3(-15, 0, 0));
            if (rb.position.x < 8 & rb.position.z > 0)
            {
                rb.AddForce(new Vector3(0, 0, -15));
            }
            else if (rb.position.x < 8 & rb.position.z < 0)
            {
                rb.AddForce(new Vector3(0, 0, 15));
            }
            
        }
        else
        {
            rb.AddForce(new Vector3(15, 0, 0));
            if (rb.position.x > -8 & rb.position.z > 0)
            {
                rb.AddForce(new Vector3(0, 0, -15));
            }
            else if (rb.position.x > 8 & rb.position.z < 0)
            {
                rb.AddForce(new Vector3(0, 0, 15));
            }
        }
        
    }

    // Power Ups
    private void OnTriggerEnter(Collider other)
    {
        if (other.name == "PowerUp")
        {
            rb.transform.localScale += new Vector3(0.3f, 0.3f, 0.3f);
        }
        else if (other.name == "PowerDown")
        {
            rb.transform.localScale += new Vector3(-0.3f, -0.3f, -0.3f);
        }
    }

    // Sound effects
    public void PlayBoop()
    {
        if (rb.velocity.magnitude > 5)
        {
            audioSource.PlayOneShot(clipPew);
        }
        else
        {
            audioSource.PlayOneShot(clipDefault);
        }

    }
}
