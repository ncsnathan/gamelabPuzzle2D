using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gridArea : MonoBehaviour
{
    int numColumn = 4;
    int numRow = 9;
    float gridWidth, gridHeight;
    float gameBlockWidth, gameBlockHeight;
    Vector3 gridAreaPos;
    float cont;
    public gridArea GameBox;
    public Blocks[,] gameBlockGrid;

    public List<GameObject> gameBlocksPrefab;

    public int randomPosition;

    // Start is called before the first frame update
    void Start()
    {
        
        GameBox = GetComponentInParent<gridArea>().GameBox;
        gameBlockGrid = new Blocks[numColumn, numRow];

        cont = 0;
        Transform transformGridArea = transform.Find("GridArea");
        SpriteRenderer spriteRendererGrid = transformGridArea.gameObject.GetComponent<SpriteRenderer>();
        gridHeight = spriteRendererGrid.bounds.size.y;
        gridWidth = spriteRendererGrid.bounds.size.x;

        gameBlockHeight = gridHeight / numRow;
        gameBlockWidth = (gridWidth / numColumn)+0.01f;

        gridAreaPos = transformGridArea.position;
        gridAreaPos.z = 0;

    }

    public bool checkCollision(Blocks gameblock)
    {
        bool collision = false;

        if(gameblock.PosY == 0)
        {
            collision = false;
        }
        else
        {
            collision = gameBlockGrid[gameblock.PosX, gameblock.PosY - 1] != null &&
                gameBlockGrid[gameblock.PosX, gameblock.PosY - 1].type == gameblock.type;
        }

        if (collision)
        {
            Destroy(gameblock.gameObject);
            Destroy(gameBlockGrid[gameblock.PosX, gameblock.PosY - 1].gameObject);
            gameBlockGrid[gameblock.PosX, gameblock.PosY] = null;
            gameBlockGrid[gameblock.PosX, gameblock.PosY - 1] = null;
        }

        return collision;
    }

    public bool verificaAbaixo(int posX, int posY)
    {
        if(gameBlockGrid[posX,posY-1] == null)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    public void updateGrid(Blocks gameblock,int posX, int posY)
    {
        gameBlockGrid[posX, posY +1] = null;
        gameBlockGrid[posX, posY] = gameblock;
    }

    public void addBlock(Blocks gameBlock, int posX, int posY)
    {
        gameBlockGrid[posX, posY] = gameBlock;
    }

    public Vector3 GetGridPosition(int x, int y)
    {
        float posX = (gameBlockWidth * x) - 1.74f;
        float posY = (gameBlockHeight * y) - 2.27f;
        return new Vector3(posX,posY,0) + gridAreaPos;

    }

    private void Respawn()
    {
        int randomGameBlock = Random.Range(0, gameBlocksPrefab.Count);
        int randomPos = Random.Range(0, 4);
        GameObject gameBlock = Instantiate(gameBlocksPrefab[randomGameBlock]);
        randomPosition = randomPos;
        gameBlock.transform.position = GetGridPosition(randomPos, 8);
    }

    private bool canSwap(Blocks blockA, Blocks blockB)
    { 
        if(blockA != null && blockB == null)
        {
            return blockA.IsFixed;
        }
        if (blockA == null & blockB != null)
        {
            return blockB.IsFixed;
        }
        if(blockA == null && blockB == null)
        {
            return false;
        }
        if(blockA != null && blockB != null)
        {
            return true;
        }
        return false;
    }

    public void Swap(RotationButton.buttonType type)
    {   
        
        if(type == RotationButton.buttonType.Left)
        {
            SwapColumn(0, 1);            
        }

        if(type == RotationButton.buttonType.Mid)
        {
            SwapColumn(1, 2);
        }

        if (type == RotationButton.buttonType.Right)
        {
            SwapColumn(2, 3);
        }
        
    }

    public void SwapColumn(int indexA, int indexB)
    {
        Blocks[] aux1 = new Blocks[numRow];
        Blocks[] aux2 = new Blocks[numRow];

        for (int i = 0; i < numRow; i++)
        {

            if (canSwap(gameBlockGrid[indexA, i], gameBlockGrid[indexB, i]))
            {

                if (gameBlockGrid[indexA, i] != null)
                {
                    aux1[i] = gameBlockGrid[indexA, i];
                    gameBlockGrid[indexA, i] = null;
                }

                if (gameBlockGrid[indexB, i] != null)
                {
                    aux2[i] = gameBlockGrid[indexB, i];
                    gameBlockGrid[indexB, i] = null;
                }

                gameBlockGrid[indexA, i] = aux2[i];
                gameBlockGrid[indexB, i] = aux1[i];

            }
        }

        for(int i = 0; i <numRow; i++)
        {

            if (canSwap(gameBlockGrid[indexA, i], gameBlockGrid[indexB, i]))
            {
                if (aux1[i] != null)
                {
                    aux1[i].ToSwap(indexB - indexA);
                }

                if (aux2[i] != null)
                {
                    aux2[i].ToSwap((indexA - indexB));
                }

            }

        }

    }




    // Update is called once per frame
    void Update()
    {
        cont += Time.deltaTime;
        if (cont >= 2)
        {
            Respawn();
            cont = 0f;
        }
    }
}
