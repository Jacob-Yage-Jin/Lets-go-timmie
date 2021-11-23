using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public GameObject characterRed;
    public GameObject characterBlack;
    Transform character;
    public Vector3 offset;

    public void Start()
    {
        if (GameManager.Instance.settingInfo.color == "Red")
        {
            character = characterRed.transform;
        } else
        {
            character = characterBlack.transform;
        }
    }

    public void FixedUpdate()
    {
        Vector3 cameraPosition = new Vector3(character.position.x, -4, 0);
        transform.position = cameraPosition + offset;

        HandleEdge();
    }

    public void HandleEdge()
    {
        if (GameManager.Instance.settingInfo.difficulty == "Lecture")
        {
            if (transform.position.x <= 0)
            {
                transform.position = new Vector3(0, transform.position.y, transform.position.z);
            } else if (transform.position.x >= 4)
            {
                transform.position = new Vector3(4, transform.position.y, transform.position.z);
            }
        }
    }
}
