using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Threading.Tasks;
using TMPro;

public class GameController : MonoBehaviour
{
    [SerializeField] GameObject _ballQueue;
    [SerializeField] Transform ball;
    [SerializeField] Camera mainCamera;

    [SerializeField] Button NextLevelButton;
    [SerializeField] Button TryAgainButton;
    
    LevelController levelController;

    public int balls;
    int ballDistance = 62;
    int remaining;
    
    bool launchTimeCondition = true;

    private bool m_lose = false;
    public bool lose {get {return m_lose;} set {m_lose = value;}}

    void Awake()
    {
        remaining = balls;
        levelController = FindObjectOfType<LevelController>();
    }

    void Start()
    {
        InvokeBalls();
    }

    void Update()
    {
        if (remaining != 0)
        {
            if (Input.GetMouseButtonDown(0) && lose != true)
            {
                if (launchTimeCondition == true)
                {
                    LaunchBall();
                }
            }
        } else
        {
            NextLevelButton.gameObject.SetActive(true);
        }
    }

    void InvokeBalls()
    {
        Vector3 distance = new Vector3(0, 0, 0);
        int newText = balls;
        for (int i = 0; i < balls; i++)
        {

            // Instantiates a new ball
            
            Transform newBall = Instantiate(ball, _ballQueue.transform.position+distance, Quaternion.identity, _ballQueue.transform);
            newBall.Find("Text").GetComponent<TextMeshPro>().text = newText.ToString();

            // Alterations for the next loop

            distance += new Vector3(0, -ballDistance, 0);
            newText -= 1;
        }
    }

    void LaunchBall()
    {
        if (_ballQueue.transform.GetChild(0))
        {
            launchTimeCondition = false;
            LaunchingTimer();
            _ballQueue.transform.GetChild(0).GetComponent<Ball>().Launch();
            remaining -= 1;
            int children = _ballQueue.transform.childCount;
            for (int i = 1; i < children; ++i)
            {
                _ballQueue.transform.GetChild(i).GetComponent<Ball>().MoveUp(ballDistance);
            }
        }
    }

    async void LaunchingTimer()
    {
        await Task.Delay(200);
        launchTimeCondition = true;
    }

    public void GameOver()
    {
        lose = true;
        TryAgainButton.gameObject.SetActive(true);
        mainCamera.backgroundColor = new Color(0.45f,0.18f,0.2f);
    }

    public void Complete()
    {
        
    }
}
