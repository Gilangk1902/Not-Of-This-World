using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName ="Player1", menuName ="Player/Data")]
public class PlayerData : ScriptableObject
{
    public float speed;
    public int maxJump;
    public float jumpHeight;
    public int health;
}
