using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEditor.Build.Content;

public class ItemManagementUI : MonoBehaviour
{
    #region Johannes
    public InteractionManager interaction;

    public List<GameObject> items;
    
    public List<GameObject> selectedItems;

    private Sprite ItemPreview;
    private string ItemName;
    private string ItemDescription;

    public GameObject ItemPrefab;

    void ManageListAdd() {
        for (int i = 0; i <= items.Count-1; i++)
        {
            if (!selectedItems.Contains(items[i]))
            {
                ItemPreview = items[i].GetComponent<WeaponDisplay>().ItemPreview;
                ItemName = items[i].GetComponent<WeaponDisplay>().ItemName;
                ItemDescription = items[i].GetComponent<WeaponDisplay>().ItemDescription;

                ItemUICreation(i);
            }
        }
    }

    void ManageListRemove()
    {
        for (int i = 0;i <= selectedItems.Count - 1; i++)
        {
            if (!items.Contains(selectedItems[i]))
            {
                GameObject temp = selectedItems[i];
                ItemUIDeletion(i, temp);
            }
        }
    }

    void ItemUICreation(int i) {
        selectedItems.Add(Instantiate(ItemPrefab));

        selectedItems[i].transform.SetParent(gameObject.transform.GetChild(0));

        selectedItems[i].transform.localScale = new Vector3(1,1,1);
        selectedItems[i].transform.localPosition = new Vector3(0, 275 - (50 * selectedItems.IndexOf(selectedItems[i])), 0);

        selectedItems[i].gameObject.transform.GetChild(0).GetComponent<Image>().sprite = ItemPreview;
        selectedItems[i].gameObject.transform.GetChild(1).GetComponent<TMP_Text>().text = ItemName;
        selectedItems[i].gameObject.transform.GetChild(2).GetComponent<TMP_Text>().text = ItemDescription;
    }

    void ItemUIDeletion(int i, GameObject temp)
    {
        selectedItems.Remove(selectedItems[i]);

        GameObject.Destroy(temp);
    }
    #region Valuepublication
    public void AddingUpdate(GameObject item) {
        items.Add(item);
        ManageListAdd();
    }

    public void RemovingUpdate(GameObject item) {
        items.Remove(item);
        ManageListRemove();
    }
    #endregion
    #endregion
}
