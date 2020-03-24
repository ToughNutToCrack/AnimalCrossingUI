using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraManager : MonoBehaviour
{
    public Transform cameraT;
    public List<Transform> trans;
    public float speed;
    float c;
    public float angularSpeed;
    Transform destination;
    private void Start()
    {
        destination = trans[0];
    }

    public void MoveToPosition(int index)
    {
        destination = trans[index];
    }

    private void Update()
    {
        if (Vector3.Distance(cameraT.position, destination.position) > 0.001f)
        {
            c += speed * Time.deltaTime;
            cameraT.position = Vector3.Lerp(cameraT.position, destination.position, c);
            cameraT.rotation = Quaternion.RotateTowards(transform.rotation, Quaternion.Euler(destination.rotation.eulerAngles), angularSpeed * Time.deltaTime);
        }
        else
            c = 0;
    }
}
