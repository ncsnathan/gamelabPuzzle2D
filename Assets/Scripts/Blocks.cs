using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Blocks : MonoBehaviour
{
    float cont = 0;
    float timeToTarget = 0.5f;

    gridArea GameBox;
    int posX, startPosY, endPosY;

    bool isMoving;
    
    // Start is called before the first frame update
    void Start()
    {
        GameBox = GameObject.Find("Game Box HD").GetComponent<gridArea>();
        posX = GameObject.Find("Game Box HD").GetComponent<gridArea>().randomPosition;
        startPosY = 8;
        endPosY = 8;
        isMoving = false;
        
    }

    // Update is called once per frame
    void Update()
    {
        if (isMoving == true)
        {
            cont += Time.deltaTime / timeToTarget;
            transform.position = Vector3.Lerp(GameBox.GetGridPosition(posX, startPosY), GameBox.GetGridPosition(posX, endPosY), cont);
            if(cont >= 1f)
            {
                startPosY = endPosY;
                isMoving = false;
                cont = 0f;
            }
        }
        else
        {   if (endPosY > 0)
            {
                endPosY--;
                isMoving = true;
            }
        }
    }
}
