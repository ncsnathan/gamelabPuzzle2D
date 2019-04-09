using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Blocks : MonoBehaviour
{
    float cont = 0;
    float timeToTarget = 4f;

    gridArea GameBox;   
    
    // Start is called before the first frame update
    void Start()
    {
        GameBox = GameObject.Find("Game Box HD").GetComponent<gridArea>();
        transform.position = Vector3.Lerp(GameBox.GetGridPosition(0, 8), GameBox.GetGridPosition(0, 0), 0);
    }

    // Update is called once per frame
    void Update()
    {
        cont += Time.deltaTime / timeToTarget;
        transform.position = Vector3.Lerp(GameBox.GetGridPosition(0, 8), GameBox.GetGridPosition(0, 0), cont);
    }
}
