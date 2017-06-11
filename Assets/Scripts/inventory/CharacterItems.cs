using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterItems : MonoBehaviour {

    const int CHARITEM_WINDOW_ID = 1; //id окна инвентаря 
    const int CHARITEM_TEXTURE_ID = 2; //id окна с иконкой 
    public float ButtonWidth = 40; //ширина ячейки 
    public float ButtonHeight = 40; //высота ячейки 

    int charitem_Rows = 4; //количество колонок 
    int charitem_Columns = 1; //количество столбцов 
    Rect charitem_WindowRect = new Rect(245,38, 70, 265); //область окна 
    Rect charitem_BoxRect = new Rect(); //область окна с изображением иконки 
    bool isDraggable; //возможно ли перемещение предмета 
    item selectItem; //вспомогательная переменная куда заносим предмет инвентаря 
    Texture2D dragTexture; //текстура которая отображается при перетягивании предмета в инвентаре 

    Dictionary<int, item> charitem_Player = new Dictionary<int, item>(); //словарь содержащий предметы инвентаря 

    void Start()
    {
       
    }


    void OnGUI()
    {
        charitem_WindowRect = GUI.Window(INVENTORY_WINDOW_ID, charitem_WindowRectt, firstInventory, "ITEMS"); //создаем окно 
        if (isDraggable)
        {
            charitem_BoxRect = GUI.Window(INVENTORY_TEXTURE_ID, new Rect(Event.current.mousePosition.x + 1, Event.current.mousePosition.y + 1, 40, 40), insert, "", "box");

        }
    }

    //окно с изображением иконки 
    void insert(int id)
    {
        GUI.BringWindowToFront(INVENTORY_TEXTURE_ID);//выводим на передний план окно с иконкой 
        GUI.DrawTexture(new Rect(Event.current.mousePosition.x, Event.current.mousePosition.y, 40, 40), dragTexture);//рисуем текстуру иконки 
    }

    //окно с инвентарем 
    void first_charItem(int id)
    {
        for (int y = 0; y < invRows; y++)
        {
            for (int x = 0; x < invColumns; x++)
            {
                if (InventoryPlayer1.ContainsKey(x + y * invColumns))//проверяем содеоржится ли ключ с данным значением 
                {
                    if (GUI.Button(new Rect(5 + (x * ButtonHeight), 20 + (y * ButtonHeight), ButtonWidth, ButtonHeight), new GUIContent(InventoryPlayer1[x + y * invColumns].Texture), "button"))
                    {
                        if (!isDraggable)
                        {
                            dragTexture = InventoryPlayer1[x + y * invColumns].Texture;//присваиваем нашой текстуре которая должна отображаться при перетаскивании, текстуру предмета 
                            isDraggable = true;//возможность перемещать предмет 
                            selectItem = InventoryPlayer1[x + y * invColumns];//присваиваем вспомогательной переменной наш предмет 
                            InventoryPlayer1.Remove(x + y * invColumns);//удаляем из словаря предмет 
                        }
                    }
                }
                else
                {
                    if (isDraggable)
                    {
                        if (GUI.Button(new Rect(5 + (x * ButtonHeight), 20 + (y * ButtonHeight), ButtonWidth, ButtonHeight), "", "button"))
                        {
                            InventoryPlayer1.Add(x + y * invColumns, selectItem);//добавляем предмет который перетаскиваем в словарь 
                                                                                //обнуляем переменные 
                            isDraggable = false;
                            selectItem = null;
                        }
                    }
                    else
                    {
                        //делаем ячейки не выделяемыми 
                        GUI.Label(new Rect(5 + (x * ButtonHeight), 20 + (y * ButtonHeight), ButtonWidth, ButtonHeight), "", "button");
                    }
                }
            }
        }
        GUI.DragWindow();
    }
}
