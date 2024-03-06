using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BallManager : MonoBehaviour
{
    private Vector2 ballPosition;
    // Start is called before the first frame update
    void Start()
    {
        ballPosition = this.gameObject.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("space"))
        {
            Debug.Log("space key was pressed");
            this.gameObject.SetActive(false);
            this.gameObject.transform.localPosition = ballPosition;
            this.gameObject.SetActive(true);
        }


        if (Input.GetKeyDown(KeyCode.Escape))
        {
            // Exit the application
            Application.Quit();
        }

    }
}
