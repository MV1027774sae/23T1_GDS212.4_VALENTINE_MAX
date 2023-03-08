using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Basketball : MonoBehaviour
{
    [SerializeField] private Rigidbody rb;
    [SerializeField] private float releaseTime = .15f;
    public float removeTime = 5f;
    private bool isMouseDown = false;
    private bool isFired;


    void Start()
    {
        
    }

    private void FixedUpdate()
    {
        if (isMouseDown && !isFired)
        {
            Vector3 mousePosition = Input.mousePosition;
            Vector3 worldPosition = Camera.main.ScreenToWorldPoint(new Vector3(mousePosition.x, mousePosition.y, 6.5f));

            if (worldPosition.y >= 0.2 && worldPosition.y <= 8f)
            {
                rb.position = worldPosition;
            }
        }
    }

    private void OnMouseDown()
    {
        if (isFired)
        {
            return;
        }

        isMouseDown = true;
        rb.isKinematic = true;
    }

    private void OnMouseUp()
    {
        if (isFired)
        {
            return;
        }

        isMouseDown = false;
        rb.isKinematic = false;

        isFired = true;

        StartCoroutine(Release());
    }

    IEnumerator Release()
    {
        yield return new WaitForSeconds(releaseTime);

        GetComponent<SpringJoint>().breakForce = 0;
        StartCoroutine(Remove());
    }

    IEnumerator Remove()
    {
        yield return new WaitForSeconds(removeTime);

        GameManager.Instance.SetNewBall();
        Destroy(gameObject);

    }
}
