using System;
using System.Collections;
using System.Collections.Generic;
using Microsoft.Unity.VisualStudio.Editor;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;


public class ItemDragAndDropController : MonoBehaviour
{
    [SerializeField] ItemSlot itemSlot;
    [SerializeField] GameObject itemIcon;
    RectTransform iconTransform;
    UnityEngine.UI.Image itemIconImage;

    void Start()
    {
        itemSlot = new ItemSlot();
        iconTransform = itemIcon.GetComponent<RectTransform>();
        itemIconImage = itemIcon.GetComponent<UnityEngine.UI.Image>();
    }

    private void Update()
    {
        if(itemIcon.activeInHierarchy == true)
        {
            iconTransform.position = Input.mousePosition;

            if(Input.GetMouseButtonDown(0))
            {
                if(EventSystem.current.IsPointerOverGameObject() == false)
                {
                    Vector3 worldPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                    worldPosition.z = 0;

                    ItemSpawnManager.intance.SpawnItem(
                        worldPosition, 
                        itemSlot.item, 
                        itemSlot.count);

                    itemSlot.Clear();
                    itemIcon.SetActive(false);
                }
            }
            
        }
    }

    internal void OnClick(ItemSlot itemSlot)
    {
        if(this.itemSlot.item == null)
        {
            this.itemSlot.Copy(itemSlot);
            itemSlot.Clear();
        }
        else
        {
            Item item = itemSlot.item;
            int count = itemSlot.count;

            itemSlot.Copy(this.itemSlot);
            this.itemSlot.Set(item, count);
        }
        UpdateIcon();
    }

    private void UpdateIcon()
    {
        if(itemSlot.item == null)
        {
            itemIcon.SetActive(false);
        }
        else
        {
            itemIcon.SetActive(true);
            itemIconImage.sprite = itemSlot.item.icon;
        }
    }
}
