using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Background : MonoBehaviour
{
    [SerializeField] float speed = 2.0f;
    [SerializeField] float offset = 18.0f;
    [SerializeField] float endPos = -9.0f;
    [SerializeField] List<GameObject> backgrounds;

    void Update()
    {
        for (int i = 0; i < backgrounds.Count; i++)
        {
            backgrounds[i].transform.position += Vector3.left * speed * Time.deltaTime;
            if (backgrounds[i].transform.position.x <= endPos)
            {
                float posX = backgrounds[i].transform.position.x;
                float posY = backgrounds[i].transform.position.y;
                backgrounds[i].transform.position = new Vector3(offset + posX, posY, 0);
            }
        }
    }
}
