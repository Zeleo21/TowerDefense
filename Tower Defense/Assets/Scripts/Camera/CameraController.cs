using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public float panSpeed = 30f;

    public float scrollSpeed = 5;

    private float minY = 10f;
    private float maxY = 80f;

    // Update is called once per frame
    void Update()
    {
        if (GameManager.gameEnded)
        {
            this.enabled = false;
            return;
        }
        if (Input.GetKey(KeyCode.Z))
        {
            transform.Translate(Vector3.left  * panSpeed * Time.deltaTime, Space.World);
        }
        if (Input.GetKey(KeyCode.Q))
        {
            transform.Translate(Vector3.back  * panSpeed * Time.deltaTime, Space.World);
        }
        if (Input.GetKey(KeyCode.D))
        {
            transform.Translate(Vector3.forward  * panSpeed * Time.deltaTime, Space.World);
        }
        if (Input.GetKey(KeyCode.S))
        {
            transform.Translate(Vector3.right  * panSpeed * Time.deltaTime, Space.World);
        }

        float scroll = Input.GetAxis("Mouse ScrollWheel");
        Debug.Log(scroll);
        Vector3 pos = transform.position;
        pos.y -= scroll * 500 *  scrollSpeed * Time.deltaTime;
        pos.y = Mathf.Clamp(pos.y, minY, maxY);
        transform.position = pos;
    }
}
