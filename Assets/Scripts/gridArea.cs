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

    // Start is called before the first frame update
    void Start()
    {

        Transform transformGridArea = transform.Find("GridArea");
        SpriteRenderer spriteRendererGrid = transformGridArea.gameObject.GetComponent<SpriteRenderer>();
        gridHeight = spriteRendererGrid.bounds.size.y;
        gridWidth = spriteRendererGrid.bounds.size.x;

        gameBlockHeight = gridHeight / numRow;
        gameBlockWidth = (gridWidth / numColumn)+0.01f;

        gridAreaPos = transformGridArea.position;
        gridAreaPos.z = 0;

        for (int i = 0; i < numColumn; i++)
        {
            for(int j = 0; j < numRow; j++)
            {
                GameObject gameBlockPrefab = Resources.Load("Blue") as GameObject;
                GameObject gameBlock = Instantiate(gameBlockPrefab);
                gameBlock.transform.position = new Vector3((gameBlockWidth * i)-1.74f, (gameBlockHeight * j)-2.27f, 0f) + gridAreaPos;
                gameBlock.transform.SetParent(transform, false);

            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
