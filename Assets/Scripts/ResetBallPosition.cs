using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResetBallPosition : MonoBehaviour
{
    private Vector2 ballPosition;
    // Start is called before the first frame update
    void Start()
    {
        ballPosition = this.gameObject.transform.localPosition;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("space"))
        {
            Debug.Log("space key was pressed");
            this.gameObject.transform.localPosition = ballPosition;
        }

    }
}
