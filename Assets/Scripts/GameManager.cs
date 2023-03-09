using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    public int remainingBalls = 4;
    [SerializeField] private GameObject readyBall;
    [SerializeField] private GameObject anchor;
    private float ballRemoveTime = 5f;
    [SerializeField] private TextMeshProUGUI remainingBallsTMP;
    [SerializeField] private ScoreTrigger scoreTrigger;

    void Start()
    {
        Application.targetFrameRate = 60;

        if (Instance == null)
        {
            Instance = this;
        }

        remainingBalls = 4;

        SetNewBall();
    }

    void Update()
    {
        remainingBallsTMP.text = remainingBalls.ToString();
        if (remainingBalls < 0)
        {
            remainingBalls = 0;
        }
    }

    public void SetNewBall()
    {
        
        if (remainingBalls >= 1)
        {
            GameObject ball = Instantiate(readyBall, new Vector3(anchor.transform.position.x, anchor.transform.position.y, anchor.transform.position.z), Quaternion.identity);
            ball.GetComponent<Basketball>().removeTime = ballRemoveTime;
        }

        remainingBalls--;
        scoreTrigger.ballScored = false;
    }
}
