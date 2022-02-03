using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ghost : MonoBehaviour
{
    private Rigidbody2D rb;
    private Animator anim;

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

    public enum Dir { NE, SE, SW, NW};
    public Dir currentDir;

    private Transform player;

    public enum MoveDir { Up, Right, Down, Left};
    public MoveDir currentMoveDir;

    List<MoveDir> possibleDirections = new List<MoveDir>();

    public GameObject sprite_regular;
    public GameObject sprite_scared;

    public GameObject deathEffect;
    public GameObject deathSoundEffect;

    public bool isScared;

    private void Start()
    {
        rb = this.GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        canMove = false;
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    private void Update()
    {
        //GhostAI();
    }

    private void FixedUpdate()
    {
        MazeCheck();
        checkIfMoving();
        GhostAI();
        Move();
        UpdateScared();
    }

    public void MazeCheck()
    {
        cantGoUp = Physics2D.OverlapCircle(UpSensor.position, checkRadius, whatIsWall);
        cantGoDown = Physics2D.OverlapCircle(DownSensor.position, checkRadius, whatIsWall);
        cantGoLeft = Physics2D.OverlapCircle(LeftSensor.position, checkRadius, whatIsWall);
        cantGoRight = Physics2D.OverlapCircle(RightSensor.position, checkRadius, whatIsWall);
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

    public void GhostAI()
    {
        if(!isMoving)
        {
            GetPlayerDirection();

            if (isScared)
            {
                MoveTowardPlayer();
            }
            else
            {
                MoveAwayFromPlayer();
            }
        }
    }

    public void Move()
    {
        if(SM.levelManager.ghostsCanMove)
        {
            if (currentMoveDir == MoveDir.Up)
                currentDirection = Vector2.up;
            else if (currentMoveDir == MoveDir.Right)
                currentDirection = Vector2.right;
            else if (currentMoveDir == MoveDir.Down)
                currentDirection = Vector2.down;
            else if (currentMoveDir == MoveDir.Left)
                currentDirection = Vector2.left;

            rb.velocity = currentDirection * speed * Time.deltaTime;
        }
        else
        {
            rb.velocity = currentDirection * 0 * Time.deltaTime;
        }
    }

    public void UpdateScared()
    {
        if (SM.levelManager.powerPillTime > 0)
        {
            isScared = true;
            sprite_regular.SetActive(false);
            sprite_scared.SetActive(true);
        }
        if (SM.levelManager.powerPillTime <= 0)
        {
            isScared = false;
            sprite_regular.SetActive(true);
            sprite_scared.SetActive(false);
        }
    }

    public void GetPlayerDirection()
    {
        if(player != null)
        {
            if (transform.position.x < player.position.x && transform.position.y < player.position.y)       // check if player is NE
                currentDir = Dir.NE;
            else if (transform.position.x < player.position.x && transform.position.y > player.position.y)       // check if player is SE
                currentDir = Dir.SE;
            else if (transform.position.x > player.position.x && transform.position.y > player.position.y)       // check if player is SW
                currentDir = Dir.SW;
            else if (transform.position.x > player.position.x && transform.position.y < player.position.y)       // check if player is NW
                currentDir = Dir.NW;
        }
    }

    public void MoveTowardPlayer()
    {
        // make a list of the directions you can go
        if (!cantGoUp)
            possibleDirections.Add(MoveDir.Up);
        if (!cantGoRight)
            possibleDirections.Add(MoveDir.Right);
        if (!cantGoDown)
            possibleDirections.Add(MoveDir.Down);
        if (!cantGoLeft)
            possibleDirections.Add(MoveDir.Left);
        // generate a random int between 0 and the list's length
        int MoveDirIndex = (Random.Range(0, possibleDirections.Count));

        bool coinFlip = (Random.value > 0.5f);

        if (currentDir == Dir.NE && !cantGoUp && !cantGoRight)
        {
            if (coinFlip)
                currentMoveDir = MoveDir.Up;
            else
                currentMoveDir = MoveDir.Right;
        }
        else if (currentDir == Dir.SE && !cantGoDown && !cantGoRight)
        {
            if (coinFlip)
                currentMoveDir = MoveDir.Down;
            else
                currentMoveDir = MoveDir.Right;
        }
        else if (currentDir == Dir.SW && !cantGoDown && !cantGoLeft)
        {
            if (coinFlip)
                currentMoveDir = MoveDir.Down;
            else
                currentMoveDir = MoveDir.Left;
        }
        else if (currentDir == Dir.NW && !cantGoUp && !cantGoLeft)
        {
            if (coinFlip)
                currentMoveDir = MoveDir.Up;
            else
                currentMoveDir = MoveDir.Left;
        }
        else
        {
            currentMoveDir = possibleDirections[MoveDirIndex];
        }
    }

    public void MoveAwayFromPlayer()
    {
        // make a list of the directions you can go
        if (!cantGoUp)
            possibleDirections.Add(MoveDir.Up);
        if (!cantGoRight)
            possibleDirections.Add(MoveDir.Right);
        if (!cantGoDown)
            possibleDirections.Add(MoveDir.Down);
        if (!cantGoLeft)
            possibleDirections.Add(MoveDir.Left);
        // generate a random int between 0 and the list's length
        int MoveDirIndex = (Random.Range(0, possibleDirections.Count));

        bool coinFlip = (Random.value > 0.5f);

        if (currentDir == Dir.NE && !cantGoUp && !cantGoRight)
        {
            if (coinFlip)
                currentMoveDir = MoveDir.Up;
            else
                currentMoveDir = MoveDir.Right;
        }
        else if (currentDir == Dir.SE && !cantGoDown && !cantGoRight)
        {
            if (coinFlip)
                currentMoveDir = MoveDir.Down;
            else
                currentMoveDir = MoveDir.Right;
        }
        else if (currentDir == Dir.SW && !cantGoDown && !cantGoLeft)
        {
            if (coinFlip)
                currentMoveDir = MoveDir.Down;
            else
                currentMoveDir = MoveDir.Left;
        }
        else if (currentDir == Dir.NW && !cantGoUp && !cantGoLeft)
        {
            if (coinFlip)
                currentMoveDir = MoveDir.Up;
            else
                currentMoveDir = MoveDir.Left;
        }
        else
        {
            currentMoveDir = possibleDirections[MoveDirIndex];
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
            if(isScared)
            {
                Instantiate(deathEffect, transform.position, transform.rotation);  // death effect\
                Instantiate(deathSoundEffect, transform.position, transform.rotation);
                Destroy(gameObject);
            }
            else
            {
                SM.levelManager.ghostsCanMove = false;
                SM.pacMan.PlayerDeath();
            }
        }
    }
}
