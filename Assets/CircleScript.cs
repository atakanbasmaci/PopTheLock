using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CircleScript : MonoBehaviour
{
    public GameObject circle;

    // Start is called before the first frame update
    void Start()
    {
        circle.transform.position = new Vector3(0, 2, 0);
    }

    // Update is called once per frame
    void Update()
    {
        //circle.transform.RotateAround(new Vector3(0, -2, 0), Vector3.forward, 30 * Time.deltaTime);
    }

    [ContextMenu("Change Position")]
    public void changePositionRandomly()
    {
        Vector3 point = new Vector3(0, -2, 0); // point around which to rotate
        float angle = Random.Range(0, 360);
        Quaternion rotation = Quaternion.Euler(0f, 0f, angle);
        transform.RotateAround(point, Vector3.forward, angle);
        transform.position = point + rotation * (transform.position - point);
    }
    
    public Vector3 getCirclePosition()
    {
        return transform.position;
    }
}
