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

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        scoreTMP.text = Mathf.Round(score).ToString();
    }

    public void OnTriggerEnter(Collider other)
    {
        //if (other.gameObject.layer == ballLayer)
        //{
            IncreaseScore();
            Debug.Log(score);
        //}
    }

    public void IncreaseScore()
    {
        score = score + scoreIncrease;
        scoreIncrease = scoreIncrease * scoreMulitplier;
        Mathf.Round(score);
    }


}
