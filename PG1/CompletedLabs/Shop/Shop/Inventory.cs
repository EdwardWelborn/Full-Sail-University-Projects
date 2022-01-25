//=============================================================================
// Program's Inventory class
//=============================================================================

using System;

namespace Shop
{
    internal class Inventory
    {
        private int mGold;

        private readonly Item[] mItems = new Item[0];

        // TODO: Define three member fields
        //       An int called mMaxSize
        //       An array of Items called mItems
        //       An int called mGold
        private readonly int mMaxSize;

        // TODO: Write a default constructor that assigns the mMaxSize to 10,
        //       mItems to a new array of Items with mMaxSize as the size,
        //       and mGold to 50.
        public Inventory()
        {
            mMaxSize = 10;
            mItems = new Item[mMaxSize];
            mGold = 50;
        }

        // TODO: Write a C# property for mGold called Gold (it has to
        //       access/update the mGold member field).

        public int Gold
        {
            get => mGold;
            set => mGold = value;
        }


        // TODO: Write a method called AddItem that returns a bool and takes an Item parameter.
        //       This method should iterate through the mItems array, looking for any array element
        //       that is null. If a null Item is found, it should assign that array element to the
        //       Item passed in and return true. Otherwise it should return false.
        public bool AddItem(Item item)
        {
            var itemAdded = false;
            for (var j = 0; j < mItems.Length; j++)
                if (mItems[j] == null)
                {
                    mItems[j] = item;
                    itemAdded = true;
                    break;
                }

            return itemAdded;
        }

        // TODO: Write a method called RemoveItem that returns a bool and takes a string parameter.
        //       This method should iterate through the mItems array, looking for an Item that
        //       has the same name as the parameter. If it finds a match it should set that 
        //       element of the mItems array to null and return true. Otherwise return false.
        //       Do not forget to make sure the element is not null before checking its name.
        public bool RemoveItem(string itemName)
        {
            var itemRemoved = false;
            for (var j = 0; j < mItems.Length; j++)
                if (mItems[j] != null)
                    if (mItems[j].GetName() == itemName)
                    {
                        mItems[j] = null;
                        itemRemoved = true;
                        break;
                    }

            return itemRemoved;
        }

        // TODO: Write a method called GetItem that returns an Item and takes a string parameter.
        //       This method should iterate through the mItems array, looking for an Item that
        //       has the same name as the parameter. If it finds a match it should return that element 
        //       of the mItems array. Otherwise return null.
        //       Do not forget to make sure the element is not null before checking its name.

        public Item GetItem(string itemName)
        {
            Item item = null;
            for (var j = 0; j < mItems.Length; j++)
                if (mItems[j] != null)
                    if (mItems[j].GetName() == itemName)
                    {
                        item = mItems[j];
                        break;
                    }

            return item;
        }
        // TODO: Uncomment the following code:

        public void DisplayInventory(int x, int y)
        {
            Console.SetCursorPosition(x, ++y);
            Console.Write("Item Name");
            Console.SetCursorPosition(x + 17, y);
            Console.Write("Item Cost");

            for (var i = 0; i < mMaxSize; i++)
                if (mItems[i] != null)
                {
                    Console.SetCursorPosition(x, ++y);
                    Console.Write(mItems[i].GetName());
                    Console.SetCursorPosition(x + 17, y);
                    Console.Write(mItems[i].GetCost());
                }

            y += 2;
            Console.SetCursorPosition(x, ++y);
            Console.Write("Gold on hand:");
            Console.SetCursorPosition(x + 17, y);
            Console.Write(mGold);
        }
    }
}