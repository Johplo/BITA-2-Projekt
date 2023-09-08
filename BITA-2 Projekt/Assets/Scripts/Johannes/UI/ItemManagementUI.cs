using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using Unity.VisualScripting;
using JetBrains.Annotations;

public class ItemManagementUI : MonoBehaviour
{
    /*
        Script zum erstellen von UI element, wenn sich Items in der Naehe befinden.
        Wenn entfernung zum Objekt besteht, wird es geloescht.
    */
    #region Johannes
    public GameObject player;
    public GameObject panel;

    public List<GameObject> items;
    
    public List<GameObject> selectedItems;

    public GameObject ItemPrefab;

    private void Awake() {
        if (player == null) {
            player = GameObject.Find("Player");
        }
    }

    void ManageListAdd(int i) {
        ItemUICreation(items[i].GetComponent<WeaponDisplay>().ID, items[i].GetComponent<WeaponDisplay>().typeID, items[i].GetComponent<WeaponDisplay>().ItemPreview, items[i].GetComponent<WeaponDisplay>().ItemName, items[i].GetComponent<WeaponDisplay>().ItemDescription);
    }

    void ManageListRemove()
    {
        for (int i = 0;i <= selectedItems.Count-1; i++)
        {
            if (!items.Contains(selectedItems[i]))
            {
                GameObject temp = selectedItems[i];
                ItemUIDeletion(i, temp);
            }
        }
    }

    void ItemUICreation(int _ID, int _typeID, Sprite _pre, string _name, string _desc) {
        selectedItems.Add(Instantiate(ItemPrefab));

        int i = selectedItems.Count-1;

        selectedItems[i].transform.SetParent(panel.transform);
        
        selectedItems[i].transform.localScale = new Vector3(1,1,1);
        selectedItems[i].transform.localPosition = new Vector3(0, 275 - (50 * selectedItems.IndexOf(selectedItems[i])), 0);

        selectedItems[i].gameObject.transform.GetChild(0).GetComponent<Image>().sprite = _pre;
        selectedItems[i].gameObject.transform.GetChild(1).GetComponent<TMP_Text>().text = _name;
        selectedItems[i].gameObject.transform.GetChild(2).GetComponent<TMP_Text>().text = _desc;
        selectedItems[i].GetComponent<button>().SetIDs(_ID, _typeID);
    }

    void ItemUIDeletion(int i, GameObject temp)
    {
        selectedItems.Remove(selectedItems[i]);

        Destroy(temp);

        StartCoroutine(ItemUIUpdating());
    }

    IEnumerator ItemUIUpdating() {
        yield return new WaitForSecondsRealtime(1);
        for (int i = 0; i < selectedItems.Count - 1; i++) {
            selectedItems[i].transform.localPosition = new(0, 275 - (50 * i), 0);
        }
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

    public void InventoryRemove(string _name)
    {
        for (int f = 0; f <= items.Count-1; f++)
        {
            if (items[f].name == _name) {
                GameObject _temp = items[f];
                items.RemoveAt(f);
                for (int i = 0; i <= selectedItems.Count - 1; i++) {
                    if (selectedItems[i].GetComponent<button>().ItemName == _name) {
                        GameObject _tempUI = selectedItems[i];
                        selectedItems.RemoveAt(i);
                        Destroy(_tempUI);
                    }
                }
                if (!player.GetComponent<InteractionManager>().items.Contains(_temp)) {
                    Destroy(_temp);
                    break;
                }
            }
        }
        
    }
    #endregion
    #endregion
}
