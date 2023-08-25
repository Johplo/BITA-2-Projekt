using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class InteractionManager : MonoBehaviour
{
    #region Johannes
    public List<GameObject> items;

    public ItemManagementUI itemManagementUI;

    private void OnTriggerEnter2D(Collider2D collision) {
        if (collision.gameObject.CompareTag("Item")) {
            items.Add(collision.gameObject);
            itemManagementUI.AddingUpdate(collision.gameObject);
        }
    }
    private void OnTriggerExit2D(Collider2D collision) {
        if (collision.gameObject.CompareTag("Item")) {
            items.Remove(collision.gameObject);
            itemManagementUI.RemovingUpdate(collision.gameObject);
        }
    }
    #region Valuepublication 
    public List<GameObject> GetItems() {
        return items;
    }
    #endregion
    #endregion
}
