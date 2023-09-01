using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class button : MonoBehaviour
{
    #region Johannes
    private int ID;
    private int typeID;



    #region PublicVariable
    public void SetIDs(int ID, int typeID) {
        this.ID = ID;
        this.typeID = typeID;
    }

    public int gettypeID() {
        return typeID;
    }
    public int getID() {
        return ID;
    }
    #endregion
    #endregion
}
