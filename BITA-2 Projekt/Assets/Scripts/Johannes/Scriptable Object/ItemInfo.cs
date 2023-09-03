using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemInfo : MonoBehaviour
{
    //Script zum Managen aller Items im Spiel.
    //IItems werden in IDs fuer jeden typ aufgeteilt und in dieser ID einer Eigenen zugewiesen.
    #region Johannes
    public List<Weapon> weaponList;



    private void Awake()
    {
        DontDestroyOnLoad(this.gameObject);
    }
    #region PublicVariables
    public Weapon FindObject(int _typeID, int _ID)
    {
        if(_typeID == 0)
        {
            return weaponList[_ID];
        } else if (_typeID == 1)
        {
            return null;
        }
        else
        {
            return null;
        }
    }
    #endregion
    #endregion
}
