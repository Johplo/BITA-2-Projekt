using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealDisplay : MonoBehaviour
{
    #region Johannes
    public Healflask flask;

    public int typeID = 1;
    public int ID;

    public int Strenght;
    public string Name;
    public string Description;

    public Sprite Picture;
    private void Start() {
        Strenght = flask.Healstrength;
        Name = flask.Name;
        Description = flask.Description;

        Picture = flask.Picture;

        transform.name = Name;
    }

    #endregion
}
