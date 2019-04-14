using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Blocks : MonoBehaviour
{
    public enum gameBlockType
    {
        Blue,
        Red,
        Yellow,
        Green,
        TopEgg,
        BottonEgg
    }

    float cont = 0, swapCont = 0;
    float timeToTarget = 0.5f, timeToSwap = 0.5f;

    gridArea GameBox;
    int posX, startPosY, endPosY, swapInt;

    bool isMoving, isSwaping;
    private bool isFixed;

    public gameBlockType type;

    public bool IsFixed
    {
        get { return isFixed; }
    }

    public int PosY
    {
        get { return endPosY; }
    }

    public int PosX
    {
        get { return posX; }
    }


    // Start is called before the first frame update
    void Start()
    {
        GameBox = GameObject.Find("Game Box HD").GetComponent<gridArea>();
        posX = GameObject.Find("Game Box HD").GetComponent<gridArea>().randomPosition;
        startPosY = 8;
        endPosY = 8;
        isMoving = false;
        isSwaping = false;
        isFixed = false;
        GameBox.addBlock(this, posX, endPosY);
        
    }

    // Update is called once per frame
    void Update()
    {      
           if (isSwaping)
           {
                swapCont += Time.deltaTime / timeToSwap;
                transform.position = Vector3.Lerp(transform.position, GameBox.GetGridPosition(posX, endPosY), swapCont);
                if (swapCont >= 1f)
                {
                    isSwaping = false;
                }

           }

        if (isMoving == true)
        {
            GameBox.updateGrid(this,posX,endPosY);

            cont += Time.deltaTime / timeToTarget;

            transform.position = Vector3.Lerp(GameBox.GetGridPosition(posX, startPosY), GameBox.GetGridPosition(posX, endPosY), cont);

            if (cont >= 1f)
            {
                startPosY = endPosY;
                isMoving = false;
                cont = 0f;
            }
        }
        else
        { 
            if (endPosY > 0 && GameBox.verificaAbaixo(posX,endPosY))
            {
                endPosY--;
                isMoving = true;
            }
            else
            {
                isFixed = true;
                GameBox.checkCollision(this);
            }
        }

    }

    public void ToSwap(int diferenca)
    {
        posX = posX + diferenca;
        swapCont = 0f;
        timeToSwap = 0.5f;
        isSwaping = true;

    }

}
