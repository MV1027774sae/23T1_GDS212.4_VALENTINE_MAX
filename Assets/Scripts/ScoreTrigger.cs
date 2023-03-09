using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreTrigger : MonoBehaviour
{
    [SerializeField] private LayerMask ballLayer;
    public float score;
    private float scoreIncrease = 100f;
    private float scoreMulitplier = 1.1f;
    public GameObject hoop;
    [SerializeField] private TextMeshProUGUI scoreTMP;
    [SerializeField] GameManager gameManager;
    public bool scoreCombo;
    public bool ballScored;

    [SerializeField] private GameObject mainCamera;
    [SerializeField] private GameObject anchor;

    private void Start()
    {
        mainCamera.transform.position = new Vector3(0, 1.3f, -6);
        anchor.transform.position = new Vector3(0, 1.25f, 1);
    }

    void Update()
    {
        scoreTMP.text = Mathf.Round(score).ToString();
    }

    public void OnTriggerEnter(Collider other)
    {
        IncreaseScore();
        Debug.Log(score);

        ballScored = true;
    }

    public void IncreaseScore()
    {
        if (scoreCombo)
        {
            score = score + scoreIncrease;
            scoreIncrease = scoreIncrease * scoreMulitplier;
            Mathf.Round(score);

            gameManager.remainingBalls++;
        }
        else if (!scoreCombo)
        {
            scoreIncrease = 100f;
            score = score + scoreIncrease;
            Mathf.Round(score);

            scoreCombo = true;
            gameManager.remainingBalls++;
        }

        mainCamera.transform.position = new Vector3(mainCamera.transform.position.x, mainCamera.transform.position.y, mainCamera.transform.position.z - 1.5f);
        anchor.transform.position = new Vector3(anchor.transform.position.x, anchor.transform.position.y, anchor.transform.position.z - 1.25f);
    }

    public void DetectMiss()
    {
        Debug.Log("Miss Detected");

        if (ballScored)
        {
            return;   
        }
        else if (!ballScored)
        {
            scoreCombo = false;
        }

        mainCamera.transform.position = new Vector3(0, 1.3f, -6);
        anchor.transform.position = new Vector3(0, 1.25f, 1);
    }
}
