using System.Collections;
using UnityEngine;
using UnityEngine.Serialization;

public class PlayerMovement : MonoBehaviour
{
    [FormerlySerializedAs("PlayerCamera")] [SerializeField]
    public Camera playerCamera;

    private Vector2 player2DSteep;
    private bool isMoving = false;

    [FormerlySerializedAs("Translation Speed")] [SerializeField]
    public float transitionDuration = 0.15f;

    //keeping track of player coordinates 
    private static Vector2Int playerMatrixPosition;

    public static Vector2Int PlayerMatrixPosition
    {
        get => playerMatrixPosition;

        private set
        {
            int clampedX = Mathf.Clamp(value.x, 0, 2);
            int clampedY = Mathf.Clamp(value.y, 0, 2);

            playerMatrixPosition = new Vector2Int(clampedX, clampedY);
        }
    }

    //Keeping track of the coroutine active
    private Coroutine currentCoroutine = null;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        if (playerCamera == null)
            Debug.Log("PlayerCamera is null!");

        float distanceFromCamera = Vector3.Distance(playerCamera.transform.position, transform.position);

        player2DSteep.x = ((playerCamera.ViewportToWorldPoint(new Vector3(1f, 0.5f, distanceFromCamera)).x) * 2f) / 3f;
        player2DSteep.y = ((playerCamera.ViewportToWorldPoint(new Vector3(0.5f, 1f, distanceFromCamera)).y) * 2f) / 3f;

        PlayerMatrixPosition = new Vector2Int(1, 1);
    }

    void Update()
    {
        float xInput = Input.GetAxisRaw("Horizontal");
        float yInput = Input.GetAxisRaw("Vertical");

        if (isMoving) return;

        if (xInput != 0 && yInput == 0)
        {
            switch (xInput)
            {
                case > 0 when transform.position.x < player2DSteep.x:
                    currentCoroutine = StartCoroutine(MovePlayer(Vector2.right, player2DSteep.x));
                    isMoving = true;
                    PlayerMatrixPosition += Vector2Int.right;
                    break;
                case < 0 when transform.position.x > (player2DSteep.x * -1):
                    currentCoroutine = StartCoroutine(MovePlayer(Vector2.left, player2DSteep.x));
                    isMoving = true;
                    PlayerMatrixPosition += Vector2Int.left;
                    break;
            }
        }

        if (xInput == 0 && yInput != 0)
        {
            switch (yInput)
            {
                case > 0 when transform.position.y < player2DSteep.y:
                    currentCoroutine = StartCoroutine(MovePlayer(Vector2.up, player2DSteep.y));
                    isMoving = true;
                    PlayerMatrixPosition += Vector2Int.down;
                    break;
                case < 0 when transform.position.y > (player2DSteep.y * -1):
                    currentCoroutine = StartCoroutine(MovePlayer(Vector2.down, player2DSteep.y));
                    isMoving = true;
                    PlayerMatrixPosition += Vector2Int.up;
                    break;
            }
        }

        //expansion for diagonal movement (if we want)
        if (xInput != 0 && yInput != 0)
        {
            
        }

        #region OldMovementSystem

        /*
               if (Input.GetKeyDown(KeyCode.W) && !isMoving && transform.position.y < player2DSteep.y)
               {
                   currentCoroutine = StartCoroutine(MovePlayer(Vector2.up, player2DSteep.y));
                   isMoving = true;
                   PlayerMatrixPosition += Vector2Int.down;
               }

               else if (Input.GetKeyDown(KeyCode.S) && !isMoving && transform.position.y > (player2DSteep.y * -1))
               {
                   currentCoroutine = StartCoroutine(MovePlayer(Vector2.down, player2DSteep.y));
                   isMoving = true;
                   PlayerMatrixPosition += Vector2Int.up;
               }

               else if (Input.GetKeyDown(KeyCode.A) && !isMoving && transform.position.x > (player2DSteep.x * -1))
               {
                   currentCoroutine = StartCoroutine(MovePlayer(Vector2.left, player2DSteep.x));
                   isMoving = true;
                   PlayerMatrixPosition += Vector2Int.left;
               }

               else if (Input.GetKeyDown(KeyCode.D) && !isMoving && transform.position.x < player2DSteep.x )
               {
                   currentCoroutine = StartCoroutine(MovePlayer(Vector2.right, player2DSteep.x)) ;
                   isMoving = true;
                   PlayerMatrixPosition += Vector2Int.right;
               }*/

        #endregion

        Debug.Log("Player Location = " + PlayerMatrixPosition.ToString());
    }

    IEnumerator MovePlayer(Vector2 direction, float axis)
    {
        float timeElapsed = 0.0f;
        Vector3 startPos = this.transform.position;
        Vector3 targetPos = startPos + (Vector3)(direction * axis);

        while (timeElapsed < transitionDuration)
        {
            timeElapsed += Time.deltaTime;
            float t = timeElapsed / transitionDuration;

            transform.position = Vector3.Lerp(startPos, targetPos, t);
            
            yield return null;
        }

        currentCoroutine = null;
        isMoving = false;
        transform.position = targetPos;
    }
}