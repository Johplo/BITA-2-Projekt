using System.Collections;
using System.Collections.Generic;
using UnityEditor.UI;
using UnityEngine;
using UnityEngine.UI;

public class ItemManagementUI : MonoBehaviour
{
    #region Johannes
    public InteractionManager interaction;

    public List<GameObject> items;
    
    private List<GameObject> selectedItems;

    private Sprite ItemPreview;
    private Text ItemName;
    private Text ItemDescription;

    public GameObject ItemPrefab;

    void ManageList() {
        for (int i = 0; i <= items.Count; i++) {
            if (!selectedItems.Contains(items[i])) {
                ItemUICreation(i);
            }
        }
    }
    void ItemUICreation(int i) {
        selectedItems.Add(Instantiate(ItemPrefab));
        selectedItems[i].gameObject.transform.GetChild(0).GetComponent<Image>().sprite = ItemPreview;
        selectedItems[i].gameObject.transform.GetChild(1).GetComponent<Text>().text = ItemName.text;
        selectedItems[i].gameObject.transform.GetChild(2).GetComponent<Text>().text = ItemDescription.text;
    }
    #region Valuepublication
    public void AddingUpdate(GameObject item) {
        items.Add(item);
        ManageList();
    }

    public void RemovingUpdate(GameObject item) {
        items.Remove(item);
        ManageList();
    }
    #endregion
    #endregion
}
