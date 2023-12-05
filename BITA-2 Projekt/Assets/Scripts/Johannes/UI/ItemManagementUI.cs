using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using Unity.VisualScripting;
using JetBrains.Annotations;
using System.Globalization;
using Unity.Netcode;

public class ItemManagementUI : NetworkBehaviour
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


    public override void OnNetworkSpawn()
    {
        if (!IsOwner) Destroy(this);
    }

    private void Awake() {
        if (player == null) {
            player = GameObject.Find("Player");
        }
        if (panel == null) {
            panel = transform.Find("PickUpUI").gameObject;
        }
    }

    void ManageListAdd(int i) {
        if (items[i].GetComponent<WeaponDisplay>() != null) {
            ItemUICreation(items[i].GetComponent<WeaponDisplay>().ID, items[i].GetComponent<WeaponDisplay>().typeID, items[i].GetComponent<WeaponDisplay>().ItemPreview, items[i].GetComponent<WeaponDisplay>().ItemName, items[i].GetComponent<WeaponDisplay>().ItemDescription);
        } else if (items[i].GetComponent<HealDisplay>() != null) {
            ItemUICreation(items[i].GetComponent<HealDisplay>().ID, items[i].GetComponent<HealDisplay>().typeID, items[i].GetComponent<HealDisplay>().Picture, items[i].GetComponent<HealDisplay>().Name, items[i].GetComponent<HealDisplay>().Description);
        }
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
                if (!player.GetComponentInChildren<InteractionManager>().items.Contains(_temp)) {
                    Destroy(_temp);
                    break;
                }
            }
        }
        
    }
    #endregion
    #endregion
}
