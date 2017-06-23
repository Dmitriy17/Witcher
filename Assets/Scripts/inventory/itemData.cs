using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class itemData : MonoBehaviour {
    public static itemData _itemData;
    public  List<item> Items = new List<item>(); //списк в котором хранятся все предметы 
    [SerializeField]
    internal int countInv = 0;
    
    [SerializeField]
    internal Dictionary<int, item> charitem_InventoryPlayer = new Dictionary<int, item>(); //словарь содержащий предметы инвентаря 
    public  item tempo;
    public bool transfer;
  public  Texture2D dragTexture; //текстура которая отображается при перетягивании предмета в инвентаре 
    public GameObject testcall;

    private Invantory pizda_ebanaia;
    void Awake()
    {
        _itemData = this;
        pizda_ebanaia = testcall.GetComponent<Invantory>();
    }

    void Start()
    {
        checkwhere();
    }

    void Update()
    {
        //checkwhere();
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
    public bool addItem(item tempo)
    {
        if (countInv <= 28)
        {
            pizda_ebanaia.InventoryPlayer.Add(countInv, tempo);
            Items.Add(tempo);
            checkwhere();
            return true;
        }
        return false;
     
    }
    public void checkwhere()
    {
        for (int y = 0; y < 7; y++)
        {
            for (int x = 0; x < 4; x++)
            {
                if (pizda_ebanaia.InventoryPlayer.ContainsKey(countInv))//проверяем содеоржится ли ключ с данным значением 
                {
                    countInv = x + y * 4;
                }
           
            }
         
        }
    }

}
