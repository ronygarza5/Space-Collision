using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerHealth : MonoBehaviour
{



    // Update is called once per frame
    void Update()
    {
        if (gameObject.transform.position.y < -50)
        {
            Die();
            //Debug.Log("Player has died");
        }
        {
        }
    }
    void Die()
    {
        SceneManager.LoadScene("firstScene");
        
    }
}
