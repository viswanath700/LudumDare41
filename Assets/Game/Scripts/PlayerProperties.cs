using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "PlayerProperties", menuName ="PlayerPropertiesScript")]
public class PlayerProperties : ScriptableObject
{
    public string PlayerName = "Player";
    public PlayerType PlayerType;
    public float Mass = 1f;
    public float MovementSpeed = 1f;
    public GameObject PlayerModel;
}
