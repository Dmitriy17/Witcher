using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class itemData : MonoBehaviour {
    public static itemData _itemData;
    public List<item> Items = new List<item>(); //списк в котором хранятся все предметы 

    void Awake()
    {
        _itemData = this;
    }

    void Start()
    {

    }

    void Update()
    {

    }
    //генерация предмета 
    public item ItemGen(int id)
    {
        item tmp_item = new item();
        tmp_item.name = Items[id].name;
        tmp_item.Type = Items[id].Type;
        tmp_item.Texture = Items[id].Texture;
        return tmp_item;
    }
}
