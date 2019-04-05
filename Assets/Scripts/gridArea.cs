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

    // Start is called before the first frame update
    void Start()
    {
        cont = 0;
        Transform transformGridArea = transform.Find("GridArea");
        SpriteRenderer spriteRendererGrid = transformGridArea.gameObject.GetComponent<SpriteRenderer>();
        gridHeight = spriteRendererGrid.bounds.size.y;
        gridWidth = spriteRendererGrid.bounds.size.x;

        gameBlockHeight = gridHeight / numRow;
        gameBlockWidth = (gridWidth / numColumn)+0.01f;

        gridAreaPos = transformGridArea.position;
        gridAreaPos.z = 0;

        /* TESTE
        for (int i = 0; i < numColumn; i++)
        {
            for(int j = 0; j < numRow; j++)
            {
                GameObject gameBlockPrefab = Resources.Load("Blue") as GameObject;
                GameObject gameBlock = Instantiate(gameBlockPrefab);
                gameBlock.transform.position = new Vector3((gameBlockWidth * i)-1.74f, (gameBlockHeight * j)-2.27f, 0f) + gridAreaPos;
                gameBlock.transform.SetParent(transform, false);

            }
        }*/
    }

    public Vector3 GetGridPosition(int x, int y)
    {
        float posX = (gameBlockWidth * x) - 1.74f;
        float posY = (gameBlockHeight * y) - 2.27f;
        return new Vector3(posX,posY,0) + gridAreaPos;

    }

    private void Respawn()
    {
        int randomPos = Random.Range(0, 4);
        GameObject gameBlock = Resources.Load("Blue") as GameObject;
        gameBlock.transform.position = GetGridPosition(randomPos, 8);
        Instantiate(gameBlock, transform, false);


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
