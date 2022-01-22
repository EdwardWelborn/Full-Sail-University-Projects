//=============================================================================
// Program's Item class
//=============================================================================

namespace Shop
{
    // TODO: Write a class called Item that contains 2 data members:
    //       A string called name and an int called cost.
    //       This class should have a default constructor that sets name to ""
    //       and cost to 0.
    //       It should also have an overloaded constructor that accepts 2
    //       parameters - a string and an int.
    //
    //       Write getters/accessors for each data member. They should be called
    //       GetName and GetCost.
    //
    //       Write setters/mutators for each data member. They should be called
    //       SetName and SetCost.
    class Item
    {
        private string name;
        private int cost;

        public Item()
        {
            name = "";
            cost = 0;
        }

        public Item(string itemName, int itemCost)
        {
            name = itemName;
            cost = itemCost;
        }

        public string GetName()
        {
            return name;
        }

        public int GetCost()
        {
            return cost;
        }

        public void SetName(string itemName)
        {
            name = itemName;
        }

        public void SetCost(int itemCost)
        {
            cost = itemCost;
        }

    }

}
