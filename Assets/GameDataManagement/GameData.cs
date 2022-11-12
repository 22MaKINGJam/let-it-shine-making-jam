using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

[Serializable]

public class GameData
{
    public int clues = 0;
    public int jump = 0;

    public bool isMove = false;

    public Vector3 cameraOffset;

    public int Ep1_Clear = 0;
    public int checkKeyboard = 0;

    public int Ep1_obj1Order = 0;
    public int Ep1_obj2Order = 0;

}

