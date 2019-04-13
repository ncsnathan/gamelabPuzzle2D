using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotationButton : MonoBehaviour
{
   
    public enum buttonType
    {
        None,
        Left,
        Right,
        Mid
    };

    public gridArea GameBox;
    public buttonType type;

    public void OnCLick()
    {
        GameBox.Swap(type);
    }
}
