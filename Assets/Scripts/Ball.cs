using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    private Rigidbody rb;
    public float amplify = 1;
    public float player1 = 0;
    public float player2 = 0;
    public float scoredOnR = 0;
    public float scoredOnL = 0;
    // Audio
    public AudioClip boop;
    AudioSource impact;
    
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        impact = GetComponent<AudioSource>();
        
    }

    // Update is called once per frame
    void Update()
    {
       
    }
    private void FixedUpdate()
    {
        //rb.AddForce(new Vector3(1,0,0) * amplify);
        if (Input.GetKeyDown(KeyCode.Space)) { AddForce(); }

        if (rb.position.x > 10)
        {
            rb.velocity = Vector3.zero;
            rb.transform.Translate(new Vector3(-10, 0, 0));
            player1++;
            Debug.Log("Player 1 scored: " + player1 + " - " + player2);
            scoredOnR++;
 
        }
        else if (rb.position.x < -10)
        {
            rb.velocity = Vector3.zero;
            rb.transform.Translate(new Vector3(10, 0, 0));
            player2++;
            Debug.Log("Player 2 scored: " + player1 + " - " + player2);
            scoredOnL++;
        }

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

    private void AddForce()
    {
        if (scoredOnR == 1)
        {
            rb.AddForce(new Vector3(15, 0, 0) * amplify);
            scoredOnR = 0;
        }
        else if (scoredOnL == 1)
        {
            rb.AddForce(new Vector3(-15, 0, 0) * amplify);
            scoredOnL = 0;
        }
        else
        {
            rb.AddForce(new Vector3(15, 0, 0) * amplify);
        }

        /*if (player1 > player2)
        {
            rb.AddForce(new Vector3(15, 0, 0) * amplify);
        }
        else
        {
            rb.AddForce(new Vector3(-15, 0, 0) * amplify);
        }*/
        
    }

    

    private void OnCollisionEnter(Collision collision)
    {
        PlayBoop();
        if (rb.position.x > 0)
        {
            rb.AddForce(new Vector3(-15, 0, 0));
        }
        else
        {
            rb.AddForce(new Vector3(15, 0, 0));
        }
        
    }

    public void PlayBoop()
    {
        impact.PlayOneShot(boop, 1);
    }
}
