using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PacMan : MonoBehaviour
{
    private Rigidbody2D rb;
    private Animator anim;
    public AudioSource runSound;
    public float speed;
    [SerializeField]
    Vector2 currentDirection;
    public bool isMoving;
    public bool canMove;

    public bool cantGoUp;
    public bool cantGoDown;
    public bool cantGoLeft;
    public bool cantGoRight;
    public Transform UpSensor;
    public Transform DownSensor;
    public Transform LeftSensor;
    public Transform RightSensor;
    public LayerMask whatIsWall;
    public float checkRadius;

    public float deathDuration;
    public float gameOverDuration;
    public GameObject playerDeathSound;
    public GameObject playerDeathEffect;
    //public GameObject playerSprite;
    public SpriteRenderer playerSprite;
    public GameObject GameOverUI;
    public GameObject GameOverSound;
    private SceneLoader sceneLoader;

    //public bool canEatGhosts;

    private void Awake()
    {
        SM.pacMan = this;
    }

    private void Start()
    {
        sceneLoader = GameObject.FindObjectOfType<SceneLoader>();
        rb = this.GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        playerSprite = GetComponent<SpriteRenderer>();
        runSound = GetComponent<AudioSource>();
        canMove = false;
    }

    private void Update()
    {
        PlayerInput();
    }

    private void FixedUpdate()
    {
        MazeCheck();
        Sunbeam();
        MovePlayer(currentDirection);
        checkIfMoving();
        AnimationHandling();
        //PacManSound();
    }

    public void PlayerInput()
    {
        if(canMove)
        {
            if (Input.GetKey(KeyCode.W) && !cantGoUp)
                currentDirection = Vector2.up;
            if (Input.GetKey(KeyCode.A) && !cantGoLeft)
                currentDirection = Vector2.left;
            if (Input.GetKey(KeyCode.S) && !cantGoDown)
                currentDirection = Vector2.down;
            if (Input.GetKey(KeyCode.D) && !cantGoRight)
                currentDirection = Vector2.right;
        }
        
    }

    public void MazeCheck()
    {
        cantGoUp = Physics2D.OverlapCircle(UpSensor.position, checkRadius, whatIsWall);
        cantGoDown = Physics2D.OverlapCircle(DownSensor.position, checkRadius, whatIsWall);
        cantGoLeft = Physics2D.OverlapCircle(LeftSensor.position, checkRadius, whatIsWall);
        cantGoRight = Physics2D.OverlapCircle(RightSensor.position, checkRadius, whatIsWall);
    }

    public void Sunbeam()
    {
        if (SM.levelManager.powerPillTime > 0)
        {
            anim.SetBool("SunbeamMode", true);
        }
        if (SM.levelManager.powerPillTime <= 0)
        {
            anim.SetBool("SunbeamMode", false);
        }
    }

    public void MovePlayer(Vector2 direction)
    {
        if(canMove)
            rb.velocity = direction * speed * Time.deltaTime;
        else
            rb.velocity = direction * 0 * Time.deltaTime;
    }

    public void AnimationHandling()
    {
        if(SM.levelManager.powerPillTime < 0.1)
        {
            anim.SetFloat("DirX", currentDirection.x);
            anim.SetFloat("DirY", currentDirection.y);
        }
    }

    public void PacManSound()
    {
        if (isMoving)
        {
            if (!runSound.isPlaying)
                runSound.Play();     // play sound
        }
        else
        {
            if (runSound.isPlaying)
                runSound.Stop();    // do not play sound
        }
    }

    public void checkIfMoving()
    {
        if (currentDirection == Vector2.up && cantGoUp)
            isMoving = false;
        if (currentDirection == Vector2.up && !cantGoUp)
            isMoving = true;

        if (currentDirection == Vector2.down && cantGoDown)
            isMoving = false;
        if (currentDirection == Vector2.down && !cantGoDown)
            isMoving = true;

        if (currentDirection == Vector2.left && cantGoLeft)
            isMoving = false;
        if (currentDirection == Vector2.left && !cantGoLeft)
            isMoving = true;

        if (currentDirection == Vector2.right && cantGoRight)
            isMoving = false;
        if (currentDirection == Vector2.right && !cantGoRight)
            isMoving = true;
    }

    public void PlayerDeath()
    {
        StartCoroutine("PlayerDeathCo");
    }

    public IEnumerator PlayerDeathCo()
    {
        SM.livesManager.TakeLife();

        canMove = false;

        playerSprite.enabled = false;
        Instantiate(playerDeathEffect, transform.position, transform.rotation);

        Instantiate(playerDeathSound, transform.position, transform.rotation);      // play death sound effect

        yield return new WaitForSeconds(deathDuration);

        SM.gameData.currentScore = SM.scoreManager.score;

        if(SM.livesManager.lifeCounter <= 0)
        {
            GameOver();
        }
        else
        {
            sceneLoader.LoadScene("Game");
        }

    }

    public void GameOver()
    {
        StartCoroutine("GameOverCo");
    }

    public IEnumerator GameOverCo()
    {
        Instantiate(GameOverUI, Vector3.zero, Quaternion.identity);
        Instantiate(GameOverSound, Vector3.zero, Quaternion.identity);
        SM.gameData.currentLives = 3;
        SM.gameData.currentScore = 0;

        yield return new WaitForSeconds(deathDuration);

        sceneLoader.LoadScene("Menu_b");
    }


}
