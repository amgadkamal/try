using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{
    // Start is called before the first frame update
    private draggableball[] circles;
    float memorizaTime = 2.0f;
    float shuffleTime = 5.0f;
    float gameTime = 10.0f;
    bool gameActive = false;

      
    void Start()
    {
        circles = FindObjectsOfType<draggableball>();
        SetRandomValues();

    }

    void SetRandomValues()
    {foreach (var c in circles)
        {
            int rand =Random.Range(0, 3);
            c.SetState(rand);

        }

        StartCoroutine("ShuffleCircles");
    }

    IEnumerator ShuffleCircles()
    {
        yield return new WaitForSecondsRealtime(memorizaTime);
        foreach (var c in circles)
        {
            c.ResetAndPause();
            c.Animate();
        }
        yield return new WaitForSecondsRealtime(shuffleTime);
        foreach (var c in circles)
        {
            c.ResetAndPause();
        }
        gameActive = true;
        StopCoroutine("ShuffleCircles");
        StartCoroutine("TimeGame");

    }

    IEnumerator TimeGame()
    {

        yield return new WaitForSecondsRealtime(gameTime);
        StopCoroutine("TimeGame");
        foreach (var c in circles) ;
        {
            Destroy(c.gameObject);
        }
        Debug.Log("You Lose");
        gameActive = false;

    }
    // Update is called once per frame
    void Update()
    {
     if (gameActive)
        {
            Debug.Log("Checking");
            bool correct = true;
            foreach (var c in circles)
            {
                correct &= c.IsCorrect();
                Debug.Log(correct);

            }
            if(correct)
            {
                StopCoroutine("TimeGame");
                Debud.Log("You Win");
                gameActive = false;
            }



        }
        



    }
}
