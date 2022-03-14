using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.SceneManagement;

public class RotationObject : MonoBehaviour
{
    GameController gameController;

    public float speed;

    void Start()
    {
        gameController = FindObjectOfType<GameController>();
    }
    void Update()
    {
        if (gameController.lose != true)
            transform.Rotate(new Vector3(0,0,speed));
    }
}