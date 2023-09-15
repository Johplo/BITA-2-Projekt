using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class InteractionManager : MonoBehaviour
{
    /*
        Checkt, ob Items in der naehe sind und fuegt diese einer Liste hinzu.
        Danach fuegt es dieses zu einem UI Manger hinzu, damit dieses Item angezeigt wird.
    */
    #region Johannes
    public List<GameObject> items;

    public ItemManagementUI itemManagementUI;


    private void Awake()
    {
        itemManagementUI = FindObjectOfType<ItemManagementUI>();
    }
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
                items.RemoveAt(i);
                break;
            }
        }
    }
    #endregion
    #endregion
}
