using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gridArea : MonoBehaviour
{
    int numColumn = 4;
    int numRow = 9;
    float gridWidth, gridHeight;
    float gameBlockWidth, gameBlockHeight;

    // Start is called before the first frame update
    void Start()
    {

        Transform transformGridArea = transform.Find("GridArea");
        SpriteRenderer spriteRendererGrid = transformGridArea.gameObject.GetComponent<SpriteRenderer>();
        gridHeight = spriteRendererGrid.bounds.size.y;
        gridWidth = spriteRendererGrid.bounds.size.x;

        gameBlockHeight = gridHeight / numRow;
        gameBlockWidth = gridWidth / numColumn;

        for (int i = 0; i < numColumn; i++)
        {
            for(int j = 0; j < numRow; j++)
            {
                GameObject gameBlockPrefab = Resources.Load("Blue") as GameObject;
                GameObject gameBlock = Instantiate(gameBlockPrefab);
                gameBlock.transform.position = new Vector3(gameBlockWidth * i, gameBlockHeight * j, 0f);

            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
