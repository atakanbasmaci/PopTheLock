using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PaddleScript : MonoBehaviour
{
    public GameObject paddle;
    public int direction = 1;
    public bool isTouching = false;
    public CircleScript circleScript;
    public LogicScript logicScript;

    // Start is called before the first frame update
    void Start()
    {
        circleScript = GameObject.FindGameObjectWithTag("Circle").GetComponent<CircleScript>();
        logicScript = GameObject.FindGameObjectWithTag("Logic").GetComponent<LogicScript>();
    }

    // Update is called once per frame
    void Update()
    {
        transform.RotateAround(new Vector3(0, -2, 0), Vector3.forward, 70 * Time.deltaTime * direction);

        if(isTouching && Input.GetKeyDown(KeyCode.Space))
        {
            logicScript.addScore(1);
            circleScript.changePositionRandomly();
        } 
        else if(!isTouching && Input.GetKeyDown(KeyCode.Space))
        {
            logicScript.addScore(-1);
        }

        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            direction *= -1;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        isTouching = true;
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        isTouching = false;
    }
}
