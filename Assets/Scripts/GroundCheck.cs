using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundCheck : MonoBehaviour
{
    [SerializeField] private ScoreTrigger scoreTrigger;

    private void OnCollisionEnter(Collision collision)
    {
        scoreTrigger.GetComponent<ScoreTrigger>().DetectMiss();
    }
}
