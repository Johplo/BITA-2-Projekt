using System.Collections.Generic;
using UnityEngine;

public class NetManager : MonoBehaviour
{
    #region Johannes
    [SerializeField] private List<GameObject> Player = new();

    #region Get/Set
    /// <summary>
    /// Adds the Player that is given to the function to the Player list.
    /// THis is later used for the AI to find their target.
    /// </summary>
    /// <param name="_player"></param>
    public void AddPlayer(GameObject _player)
    {
        Player.Add(_player);
    }

    /// <summary>
    /// Removes the player from the list if called.
    /// Can be used for Dead players or if he left the game.
    /// </summary>
    /// <param name="_player"></param>
    public void RemovePlayer(GameObject _player)
    {
        Player.Remove(_player);
    }
    #endregion
    #endregion
}
