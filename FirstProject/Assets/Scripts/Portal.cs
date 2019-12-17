using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class Portal : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.name == "Portal")
        {
            SceneManager.LoadScene("secondScene");
        }
        if (collision.gameObject.name == "Portal2")
        {
            SceneManager.LoadScene("third_scene");
        }
        if (collision.gameObject.name == "Portal3")
        {
            SceneManager.LoadScene("theEnd");
        }

    }
}
