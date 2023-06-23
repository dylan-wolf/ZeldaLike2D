using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomMove : MonoBehaviour
{
    public Vector2 cameraChangeMin;//If room is a non-box shape, you will need to create cameraChangeMin and cameraChangeMax
    public Vector2 cameraChangeMax;
    public Vector3 playerChange;
    private CameraMovement cam;
    // Start is called before the first frame update
    void Start()
    {
        cam = Camera.main.GetComponent<CameraMovement>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))

        {
            cam.minPosition = cameraChangeMin; //Here is where you would assign cameraChangeMin and cameraChangeMax
            cam.maxPosition = cameraChangeMax;
            collision.transform.position += playerChange;
        }
    }
}
