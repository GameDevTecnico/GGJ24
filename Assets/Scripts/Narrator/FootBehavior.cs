using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FootBehavior : MonoBehaviour
{
    [SerializeField] private Transform leftBound;
    [SerializeField] private Transform rightBound;
    [SerializeField] private Transform upperBound;

    [SerializeField] private int trampleSequence = 3;
    [SerializeField] private float trampleCooldown = 10f;
    [SerializeField] private float cooldownTime = 3f;

    [SerializeField] private float moveSpeed = 1f;
    [SerializeField] private float footSpeed = 3f;

    [SerializeField] private Transform player;

    [SerializeField] private float distanceForTickle;
    

    enum State
    {
        Idle,
        Trampling,
        AfterTrample,
        Cooldown
    }

    private State state = State.Idle;
    private float currentTrampleCooldown = 0f;
    private float tramplePosition;
    private int currentTrampleSequence = 0;
    private float currentCooldownTime = 0f;

    private bool tickledThisTurn = false;
    private int timesTickled = 0;

    private Rigidbody2D rb;


    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void FixedUpdate()
    {
        currentTrampleCooldown += Time.deltaTime;

        if (currentTrampleCooldown > trampleCooldown)
        {
            InitiateTrample();
        }

        switch (state)
        {
            case State.Idle:
                break;
            case State.Trampling:
                Trample();
                break;
            case State.AfterTrample:
                AfterTrample();
                break;
            case State.Cooldown:
                InCooldown();
                break;
        }

        if(timesTickled >= 3)
        {
            //TODO: End game
        }

    }

    void InitiateTrample()
    {
        currentTrampleCooldown = 0f;
        currentCooldownTime = 0f;

        currentTrampleSequence++;

        tickledThisTurn = false;

        tramplePosition = Random.Range(leftBound.position.x, rightBound.position.x);
        rb.position = new Vector2(tramplePosition, rb.position.y);

        state = State.Trampling;
    }

    //Foot when trampling (Going down)
    void Trample()
    {
        rb.velocity = new Vector2(rb.velocity.x, - footSpeed * moveSpeed);

        if (Mathf.Abs(transform.position.y - leftBound.position.y) < 0.1f)
        {
            rb.velocity = new Vector2(rb.velocity.x, 0f);

            if(currentTrampleSequence >= trampleSequence)
            {
                state = State.Cooldown;
                currentTrampleSequence = 0;
            }
            else
            {
                state = State.AfterTrample;
            }

        }
    }

    //Foot after trampling (Going up)
    void AfterTrample()
    {
        rb.velocity = new Vector2(rb.velocity.x, footSpeed * moveSpeed);

        if (Mathf.Abs(transform.position.y - upperBound.position.y) < 0.1f)
        {
            rb.velocity = new Vector2(rb.velocity.x, 0f);
            state = State.Idle;
        }
    }

    //Foot is vulnerble after trampling
    void InCooldown()
    {
        currentCooldownTime += Time.deltaTime;

        if (currentCooldownTime > cooldownTime)
        {
            state = State.AfterTrample;
        }
    }

    public bool isTickable()
    {
        if(state == State.Cooldown && (Mathf.Abs(transform.position.x - player.position.x) < distanceForTickle) && !tickledThisTurn)
        {
            tickledThisTurn = true;
            timesTickled++;
            return true;
        }
        return false;
    }
}
