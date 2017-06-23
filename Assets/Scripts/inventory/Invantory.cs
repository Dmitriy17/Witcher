using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Invantory : MonoBehaviour {
    const int INVENTORY_WINDOW_ID = 0; //id окна инвентаря 
    const int INVENTORY_TEXTURE_ID = 1; //id окна с иконкой 
    public float ButtonWidth = 40; //ширина ячейки 
    public float ButtonHeight = 40; //высота ячейки 
    int invRows = 7; //количество колонок 
    int invColumns = 4; //количество столбцов 
    Rect inventoryWindowRect = new Rect(318, 18, 170, 305); //область окна 
    Rect inventoryBoxRect = new Rect(); //область окна с изображением иконки 
    bool isDraggable; //возможно ли перемещение предмета 
    [SerializeField]
    internal Dictionary<int, item> InventoryPlayer = new Dictionary<int, item>(); //словарь содержащий предметы инвентаря 

    void Start()
    {

       
          
    }
    void OnGUI()
    {
        inventoryWindowRect = GUI.Window(INVENTORY_WINDOW_ID, inventoryWindowRect, firstInventory, "INVENTORY"); //создаем окно 
        if (itemData._itemData.transfer)
        {
           // print("zopa");
            inventoryBoxRect = GUI.Window(INVENTORY_TEXTURE_ID, new Rect(Event.current.mousePosition.x + 1, Event.current.mousePosition.y + 1, 40, 40), insert, "", "box");
        }
  
    }

    //окно с изображением иконки 
    void insert(int id)
    {
       GUI.BringWindowToFront(INVENTORY_TEXTURE_ID);//выводим на передний план окно с иконкой
        GUI.DrawTexture(new Rect(Event.current.mousePosition.x, Event.current.mousePosition.y, 40, 40), itemData._itemData.dragTexture);//рисуем текстуру иконки 
 
    }

    //окно с инвентарем 
    void firstInventory(int id)
    {
        for (int y = 0; y < invRows; y++)
        {
            for (int x = 0; x < invColumns; x++)
            {
                if (InventoryPlayer.ContainsKey(x + y * invColumns))//проверяем содеоржится ли ключ с данным значением 
                {
   
                    if (GUI.Button(new Rect(5 + (x * ButtonHeight), 20 + (y * ButtonHeight), ButtonWidth, ButtonHeight), new GUIContent(InventoryPlayer[x + y * invColumns].Texture), "button"))
                    {
                        print("dobavili");
                      
                        if (!itemData._itemData.transfer)
                        {
                            itemData._itemData.checkwhere();
                           itemData._itemData.dragTexture = InventoryPlayer[x + y * invColumns].Texture;//присваиваем нашой текстуре которая должна отображаться при перетаскивании, текстуру предмета 
                            itemData._itemData.tempo = InventoryPlayer[x + y * invColumns];
                            isDraggable = true;//возможность перемещать предмет 
                            itemData._itemData.transfer = true;
                            InventoryPlayer.Remove(x + y * invColumns);//удаляем из словаря предмет 
                           // itemData._itemData.countInv--;



                        }
                    }
                }
                else
                {
                    
                    if ( itemData._itemData.transfer)
                    {
                        itemData._itemData.checkwhere();
                        if (GUI.Button(new Rect(5 + (x * ButtonHeight), 20 + (y * ButtonHeight), ButtonWidth, ButtonHeight), "", "button"))
                        {
                            print("clickqwer 2");
                            InventoryPlayer.Add(x + y * invColumns, itemData._itemData.tempo);//добавляем предмет который перетаскиваем в словарь 
                                                                                                                 //обнуляем переменные 
                        //    itemData._itemData.countInv++;
                            isDraggable = false;
                           itemData._itemData.tempo = null;
                            itemData._itemData.transfer = false;
                        }
                    }
                    else
                    {
                        //делаем ячейки не выделяемыми 
                        GUI.Label(new Rect(5 + (x * ButtonHeight), 20 + (y * ButtonHeight), ButtonWidth, ButtonHeight), "", "button");
                    }
                //     = x + y * invColumns;
                }
            }
        }
        GUI.DragWindow();
    }
}
