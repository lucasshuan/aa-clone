using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.SceneManagement;

public class Ball : MonoBehaviour
{

    LineRenderer lineRenderer;
    GameController gameController;

    public void Awake()
    {
        gameController = FindObjectOfType<GameController>();
    }

    public void Launch()
    {

        transform.DOLocalMoveY(500, 1.5f, false);
    }

    public void MoveUp(int distance)
    {
        transform.DOLocalMoveY(transform.position.y+184+distance, 0.25f, false);
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.GetComponent<CollisionDetector>() != null)
        {
            // When it collides with a ball, it attaches the ball to the rotative object:
            
            RotationObject rotationObject = FindObjectOfType<RotationObject>();
            Vector3 position = collision.transform.position;
            
            DOTween.Kill(transform); // Ends the current DOTween animation

            // Generates a line between the ball and the center

            transform.parent = rotationObject.transform;
            lineRenderer = gameObject.AddComponent<LineRenderer>();
            lineRenderer.material = new Material(Shader.Find("Sprites/Default"));
            lineRenderer.widthMultiplier = 3;
            lineRenderer.startColor = Color.white;
            lineRenderer.positionCount = 2;
            lineRenderer.SetPosition(0, rotationObject.transform.position);
            lineRenderer.SetPosition(1, transform.position);
        } else if (collision.GetComponent<Ball>())
        {
            gameController.GameOver();
        }
    }

    void Update()
    {

        // Changes the final position of the line every frame
        if (GetComponent<LineRenderer>() != null && gameController.lose != true)
        {
            GetComponent<LineRenderer>().SetPosition(1, transform.position);
        }
    }
}