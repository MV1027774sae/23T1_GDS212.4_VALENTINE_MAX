using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    private bool activeTurn;
    [SerializeField] private int remainingBalls = 4;
    [SerializeField] private GameObject readyBall;
    [SerializeField] private GameObject anchor;
    private float ballRemoveTime = 5;
    [SerializeField] private LayerMask ballLayer;
    public float score;
    private float scoreIncrease = 100f;
    private float scoreMulitplier = 1.1f;
    [SerializeField] private GameObject hoop;
    [SerializeField] private TextMeshProUGUI remainingBallsTMP;


    // Start is called before the first frame update
    void Start()
    {
        if (Instance == null)
        {
            Instance = this;
        }

        remainingBalls = 4;

        SetNewBall();
    }

    // Update is called once per frame
    void Update()
    {
        remainingBallsTMP.text = remainingBalls.ToString();
    }

    public void SetNewBall()
    {
        activeTurn = false;
        
        if (remainingBalls >= 1)
        {
            GameObject ball = Instantiate(readyBall, new Vector3(anchor.transform.position.x, anchor.transform.position.y, anchor.transform.position.z), Quaternion.identity);
            ball.GetComponent<Basketball>().removeTime = ballRemoveTime;
        }

        remainingBalls--;
    }

    //public void OnTriggerEnter(Collider other)
    //{
        //if (other.gameObject.layer == ballLayer)
        //{
            //score 
        //}
    //}
}
