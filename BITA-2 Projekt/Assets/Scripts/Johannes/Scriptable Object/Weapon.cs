using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

[CreateAssetMenu(fileName = "Weapon", menuName = "Items/Weapons/closeRange/Weapon")]
public class Weapon : ScriptableObject
{
    public float Damage;
    public float Speed;
    public string Name;
    public Sprite Picture;
}
