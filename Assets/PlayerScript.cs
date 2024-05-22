using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour
{
    public Rigidbody rb;
    private AudioSource audioSource;
    private bool isBlock = true;
    float moveSpeed = 2.0f;
    float jump = 8.0f;
    // Start is called before the first frame update
    void Start()
    {
        audioSource = gameObject.GetComponent<AudioSource>();
        GameManagerScript.score = 0;
    }


    void FixedUpdate()
    {
        if (GoalScript.isGameClear) 
        {

        }
        else
        {
            Vector3 v = rb.velocity;
            if (Input.GetKey(KeyCode.LeftShift))
            {
                moveSpeed = 5.0f;
            }else
            {
                moveSpeed = 2.0f;
            }
            if (Input.GetKey(KeyCode.D))
            {
                v.x = moveSpeed;
            }
            else if(Input.GetKey(KeyCode.A))
            {
                v.x = -moveSpeed;
            }
            else
            {
                v.x = 0;
            }
            if (Input.GetKeyDown(KeyCode.Space) && isBlock)
            {
                v.y = jump;
            }
            rb.velocity = v;

        }

    }
    // Update is called once per frame
    void Update()
    {
        Vector3 rayPos = transform.position;
        Ray ray = new Ray(rayPos, Vector3.down);
        float distance = 0.6f;
        isBlock = Physics.Raycast(ray, distance);

        if(isBlock) {
            Debug.DrawRay(rayPos, Vector3.down * distance, Color.red);
        }
        else
        {
            Debug.DrawRay(rayPos, Vector3.down * distance, Color.yellow);
        }
        
        Vector3 v = rb.velocity;
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "COIN")
        {
            other.gameObject.SetActive(false);
            audioSource.Play();
            GameManagerScript.score += 1;
        }
    }
}
