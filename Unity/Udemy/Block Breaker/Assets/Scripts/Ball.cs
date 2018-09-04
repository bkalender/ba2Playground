using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour {

    [SerializeField] Paddle paddle;
    [SerializeField] float launchX = 2f;
    [SerializeField] float launchY = 20f;

    Vector2 paddleToBallVector;
    bool hasStarted = false;

    // Use this for initialization
    void Start () {
        paddleToBallVector = transform.position - paddle.transform.position;
	}

    // Update is called once per frame
    void Update(){
        if (!hasStarted)
        {
            LockBallToPaddle();
            LaunchBallOnMouseClick();
        }
    }

    private void LockBallToPaddle(){
        Vector2 paddlePos = new Vector2(paddle.transform.position.x, paddle.transform.position.y);
        transform.position = paddlePos + paddleToBallVector;
    }

    private void LaunchBallOnMouseClick(){
        if (Input.GetMouseButtonDown(0)) {
            hasStarted = true;
            GetComponent<Rigidbody2D>().velocity = new Vector2(launchX, launchY);
        }
    }
}
