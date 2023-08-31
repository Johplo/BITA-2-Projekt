using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using Unity.VisualScripting;

public class ItemManagementUI : MonoBehaviour
{
    #region Johannes
    public InteractionManager interaction;

    public List<GameObject> items;
    
    public List<GameObject> selectedItems;
    public List<GameObject> selectedOverhaul;

    private Sprite ItemPreview;
    private string ItemName;
    private string ItemDescription;

    public GameObject ItemPrefab;

    void ManageListAdd(int i) {
        ItemUICreation(i, items[i].GetComponent<WeaponDisplay>().ItemPreview, items[i].GetComponent<WeaponDisplay>().ItemName, items[i].GetComponent<WeaponDisplay>().ItemDescription);
    }

    void ManageListRemove()
    {
        for (int i = 0;i < selectedItems.Count; i++)
        {
            if (!items.Contains(selectedItems[i]))
            {
                GameObject temp = selectedItems[i];
                ItemUIDeletion(i, temp);
            }
        }
    }

    void ItemUICreation(int i, Sprite _pre, string _name, string _desc) {
        selectedItems.Add(Instantiate(ItemPrefab));

        selectedItems[i].transform.SetParent(gameObject.transform.GetChild(0));
        
        selectedItems[i].transform.localScale = new Vector3(1,1,1);
        selectedItems[i].transform.localPosition = new Vector3(0, 275 - (50 * selectedItems.IndexOf(selectedItems[i])), 0);

        selectedItems[i].gameObject.transform.GetChild(0).GetComponent<Image>().sprite = _pre;
        selectedItems[i].gameObject.transform.GetChild(1).GetComponent<TMP_Text>().text = _name;
        selectedItems[i].gameObject.transform.GetChild(2).GetComponent<TMP_Text>().text = _desc;
    }

    void ItemUIDeletion(int i, GameObject temp)
    {
        selectedItems.Remove(selectedItems[i]);

        GameObject.Destroy(temp);
    }

    #region Valuepublication
    public void AddingUpdate(GameObject item) {
        items.Add(item);
        ManageListAdd(items.IndexOf(item));
    }

    public void RemovingUpdate(GameObject item) {
        items.Remove(item);
        ManageListRemove();
    }
    #endregion
    #endregion
}
