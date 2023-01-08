using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class NinjaController : MonoBehaviour
{
    Animator animator;
    // Belli bir süre boyunca hiçbir tuşa basılmaması gereken zaman dilimi (saniye cinsinden)
    public float idleTime = 0.25f;
    float idleStartTime;
    public float moveSpeed = 5f;
    public float jumpForce = 500f;
    private bool isJumping = false;
    bool isGrounded = false;
    Rigidbody rb;
    public float maxFallSpeed = 2.5f;
    public int damageTaken = 0;
    float can = 100.0f;
    float anlikCan= 100.0f;
    public Image can_bar;
    public GameObject panel;
    Text t1 = new Text();

    void Start()
    {
        animator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {

        if (!Input.anyKey)
        {
            animator.SetBool("run1",false);
        }

        if (Input.GetKey(KeyCode.A))
        {
            animator.SetBool("run1",true);
            transform.position += Vector3.left * moveSpeed * Time.deltaTime;
            transform.rotation = Quaternion.Euler(0, 270, 0);
        }

        if (Input.GetKey(KeyCode.D))
        {
            animator.SetBool("run1",true);
            transform.position += Vector3.right * moveSpeed * Time.deltaTime;
            transform.rotation = Quaternion.Euler(0, 90, 0);
        }

        if (Input.GetKeyDown(KeyCode.Space) && !isJumping)
        {
            animator.SetTrigger("jump");
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            GetComponent<Rigidbody>().velocity = new Vector3(GetComponent<Rigidbody>().velocity.x, Mathf.Clamp(GetComponent<Rigidbody>().velocity.y, -maxFallSpeed, Mathf.Infinity), GetComponent<Rigidbody>().velocity.z);

            isJumping=true;
        }
        
    }

    public int getdamageTaken(){
        return this.damageTaken;
    }

    void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag == "Ground")
        {
            isGrounded = true;
            isJumping = false;
        }

        if (other.gameObject.tag == "Ball")
        {
            // Hasar sayacını 1 arttır
            damageTaken++;
            anlikCan -= 34.0f;
            can_bar.fillAmount = anlikCan/can;
            Debug.Log(damageTaken);

            if(damageTaken>2)
            {
                panel.SetActive(true);
                Time.timeScale = 0.0f;
            }
        }
    }
}