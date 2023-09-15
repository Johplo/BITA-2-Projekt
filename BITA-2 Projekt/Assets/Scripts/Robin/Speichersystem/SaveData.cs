using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[System.Serializable]
public class SaveData
{
    #region Robin
    public int healflask;
    // Weitere noch hinzufügen

    public float[] position;

    public SaveData(PlayerMovement player) 
    {
        

        position = new float[3];
        position[0] = player.transform.position.x;
        position[1] = player.transform.position.y;
        position[2] = player.transform.position.z;
    }   
    #endregion
}
