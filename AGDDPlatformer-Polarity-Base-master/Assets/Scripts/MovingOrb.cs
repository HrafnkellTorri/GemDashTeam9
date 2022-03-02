using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MovingOrb : MonoBehaviour
{
    public float speed = 1f;
    public float setHeight = 4f;
    public float setX;

    void Update()
    {
        float height = Mathf.PingPong(Time.time * speed, 1) * 10 - 3;
        transform.position = new Vector2(setX, height+setHeight);
    }


    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.name == "Player1" || col.gameObject.name == "Player2")
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }


}
