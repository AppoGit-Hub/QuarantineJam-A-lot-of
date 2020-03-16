using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "KeyInputSet", menuName = "KeyInputSet")]
public class KeyInputSet : ScriptableObject
{
    public KeyCode Up;
    public KeyCode Down;
    public KeyCode Rigth;
    public KeyCode Left;

    public KeyCode Fire;
}
