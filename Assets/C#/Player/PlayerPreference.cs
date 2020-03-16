using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "PlayerPreference", menuName = "PlayerPreference")]
public class PlayerPreference : ScriptableObject
{
    public KeyInputSet KeyboardInput;
}
