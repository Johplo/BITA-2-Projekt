using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Healflask", menuName = "Items/Heals/Healflask")]
public class Healflask : ScriptableObject
{
    #region Johannes
    public int ID;
    public int typeID;

    public int Healstrength;
    public string Name;
    public string Description;

    public Sprite Picture;
    #endregion
}
