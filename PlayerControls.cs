using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerControls : MonoBehaviour
{
    public CameraController Camscript;
    public Rigidbody2D rb;
    public Animator anim;

    public Transform respawnboxOne;
    public Transform respawnboxTwo;
    public Transform respawnboxThree;
    public Transform respawnboxFour;

    public swordScript KillCount;

    public int AttackS;
    public int[] AttackStates;

    private Transform m_currMovingPlatform;

    public Transform teleporter2;

    public AudioClip musicClipJump;

    public AudioSource jumpingSound;
    public AudioSource walkingSound;
    public AudioSource runningSound;
    public AudioSource JewelSoud;
    public AudioSource MonsterDeathSound;

    private Vector3 thetVelocity = Vector3.zero;

    public float speed;
    public float JumpSpeed;

    private readonly float MovementSmoothing = .05f;

    public GameObject ControlPanel;
    private bool ControlPanelActivity;

    public GameObject Sword;
    public bool SwordActivity;


    public bool jumping;
    private bool facingRight;

    public int Jewels;
    public int Score;
    private int Lives;
    private string sceneName;

    private Random rand;

    public Text JewelCount;
    public Text WinText;
    public Text LoseText;
    public Text ScoreText;
    public Text LivesText;

    private bool PlayerAlive;


    void Start()
    {
        ControlPanelActivity = true;
        PlayerAlive = true;
        rb = GetComponent<Rigidbody2D>();
        facingRight = true;
        jumping = false;
        Lives = 100;
        Score = 0;
        Jewels = 0;
        WinText.text = "";
        LoseText.text = "";
        ScoreText.text = "";
        JewelCount.text = "";
        LivesText.text = "";
        SetAllText();


        Scene currentScene = SceneManager.GetActiveScene();

        sceneName = currentScene.name;

    }

    private void Update()
    {
        if (Lives > 0)
        {
            PlayerAlive = true;
        }

        if (Lives <= 0)
        {
            PlayerAlive = false;
        }

       if (ControlPanel.gameObject.activeSelf)
       {
            ControlPanelActivity = true;
            Time.timeScale = 0;
        }
        else
        {
            ControlPanelActivity = false;
            Time.timeScale = 1;
        }
        if (ControlPanelActivity == true)
        {
            if ((Input.GetKeyDown(KeyCode.Return)) || (Input.GetKeyDown(KeyCode.KeypadEnter)))
            {
                ControlPanel.gameObject.SetActive(false);
            }
        }
        else if (ControlPanelActivity == false)
        {
            if ((Input.GetKeyDown(KeyCode.Return)) || (Input.GetKeyDown(KeyCode.KeypadEnter)))
            {
                ControlPanel.gameObject.SetActive(true);
            }
        }

        anim = GetComponent<Animator>();
        HandJumpAndFall();


        if (Input.GetKey(KeyCode.Escape))
        {
            Application.Quit();
        }

        if (Input.GetKey(KeyCode.R))
        {
            SceneManager.LoadScene("firstlevel");
        }


        if (Jewels == 22)
        {
            if ((Input.GetKey(KeyCode.KeypadEnter)) || (Input.GetKey(KeyCode.Return)))
            {
                SceneManager.LoadScene(1);
            }
        }



        AttackStates = new int[] { 1, 2, 3, 4 };
        for (var i = 0; i < AttackStates.Length; i++)
       
        if (Input.GetKey(KeyCode.LeftControl))
        {
            {
                    AttackS = Random.Range(1, AttackStates.Length);
                    anim.SetInteger("Astate", AttackS);
            }
        }
        else if (Input.GetKeyUp(KeyCode.LeftControl))
        {
            anim.SetInteger("Astate", 0);
            anim.SetInteger("State", 0);
        }

        if (Sword.gameObject.activeSelf)
        {
            SwordActivity = true;
        }
        else
        {
            SwordActivity = false;
        }
    }
    private void FixedUpdate()
    {

        if (PlayerAlive == true)
        {
            float moveHorizontal = Input.GetAxis("Horizontal");

            Vector2 targetVelocity = new Vector2(moveHorizontal * speed, rb.velocity.y);
            rb.velocity = Vector3.SmoothDamp(rb.velocity, targetVelocity, ref thetVelocity, MovementSmoothing);
            Flip(moveHorizontal);
        }

        else if (PlayerAlive == false)
        {
            float moveHorizontal = 0;

            Vector2 targetVelocity = new Vector2(moveHorizontal * speed, 0);
            rb.velocity = Vector3.SmoothDamp(rb.velocity, targetVelocity, ref thetVelocity, MovementSmoothing);
           // Flip(moveHorizontal);
        }
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        if ((collision.collider.tag == "Ground"))
        {
            m_currMovingPlatform = collision.gameObject.transform;
            transform.SetParent(m_currMovingPlatform);

            walkingSound.Pause();
            runningSound.Pause();

            anim.SetInteger("State", 0);
            jumping = false;

            if (Input.GetKey(KeyCode.Space) && (PlayerAlive == true))
            {
                Vector2 jumpUp = Vector2.up * JumpSpeed;
                rb.velocity = jumpUp;
                jumping = true;
                jumpingSound.clip = musicClipJump;
                jumpingSound.Play();
            }

            if (Input.GetKey(KeyCode.LeftShift))
            {
                speed = 7;
            }
            else
            {
                speed = 5;
            }

            if ((Input.GetKey(KeyCode.RightArrow) && (speed == 5)) || (Input.GetKey(KeyCode.LeftArrow) && (speed == 5)))
            {
                anim.SetInteger("State", 1);


            }
            else if ((Input.GetKey(KeyCode.RightArrow) && (speed == 7)) || (Input.GetKey(KeyCode.LeftArrow) && (speed == 7)))
            {
                anim.SetInteger("State", 4);
            }
            else
            {
                anim.SetInteger("State", 0);

            }

            if (
                (rb.velocity.x > 0.5f) && (speed == 5) || (rb.velocity.x < -0.5f) && (speed == 5)
                )
            {
                walkingSound.Play();
            }
            if (
                 (rb.velocity.x > 0.5f) && (speed == 7) || (rb.velocity.x < -0.5f) && (speed == 7)
                   )
            {
                runningSound.Play();
            }


        }
        if ((collision.collider.CompareTag("Enemy")) && (SwordActivity == false))
        {
            rb.velocity= new Vector2(-20, 1);
            Score = Score - 1;
            Lives = Lives - 20;
            SetAllText();

        }
        else if ((collision.collider.CompareTag("Enemy")) && (SwordActivity == true))
        {

            Score = Score + 10;
            SetAllText();
        }

    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if ((other.gameObject.CompareTag("jewel")))
        {
            other.gameObject.SetActive(false);
            Jewels = Jewels + 1;
            Score = Score + 1;
            SetAllText();
            JewelSoud.Play();

        }
        if ((other.gameObject.CompareTag("Teleporter1")))
        {
            rb.transform.position = teleporter2.transform.position;
            Lives = Lives - 10;
            SetAllText();
        }

        if (other.gameObject.CompareTag("fallingbound1"))
        {

            rb.transform.position = respawnboxOne.transform.position;
            Lives = Lives - 30;
            SetAllText();
        }

        if (other.gameObject.CompareTag("fallingbound2"))
        {

            rb.transform.position = respawnboxTwo.transform.position;
            Lives = Lives - 30;
            SetAllText();
        }
        if (other.gameObject.CompareTag("fallingbound3"))
        {

            rb.transform.position = respawnboxThree.transform.position;
            Lives = Lives - 30;
            SetAllText();
        }
        if (other.gameObject.CompareTag("fallingbound4"))
        {

            rb.transform.position = respawnboxFour.transform.position;
            Lives = Lives - 30;
            SetAllText();
        }
    }

    void HandJumpAndFall()
    {

        if (jumping)

            if (rb.velocity.y > 0)
            {
                anim.SetInteger("State", 2);
            }
            else if (rb.velocity.y < 0)
            {
               anim.SetInteger("State", 3);
            }


    }

    public void SetAllText()
    {
        JewelCount.text = "" + Jewels.ToString();
        ScoreText.text = "Score : " + Score.ToString();
        LivesText.text = "HP : %" + Lives.ToString();
        if (sceneName == "firstlevel")

        {
            if (Jewels == 20)
            {
                JewelCount.text = "";
                ScoreText.text = "";
                LivesText.text = "";
                WinText.text = "Game Over";
                return;

            }
            else if (Lives <= 0)
            {
                JewelCount.text = "";
                ScoreText.text = "";
                LivesText.text = "";
                LoseText.text = "YOU DIED";
                anim.SetInteger("State", 5);
               // rb.gameObject.SetActive(false);

            }

        }
    }
   private void Flip(float moveHorizontal)
   {
        if (moveHorizontal > 0 && !facingRight || moveHorizontal < 0 && facingRight)
        {
            facingRight = !facingRight;
            Vector3 theScale = transform.localScale;

            theScale.x *= -1;
            transform.localScale = theScale;
        }
        
   }

}
