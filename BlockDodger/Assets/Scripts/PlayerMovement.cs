using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public Rigidbody rb;

    public float forwardMovement;
    public float forwardMovementAcceleration;
    public float forwardSpeedLimit;
    public float forwardSpeedLimitMax;
    public float forwardSpeedLimitMin;
    public float boundary = 4f;
    public float teleportCooldown = 5f;
    public float teleportLength = 5f;
    [HideInInspector]
    public float playerSpeed;


    //Make boolean checks for s key and w key to be applied in FixedUpdate
    private bool canSpeedUp;
    private bool canSlowDown;
    [HideInInspector]
    public bool canTeleport = true;
    private GlobalGameManager globalGameManager;
    private LevelManager manager;
    private Vector3 playerVelocity;
    private Vector3 originalPlayerPosition;
    private float originalSpeedLimit;
    // Start is called before the first frame update
    void Start()
    {
        globalGameManager = FindObjectOfType<GlobalGameManager>();
        manager = FindObjectOfType<LevelManager>();
        originalPlayerPosition = new Vector3(rb.transform.position.x, rb.transform.position.y, rb.transform.position.z);
        originalSpeedLimit = forwardSpeedLimit;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            manager.PauseGame();
        }
        if (Input.GetKeyDown(KeyCode.A))
        {
            float newPositionLeft = Mathf.Clamp(rb.position.x + 1, originalPlayerPosition.x - boundary, originalPlayerPosition.x + boundary);
            rb.position = new Vector3(newPositionLeft, rb.position.y, rb.position.z);
        }
        if (Input.GetKeyDown(KeyCode.D))
        {
            float newPositionRight = Mathf.Clamp(rb.position.x - 1, originalPlayerPosition.x - boundary, originalPlayerPosition.x + boundary);
            rb.position = new Vector3(newPositionRight, rb.position.y, rb.position.z);
        }

        if (globalGameManager.currentLevel >= 3)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                if (rb.position.y == originalPlayerPosition.y)
                {
                    rb.position = new Vector3(rb.position.x, rb.position.y + 1, rb.position.z);
                }
                else
                {
                    rb.position = new Vector3(rb.position.x, rb.position.y - 1, rb.position.z);
                }
            }
            if (globalGameManager.currentLevel >= 6)
            {
                if (Input.GetKey(KeyCode.S))
                {
                    canSpeedUp = true;
                    //Debug.Log(canSpeedUp);
                }
                else
                {
                    canSpeedUp = false;
                }
                if (globalGameManager.currentLevel >= 9)
                {
                    //Debug.Log(canSlowDown);
                    if (Input.GetKey(KeyCode.X))
                    {
                        canSlowDown = true;
                    }
                    else
                    {
                        canSlowDown = false;
                    }
                    //Handles Teleportation only if the game level is above 13
                    if (globalGameManager.currentLevel >= 12)
                    {
                        if (Input.GetKeyDown(KeyCode.W))
                        {
                            if (canTeleport)
                            {
                                rb.position = new Vector3(rb.position.x, rb.position.y, rb.position.z - teleportLength);
                                canTeleport = false;
                                StartCoroutine(TeleportCooldown());
                            }
                        }
                    }
                }
            }
        }
    }
    private void FixedUpdate() {
        //Set player forward velocity
        rb.AddForce(0, 0, -forwardMovement * Time.fixedDeltaTime, ForceMode.VelocityChange);

        //Caps Player Speed
        rb.velocity = new Vector3(0, 0, Mathf.Clamp(rb.velocity.z, -forwardSpeedLimit, 0f));
        //playerSpeed = CalculateVelocity();
        //Handles S Input only if the game level is above 7
        if (globalGameManager.currentLevel >= 6)
        {
            if (canSpeedUp)
            {
                IncreaseSpeedAndSpeedLimit();
                //Debug.Log("Increasing Speed and Speed Limit...");
            }
            else
            {
                ReduceSpeedAndSpeedLimit();
                //Debug.Log("Reducing Speed and Speed Limit...");
            }
        }
            //Handles W Input only if the game level is above 10
        if (globalGameManager.currentLevel >= 9)
        {
            if (canSpeedUp)
            {
                IncreaseSpeedAndSpeedLimit();
                //Debug.Log("Increasing Speed and Speed Limit...");
            }
            if (!canSpeedUp)
            {
                ReduceSpeedAndSpeedLimit();
                //Debug.Log("Reducing Speed and Speed Limit...");
            }
            if (canSlowDown)
            {
                DecreaseSpeed();
                //Debug.Log("Decreasing Speed...");
            }
            else
            {
                //canSpeedUp = false;
            }
        }
        playerSpeed = CalculateVelocity();
    }

    private void IncreaseSpeedAndSpeedLimit()
    {
        rb.AddForce(0, 0, -forwardMovementAcceleration * Time.deltaTime);
        forwardSpeedLimit = Mathf.Clamp(forwardSpeedLimit + 1, forwardSpeedLimit, forwardSpeedLimitMax);
        rb.velocity = new Vector3(0, 0, Mathf.Clamp(rb.velocity.z, -forwardSpeedLimitMax, 0f));
    }
    private void ReduceSpeedAndSpeedLimit()
    {
        //reduce velocity to original velocity
        float newVelocity = Mathf.Clamp(rb.velocity.z + 0.5f, -originalSpeedLimit, -forwardSpeedLimit);
        rb.velocity = new Vector3(0, 0, newVelocity);
        //reduce speed limit to original speed limit
        forwardSpeedLimit = Mathf.Clamp(forwardSpeedLimit - 5f, originalSpeedLimit, forwardSpeedLimit);
        //Debug.Log(forwardSpeedLimit);
    }
    private void DecreaseSpeed()
    {
        //reduce speed
        rb.AddForce(0, 0, forwardMovementAcceleration * Time.deltaTime);
        //Clamp Speed limit to min speed limit
        forwardSpeedLimit = Mathf.Clamp(forwardSpeedLimit - 5f, 0f, forwardSpeedLimitMin);
        rb.velocity = new Vector3(0, 0, Mathf.Clamp(-rb.velocity.z, -forwardSpeedLimitMin, -forwardSpeedLimit));
    }

    IEnumerator TeleportCooldown()
    {
        yield return new WaitForSeconds(teleportCooldown);
        canTeleport = true;
    }

    public float CalculateVelocity()
    {
        return -rb.velocity.z;
    }
}
