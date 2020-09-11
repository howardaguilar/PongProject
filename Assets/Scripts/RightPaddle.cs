using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RightPaddle : MonoBehaviour
{
    public float amplify = 5;
    public float player2 = 0;
    

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.UpArrow))
        {
            if ((transform.position.z) < 5.5)
            {
                transform.Translate(new Vector3(0, 0, Input.GetAxis("Vertical") + 5) * Time.deltaTime * amplify);
            }
            else if ((transform.position.z) >= 5.5)
            {
                transform.Translate(new Vector3(0, 0, Input.GetAxis("Vertical") + 5) * Time.deltaTime * amplify * -5);
            }
        }
        else if (Input.GetKey(KeyCode.DownArrow))
        {
            if ((transform.position.z) > -5.5)
            {
                transform.Translate(new Vector3(0, 0, Input.GetAxis("Vertical") - 5) * Time.deltaTime * amplify);
            }
            else if ((transform.position.z) <= -5.5)
            {
                transform.Translate(new Vector3(0, 0, Input.GetAxis("Vertical") + 5) * Time.deltaTime * amplify * +5);
            }
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        /*player2++;
        Debug.Log("Player 2 score: " + player2);
        collision.transform.Translate(new Vector3(5, 0, 0));*/
    }

}
