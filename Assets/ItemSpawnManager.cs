using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemSpawnManager : MonoBehaviour
{
    public static ItemSpawnManager intance;

    private void Awake()
    {
        intance = this;
    }

    [SerializeField] GameObject pickUpiItemPrefab;

    public void SpawnItem(Vector3 position, Item item, int count)
    {
        GameObject o = Instantiate(pickUpiItemPrefab, position, Quaternion.identity);
        o.GetComponent<PickUpItem>().Set(item,count);

    }
}
