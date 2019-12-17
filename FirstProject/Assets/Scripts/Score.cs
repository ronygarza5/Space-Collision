using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    private float TimeLeft = 100;
    public int PlayerScore = 0;
    public GameObject timeLeftUI;
    public GameObject playerScoreUI;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        TimeLeft -= Time.deltaTime;
        timeLeftUI.gameObject.GetComponent<Text>().text = ("Time: " + (int)TimeLeft);
        playerScoreUI.gameObject.GetComponent<Text>().text = ("Score: " + (int)PlayerScore);
        if (TimeLeft < 0.1f)
        {
            SceneManager.LoadScene("firstScene");
        }
        //Debug.Log(TimeLeft);
    }
    void OnTriggerEnter2D(Collider2D trig)
    {
        if (trig.gameObject.name == "EndLevel") {
            CountScore();
        }
        if(trig.gameObject.name == "Crystal")
        {
            PlayerScore += 10;
            Destroy(trig.gameObject);
            Debug.Log(PlayerScore);
        }
        if (trig.gameObject.name == "Crystal2")
        {
            PlayerScore += 20;
            Destroy(trig.gameObject);
            Debug.Log(PlayerScore);
        }
        if (trig.gameObject.name == "Crystal3")
        {
            PlayerScore += 25;
            Destroy(trig.gameObject);
            Debug.Log(PlayerScore);
        }

    }
    void CountScore()
    {
        PlayerScore = PlayerScore + (int)(TimeLeft * 10);
        Debug.Log(PlayerScore);
    }

   //Debug.Log("finsihed the level.");
}