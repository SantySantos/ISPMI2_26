using System.Collections;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UIElements;

public class PlayerMovement : MonoBehaviour
{
    [FormerlySerializedAs("PlayerCamera")] [SerializeField]
    public Camera playerCamera;

    private Vector2 player2DSteep;
    private bool isMoving = false;
    
    [FormerlySerializedAs("Translation Speed")] [SerializeField]
    public float transitionDuration = 0.5f;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        if (playerCamera == null)
            Debug.Log("PlayerCamera is null!");

        float distanceFromCamera = Vector3.Distance(playerCamera.transform.position, transform.position);

        player2DSteep.x = ((playerCamera.ViewportToWorldPoint(new Vector3(1f, 0.5f, distanceFromCamera)).x) * 2f) / 3f;
        player2DSteep.y = ((playerCamera.ViewportToWorldPoint(new Vector3(0.5f, 1f, distanceFromCamera)).y) * 2f) / 3f;
    }

    void Update()
    {
        Debug.Log("Player Position = " + this.transform.position.ToString());

        if (Input.GetKeyDown(KeyCode.W) && !isMoving && transform.position.y < player2DSteep.y)
        {
            StartCoroutine(MovePlayer(Vector2.up, player2DSteep.y));
            isMoving = true;
            Debug.Log("Player Moves Up");
        }
        else if (Input.GetKeyDown(KeyCode.S) && !isMoving && transform.position.y > (player2DSteep.y * -1))
        {
            StartCoroutine(MovePlayer(Vector2.down, player2DSteep.y));
            isMoving = true;
            Debug.Log("Player Moves down");
        }

        else if (Input.GetKeyDown(KeyCode.A) && !isMoving && transform.position.x > (player2DSteep.x * -1))
        {
            StartCoroutine(MovePlayer(Vector2.left, player2DSteep.x));
            isMoving = true;
            Debug.Log("Player Moves left");
        }
        else if (Input.GetKeyDown(KeyCode.D) && !isMoving && transform.position.x < player2DSteep.x )
        {
            StartCoroutine(MovePlayer(Vector2.right, player2DSteep.x)) ;
            isMoving = true;
            Debug.Log("Player Moves right");
        }
    }

    IEnumerator MovePlayer(Vector2 direction, float axis)
    {
        float timeElapsed = 0.0f;
        Vector3 playerPos = this.transform.position;
        Vector3 startPos = this.transform.position;
        Vector3 targetPos = startPos + (Vector3)(direction * axis);
        
        while (timeElapsed < transitionDuration)
        {
            timeElapsed += Time.deltaTime;
            float t = timeElapsed / transitionDuration;
            
            transform.position = Vector3.Lerp(startPos, targetPos, t);
            
            if (direction == Vector2.down || direction == Vector2.up)
                playerPos.y = Mathf.Clamp(this.transform.position.y, -axis, axis);

            else if (direction == Vector2.left || direction == Vector2.right)
                playerPos.x = Mathf.Clamp(this.transform.position.x, -axis, axis);
            
            yield return null;
        }
        
        isMoving = false;
        transform.position = targetPos;
    }
}