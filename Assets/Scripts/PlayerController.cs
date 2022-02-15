using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    private Rigidbody rb;
    public bool isGrounded = true;
    public float movementSpeed = 10f;

    public AudioSource coinsound;
    public AudioSource JumpSound;

    public float Jumpforce = 10f;
    public SpawnManager spawnManager;

    public Canvas GameOverScreen;
    public Canvas ScoreSystem;
    public bool CollisionCheck = false;

    public Text score;
    public float scoreDisplay;
    private float Display;

    public Text FinalScore;
    //public Text FinalCoin;

    public Text CoinCollection;
    public int coincollect;

    private Animator anim;

    
    private Collider coll;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {

        scoreSystem();



        float hMovement = Input.GetAxis("Horizontal") * movementSpeed / 2;
        float vMovement =  movementSpeed;
        speedIncrement();

        transform.Translate(new Vector3(hMovement, 0, vMovement) * Time.deltaTime);


            

        
        
            anim.SetInteger("State", 1);
        


       
            if(Input.GetKey(KeyCode.Space))
        {
            Jump();
            anim.SetInteger("State", 2);
            JumpSound.Play();
        }



    }

      

    private void Jump()
    {
        if (isGrounded == true)
        {
            rb.velocity = new Vector3(rb.velocity.x, Jumpforce);
            isGrounded = false;
        }
    }

    
    private void OnTriggerEnter(Collider other)
    {
        spawnManager.SpawnTriggerEntered();
    }


    private void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.tag == "Ground")
        {
            isGrounded = true;
        }
        if (col.gameObject.tag == "Obstacle")
        {
            CollisionCheck = true; 
            GameOverScreen.GetComponent<Canvas>().enabled = true;
            ScoreSystem.GetComponent<Canvas>().enabled = false; 

            FinalScore.text = scoreDisplay.ToString("Score  " + scoreDisplay + "\nCoins  " + coincollect);
          //  FinalCoin.text = scoreDisplay.ToString("Coins " + coincollect);
        }

        if(col.gameObject.tag == "Obstacle")
        {
            anim.SetInteger("State", 3);
        }
        if(col.gameObject.tag == "Coin" )
        {
            coincollect++;
            CoinCollection.text = coincollect.ToString("Coins: " + coincollect);
            coinsound.Play();
        }

    }


    public void scoreSystem()
    {
        Display = transform.position.z + 26.09f;
        scoreDisplay = Display / 5;
        scoreDisplay = Mathf.Floor(scoreDisplay);
        score.text = scoreDisplay.ToString("Score: " + scoreDisplay);

    }

    public void speedIncrement()
    {
        movementSpeed += 0.01f;
    }
}
