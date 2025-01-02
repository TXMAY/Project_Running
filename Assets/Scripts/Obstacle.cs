using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle : MonoBehaviour
{
    [SerializeField] float speed = 2.0f;
    [SerializeField] float endPos = -9.0f;

    void Update()
    {
        gameObject.transform.position += Vector3.left * speed * GameManager.Instance.globalSpeed * Time.deltaTime;

        if (gameObject.transform.position.x <= endPos)
        {
            Destroy(gameObject);
        }
    }
}
