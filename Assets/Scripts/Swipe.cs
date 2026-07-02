using UnityEngine;
using UnityEngine.UI;

public class Swipe : MonoBehaviour
{
    public GameManager gameManager;

    //public Image image;

    public bool grounded;
    public int jumpForce;
    public int downForce;

    Animator animator;

    private float deadCam = -3;

    private Vector2 startTouchPosition;
    private Vector2 endTouchPosition;

    [Header("Settings")]
    [Tooltip("Minimum pixel distance to register as a swipe")]
    public float swipeThreshold = 50f;

    private void Start()
    {
        animator = GetComponent<Animator>();
        //image = GetComponent<Image>();
    }

    void Update()
    {
        if(gameManager == null)
        {
            gameManager = FindAnyObjectByType<GameManager>();
        }
        else 
        {
            if (gameManager.CurrentState == GameManager.playerState.Play)
            {
                // 1. Detect Initial Press (Touch or Mouse)
                if (Input.GetMouseButtonDown(0))
                {
                    startTouchPosition = Input.mousePosition;
                }

                // 2. Detect Release and Process Swipe Direction
                if (Input.GetMouseButtonUp(0))
                {
                    endTouchPosition = Input.mousePosition;
                    DetectSwipe();
                }
            }

            if (transform.position.x < deadCam || transform.position.y <= 0)
            {
                gameObject.transform.position = new Vector3(0, 3, transform.position.z);
                gameManager.health -= 1;

                if (gameManager.health > 0)
                {
                    
                }
                else
                {
                    gameManager.CurrentState = GameManager.playerState.Die;
                    gameManager.GameOver();
                }
            }
        }
    }

    void DetectSwipe()
    {
        Vector2 swipeDelta = endTouchPosition - startTouchPosition;

        // Check if the vertical movement is greater than horizontal movement
        if (Mathf.Abs(swipeDelta.y) > Mathf.Abs(swipeDelta.x))
        {
            // Verify if the swipe meets your minimum distance requirement
            if (Mathf.Abs(swipeDelta.y) > swipeThreshold)
            {
                if (swipeDelta.y > 0)
                {
                    OnSwipeUp();
                }
                else
                {
                    OnSwipeDown();
                }
            }
        }
    }

    public void Jump()
    {
        Debug.Log("Swiped Up!");

        if (grounded)
        {
            GetComponent<Rigidbody>().AddForce(transform.up * jumpForce, ForceMode.Impulse);
            gameManager.AnimChar.SetTrigger("Jump");
            animator.SetTrigger("PlayerJump");
        }
    }

    public void OnSwipeUp()
    {
        
        //Debug.Log("Swiped Up!");

        //if (grounded)
        //{
        //    GetComponent<Rigidbody>().AddForce(transform.up * jumpForce, ForceMode.Impulse);
        //    gameManager.AnimChar.SetTrigger("Jump");
        //    animator.SetTrigger("PlayerJump");
        //}
    }

    public void OnSwipeDown()
    {
        //Debug.Log("Swiped Down!");

        //if (!grounded)
        //{
        //    GetComponent<Rigidbody>().AddForce(transform.up * downForce, ForceMode.Impulse);
        //}
    }

    private void OnCollisionEnter(Collision collision)
    {
        grounded = true;
        animator.SetTrigger("PlayerOnFloor");

        if (collision.gameObject.tag == "Coin") 
        {
            gameManager.coin += 1;
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        grounded = false;
    }
}
