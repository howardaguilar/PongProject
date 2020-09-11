using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Paddle : MonoBehaviour
{
    public float amplify = 1;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Mathf.Abs(transform.position.z) < 5.5)
        {
            transform.Translate(new Vector3(0, 0, Input.GetAxis("Vertical")) * Time.deltaTime * amplify);
        }
        else if (Mathf.Abs(transform.position.z) >= 5.5)
        {
            transform.Translate(new Vector3(0, 0, Input.GetAxis("Vertical")) * Time.deltaTime * amplify * -1);
        }
        else if (Mathf.Abs(transform.position.z) <= -5.5)
        {
            transform.Translate(new Vector3(0, 0, Input.GetAxis("Vertical")) * Time.deltaTime * amplify * 1);
        }

    }
}
