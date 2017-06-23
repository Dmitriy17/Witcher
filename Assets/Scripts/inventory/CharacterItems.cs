using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterItems : MonoBehaviour {

    const int charitem_WINDOW_ID = 4; //id окна инвентаря 
    const int charitem_TEXTURE_ID = 1; //id окна с иконкой 
    public float charitem_ButtonWidth = 40; //ширина ячейки 
    public float charitem_ButtonHeight = 40; //высота ячейки 

    int charitem_Rows = 4; //количество колонок 
    int charitem_Columns = 1; //количество столбцов 
    Rect charitem_WindowRect = new Rect(245,38, 70, 265); //область окна 
    Rect charitem_BoxRect = new Rect(); //область окна с изображением иконки 
    
    public GameObject player;
    private PlayerHealth PlHealth;
    public GameObject project;


    void Start()
    {
        PlHealth = player.GetComponent<PlayerHealth>();
    }


    void OnGUI()
    {

         charitem_WindowRect = GUI.Window(charitem_WINDOW_ID, charitem_WindowRect, char_Inventory, "ITEMS"); //создаем окно 

        if (itemData._itemData.transfer)
        {
            charitem_BoxRect = GUI.Window(charitem_TEXTURE_ID, new Rect(Event.current.mousePosition.x + 1, Event.current.mousePosition.y + 1, 150, 80), char_insert, "", "box");
            
        }

    }

    //окно с изображением иконки 
    void char_insert(int id)
    {   
        GUI.BringWindowToFront(charitem_TEXTURE_ID);//выводим на передний план окно с иконкой 
        GUI.DrawTexture(new Rect(Event.current.mousePosition.x, Event.current.mousePosition.y+20, 55, 60),itemData._itemData.dragTexture);//рисуем текстуру иконки 
        GUI.TextArea(new Rect(Event.current.mousePosition.x , Event.current.mousePosition.y, 150, 20), itemData._itemData.tempo.name);
        GUI.TextArea(new Rect(Event.current.mousePosition.x+60, Event.current.mousePosition.y+20, 90, 20),"Damage :" +itemData._itemData.tempo.Damage.ToString());
        GUI.TextArea(new Rect(Event.current.mousePosition.x + 60, Event.current.mousePosition.y+40, 90, 20), "Health :"+itemData._itemData.tempo.Health.ToString());
        GUI.TextArea(new Rect(Event.current.mousePosition.x + 60, Event.current.mousePosition.y+60, 90, 20), "Mana :"+itemData._itemData.tempo.Mana.ToString());
    }

    //окно с инвентарем 
    void char_Inventory(int id)
    {
        for (int y = 0; y < charitem_Rows; y++)
        {
            for (int x = 0; x < charitem_Columns; x++)
            {
                if (itemData._itemData.charitem_InventoryPlayer.ContainsKey(x + y * charitem_Columns))//проверяем содеоржится ли ключ с данным значением 
                {
                    if (GUI.Button(new Rect(5 + (x * charitem_ButtonHeight), 20 + (y * charitem_ButtonHeight), charitem_ButtonWidth, charitem_ButtonHeight), new GUIContent(itemData._itemData.charitem_InventoryPlayer[x + y * charitem_Columns].Texture), "button"))
                    {
                        
                       if (!itemData._itemData.transfer)
                       {

                            addItemsChatacter(-itemData._itemData.charitem_InventoryPlayer[x + y * charitem_Columns].Health,
                              -itemData._itemData.charitem_InventoryPlayer[x + y * charitem_Columns].Mana,
                               -itemData._itemData.charitem_InventoryPlayer[x + y * charitem_Columns].Damage);
                            itemData._itemData.dragTexture = itemData._itemData.charitem_InventoryPlayer[x + y * charitem_Columns].Texture;//присваиваем нашой текстуре которая должна отображаться при перетаскивании, текстуру предмета 
                            itemData._itemData.transfer = true;//возможность перемещать предмет 
                            itemData._itemData.tempo = itemData._itemData.charitem_InventoryPlayer[x + y * charitem_Columns];//присваиваем вспомогательной переменной наш предмет 
                            itemData._itemData.charitem_InventoryPlayer.Remove(x + y * charitem_Columns);//удаляем из словаря предмет 
                            itemData._itemData.checkwhere();
                        }
                     
                    }
                }
                else
                {
                    if (itemData._itemData.transfer)
                    {
                      
                        if (GUI.Button(new Rect(5 + (x * charitem_ButtonHeight), 20 + (y * charitem_ButtonHeight), charitem_ButtonWidth, charitem_ButtonHeight), "", "button"))
                        {
                            if (itemData._itemData.transfer)
                            {
                                if(x + y * charitem_Columns ==0 && itemData._itemData.tempo.Type !="hat")
                                {
                                    break;
                                }
                                if (x + y * charitem_Columns == 1 && itemData._itemData.tempo.Type != "armor")
                                {
                                    break;
                                }
                                if (x + y * charitem_Columns == 2 && itemData._itemData.tempo.Type != "necklace")
                                {
                                    break;
                                }
                                if (x + y * charitem_Columns == 3 && itemData._itemData.tempo.Type != "ring")
                                {
                                    break;
                                }
                                itemData._itemData.charitem_InventoryPlayer.Add(x + y * charitem_Columns, itemData._itemData.tempo);//добавляем предмет который перетаскиваем в словарь 
                               
                                                                         //тут вставляем урон и тд                                 //обнуляем переменные 
                                itemData._itemData.transfer = false;
                                itemData._itemData.tempo = null;
                                addItemsChatacter(itemData._itemData.charitem_InventoryPlayer[x + y * charitem_Columns].Health, 
                                    itemData._itemData.charitem_InventoryPlayer[x + y * charitem_Columns].Mana, 
                                    itemData._itemData.charitem_InventoryPlayer[x + y * charitem_Columns].Damage);
                            }
                        }
                    }
                    else
                    {
                        //делаем ячейки не выделяемыми 
                        GUI.Label(new Rect(5 + (x * charitem_ButtonHeight), 20 + (y * charitem_ButtonHeight), charitem_ButtonWidth, charitem_ButtonHeight), "", "button");
                    }
                }
            }
        }
        GUI.DragWindow();
    }
    private void addItemsChatacter(int Health, int Mana,int Damage)
    {
        if (Health != 0)
        {
            PlHealth.healthPlayer.MaxValue += Health; // обсудить им хз как лучше апать все это
          PlHealth.healthPlayer.CurrentValue += Health;
        }
        if (Mana != 0)
        {
            PlHealth.manaPlayer.MaxValue += Mana;
            PlHealth.manaPlayer.CurrentValue +=Mana;
        }
        if(Damage != 0)
        {
            project.GetComponent<HitEffect>().weaponDamage += Damage;
        }
        PlHealth.healthText.text = PlHealth.healthPlayer.CurrentValue.ToString();
        PlHealth.manaText.text = PlHealth.manaPlayer.CurrentValue.ToString();
    }
}
