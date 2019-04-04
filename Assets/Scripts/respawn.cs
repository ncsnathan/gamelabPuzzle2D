using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class respawn : MonoBehaviour
{
    float cont;
    // Start is called before the first frame update
    void Start()
    {
        cont = 0f;
    }

    // Update is called once per frame
    void Update()
    {
        cont += Time.deltaTime;
        if(cont>=2)
        {
            Respawn();
            cont = 0f;
        }
    }

    private void Respawn()
    {
        GameObject gameBlock = Resources.Load("Blue") as GameObject;
        Instantiate(gameBlock,transform,false);
        
    }
}
