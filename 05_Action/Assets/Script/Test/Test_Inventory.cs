using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Test_Inventory : TestBase
{
    public InventoryUI inventoryUI;

    [Range(1, 30)]
    public int invenSize = 10;
    Inventory inven;

    private void Start()
    {
        inven = new Inventory(null, invenSize);
        inventoryUI.InitializeInventory(inven);
    }

    protected override void Test1(InputAction.CallbackContext _)
    {
        inven.PrintInventory();
    }

    protected override void Test2(InputAction.CallbackContext _)
    {
        Test_AddItemForUI();
        inventoryUI.InitializeInventory(inven);
    }    

    protected override void Test3(InputAction.CallbackContext _)
    {
        inven.MoveItem(0, 3);
    }    

    protected override void Test4(InputAction.CallbackContext _)
    {
        inven.MoveItem(3, 0);
    }
    
    protected override void Test5(InputAction.CallbackContext _)
    {
        //inven.AddItem(ItemIDCode.Ruby, 9);
        //inven.AddItem(ItemIDCode.Emerald, 8);
        //inven.AddItem(ItemIDCode.Sapphire, 20);

    }


    void Test_AddItemForUI()
    {
        inven.ClearInventory();

        inven.AddItem(ItemIDCode.Ruby);
        inven.AddItem(ItemIDCode.Ruby);
        inven.AddItem(ItemIDCode.Ruby);
        inven.AddItem(ItemIDCode.Ruby);
        inven.AddItem(ItemIDCode.Emerald);
        inven.AddItem(ItemIDCode.Emerald);
        inven.AddItem(ItemIDCode.Sapphire);

        inven.AddItem(ItemIDCode.Ruby, 5);
        inven.AddItem(ItemIDCode.Ruby, 5);
        inven.AddItem(ItemIDCode.Ruby, 5);
        inven.AddItem(ItemIDCode.Ruby, 5);

        inven.PrintInventory();
    }


    private void Test_AddItem()
    {
        inven.AddItem(ItemIDCode.Ruby);
        inven.AddItem(ItemIDCode.Emerald);
        inven.AddItem(ItemIDCode.Sapphire);

        inven.AddItem(ItemIDCode.Emerald);
        inven.AddItem(ItemIDCode.Ruby);

        inven.PrintInventory();
    }

    private void MoveItem()
    {
        Test_AddItem();         // 0:??????2, 1:??????2, 2:??????1

        inven.MoveItem(0, 9);   // 1:??????2, 2:??????1, 9:??????2
        inven.PrintInventory();
        inven.MoveItem(9, 15);  // ?????? ??????
        inven.PrintInventory();

        inven.MoveItem(1, 2);   // 1:??????1, 2:??????2, 9:??????2
        inven.PrintInventory();

        inven.MoveItem(5, 6);   // ????????? ??????
        inven.PrintInventory();
        inven.MoveItem(5, 1);   // ????????? ??????
        inven.PrintInventory();

        inven.AddItem(ItemIDCode.Sapphire, 0);  // 0:??????1, 1:??????1, 2:??????2, 9:??????2
        inven.PrintInventory();
        inven.MoveItem(0, 1);   // 1:??????2, 2:??????2, 9:??????2
        inven.PrintInventory();
    }

    private void Test_ItemStack()
    {
        //inven.RemoveItem(0);
        //inven.RemoveItem(1, 3);

        inven.AddItem(ItemIDCode.Ruby);
        inven.AddItem(ItemIDCode.Ruby);
        inven.AddItem(ItemIDCode.Ruby);
        inven.AddItem(ItemIDCode.Ruby);
        inven.AddItem(ItemIDCode.Emerald);
        inven.AddItem(ItemIDCode.Emerald);
        inven.AddItem(ItemIDCode.Sapphire);

        inven.PrintInventory();     // 0:??????4, 1:??????2, 2: ??????1

        inven.AddItem(ItemIDCode.Ruby, 5);
        inven.AddItem(ItemIDCode.Ruby, 5);

        inven.PrintInventory();     // 0:??????4, 1:??????2, 2:??????1,  5:??????2

        inven.MoveItem(0, 5);

        inven.PrintInventory();     // 0:??????1, 1:??????2, 2:??????1,  5:??????5
    }
}
