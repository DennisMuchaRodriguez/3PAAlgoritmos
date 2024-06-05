using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    private Stack<Item> items = new Stack<Item>();

    public void AddItem(Item item)
    {
        items.Push(item);
        ApplyTopItemEffect();
    }

    public void RemoveItem()
    {
        if (items.Count > 0)
        {
            items.Pop();
            ApplyTopItemEffect();
        }
    }
    private void ApplyTopItemEffect()
    {
        PlayerAttributes playerAttributes = FindObjectOfType<PlayerAttributes>();
        playerAttributes.ResetStats();

        if (items.Count > 0)
        {
            Item topItem = items.Peek();
            topItem.ApplyEffect(playerAttributes);
        }
    }
}
