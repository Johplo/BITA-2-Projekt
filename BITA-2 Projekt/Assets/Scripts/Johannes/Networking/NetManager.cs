using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NetManager : MonoBehaviour
{
    #region Johannes
    [SerializeField] private List<GameObject> Player = new();
    [SerializeField] private List<string> Scenes = new();

    #region Get/Set
    #region Players
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

    /// <summary>
    /// Gets one of the Players in the player list.
    /// </summary>
    /// <param name="t"></param>
    /// <returns>Gameobject of player</returns>
    public GameObject GetPlayer(int t)
    {
        return Player[t];
    }
    #endregion
    #region Scenes
    /// <summary>
    /// Returns the List of Scene names as an array.
    /// </summary>
    /// <returns>String-Array</returns>
    public string[] GetScenes()
    {
        return Scenes.ToArray();
    }
    #endregion
    #endregion
    #endregion
}
