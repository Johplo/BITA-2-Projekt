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

    #region Triggers
    private void OnTriggerEnter2D(Collider2D collision) {
        if (collision.gameObject.CompareTag("Item") && !items.Contains(collision.gameObject)) {
            items.Add(collision.gameObject);
            itemManagementUI.AddingUpdate(collision.gameObject);
        }
    }
    private void OnTriggerExit2D(Collider2D other) {
        if (other.gameObject.CompareTag("Item") && items.Contains(other.gameObject)) {
            items.Remove(other.gameObject);
            itemManagementUI.RemovingUpdate(other.gameObject);
        }
    }
    #endregion
    #region Valuepublication 
    public List<GameObject> GetItems() {
        return items;
    }

    public void RemoveItem(string itemName)
    {
        for (int i = 0; i <= items.Count-1; i++)
        {
            if (items[i].name == itemName)
            {
                GameObject _tempItem = items[i];
                items.RemoveAt(i);
                Destroy(_tempItem);
                _tempItem = null;
                
                break;
            }
        }
    }
    #endregion
    #endregion
}
