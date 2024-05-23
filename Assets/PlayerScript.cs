using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class PlayerScript : MonoBehaviour
{
    CharacterController controller;
    Animator animator;
    private AudioSource audioSource;
    private bool isBlock = true;

    float normalSpeed = 1.0f;
    float sprintSpeed = 3.0f;
    float jump = 12.0f;
    float gravity = 9.14f;

    Vector3 moveDirection = Vector3.zero;
    Vector3 startPos;

    // Start is called before the first frame update
    void Start()
    {
        controller = GetComponent<CharacterController>();
        animator = GetComponent<Animator>();
        audioSource = gameObject.GetComponent<AudioSource>();
        GameManagerScript.score = 0;

        //Cursor.visible = false;
        //Cursor.lockState = CursorLockMode.Locked;

        startPos = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        float speed = Input.GetKey(KeyCode.LeftShift) ? sprintSpeed : normalSpeed;

        Vector3 cameraForward = Vector3.Scale(Camera.main.transform.forward, new Vector3(1, 0, 1)).normalized;

        //Vector3 moveZ = cameraForward * Input.GetAxis("Vertical") * speed;
        Vector3 moveX = Camera.main.transform.right * Input.GetAxis("Horizontal") * speed;

        if (GoalScript.isGameClear)
        {

        }
        else
        {
            if (controller.isGrounded)
            {
                moveDirection =  moveX;
                if (Input.GetButtonDown("Jump") && isBlock)
                {
                    animator.SetBool("Space_Jump", true);
                    moveDirection.y = jump;
                }
                else
                {
                    animator.SetBool("Space_Jump", false);
                }
            }
            else
            {

                moveDirection =  moveX + new Vector3(0, moveDirection.y, 0);
                moveDirection.y -= gravity * Time.deltaTime;
            }
        }
        // 移動のアニメーション
        animator.SetFloat("MoveSpeed", ( moveX).magnitude);

        // プレイヤーの向きを入力の向きに変更　
        transform.LookAt(transform.position + moveX);

        // Move は指定したベクトルだけ移動させる命令
        controller.Move(moveDirection * Time.deltaTime);

        Vector3 rayPos = transform.position;
        Ray ray = new Ray(rayPos, Vector3.down);
        float distance = 0.6f;
        isBlock = Physics.Raycast(ray, distance);

        if (isBlock)
        {
            Debug.DrawRay(rayPos, Vector3.down * distance, Color.red);
        }
        else
        {
            Debug.DrawRay(rayPos, Vector3.down * distance, Color.yellow);
        }

        //Vector3 v = rb.velocity;
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "COIN")
        {
            other.gameObject.SetActive(false);
            audioSource.Play();
            GameManagerScript.score += 1;
        }
    }

}
