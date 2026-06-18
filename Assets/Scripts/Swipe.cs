using UnityEngine;

public class Swipe : MonoBehaviour
{
    public bool grounded;
    public int jumpForce;
    public int downForce;

    private Vector2 startTouchPosition;
    private Vector2 endTouchPosition;

    [Header("Settings")]
    [Tooltip("Minimum pixel distance to register as a swipe")]
    public float swipeThreshold = 50f;

    void Update()
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

    void OnSwipeUp()
    {
        Debug.Log("Swiped Up!");

        if (grounded)
        {
            GetComponent<Rigidbody>().AddForce(transform.up * jumpForce, ForceMode.Impulse);
        }
    }

    void OnSwipeDown()
    {
        Debug.Log("Swiped Down!");

        if (!grounded)
        {
            GetComponent<Rigidbody>().AddForce(transform.up * downForce, ForceMode.Impulse);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        grounded = true;
    }

    private void OnCollisionExit(Collision collision)
    {
        grounded = false;
    }
}
