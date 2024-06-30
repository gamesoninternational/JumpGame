using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using Random=UnityEngine.Random;

public class Obstacle : MonoBehaviour
{
    private Animator animator;
    private bool GetCoin;
    private bool isStopped = false; // Boolean to track if the obstacle should stop moving

    // Speed at which the obstacle moves towards the center
    private float speed;

    // Minimum and maximum speed values
    public float minSpeed = 2f;
    public float maxSpeed = 5f;

    public GameObject PlayerAnim;

    void Start()
    {
        // Assign a random speed within the specified range
        speed = Random.Range(minSpeed, maxSpeed);

        // Mengambil komponen Animator dari objek ini
        animator = GetComponent<Animator>();
        
        // Periksa apakah Animator ditemukan
        if (animator == null)
        {
            Debug.LogError("Animator not found on " + gameObject.name);
        }

        PlayerAnim = GameObject.FindGameObjectWithTag("Player");
    }

    void Update()
    {
        if (isStopped) return; // Stop moving if isStopped is true

        // Calculate the step size based on speed and frame time
        float step = speed * Time.deltaTime;

        // Move the obstacle towards the center (X = 0)
        transform.position = Vector3.MoveTowards(transform.position, new Vector3(0f, transform.position.y, transform.position.z), step);

        
    }

    void OnCollisionEnter2D (Collision2D col){
        if (col.transform.tag == "Player"){
            //Debug.Log("Nabrak Player Tag");
            isStopped = true; // Stop the obstacle from moving
            animator.SetTrigger("ObstacleAnim");
            if (GetCoin == false)
            {
                if (Mathf.Approximately(transform.position.x, 0))
                {
                    //Debug.Log(gameObject.name + " is at X position 0");
                    GlobalVar.AddComboCoin();
                    GlobalVar.SaveCoinTotal();
                    GetCoin = true;
                }
                else
                {
                    //Debug.Log(gameObject.name + " is not at X position 0");
                    GlobalVar.AddCoin();
                    GlobalVar.SaveCoinTotal();
                    GetCoin = true;
                }
            }
        }

        if (col.transform.tag == "HitLeft")
        {
            isStopped = true; // Stop the obstacle from moving
            Debug.Log("Hit Left");
            GameManager.Instance.GameOver();
            PlayerAnim.GetComponent<PlayerController>().GameOverLeft();
        }
        if (col.transform.tag == "HitRight")
        {
            isStopped = true; // Stop the obstacle from moving
            GameManager.Instance.GameOver();
            Debug.Log("Hit Right");
            PlayerAnim.GetComponent<PlayerController>().GameOverRight();
        }
    }

    
}
