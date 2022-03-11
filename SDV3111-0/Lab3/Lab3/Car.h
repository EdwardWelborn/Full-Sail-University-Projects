// Car struct, and color definition enum

enum EnumColorDefinition
{
    Red = 1,
    Blue,
    Green,
    Yellow,
    Purple,
    Orange,
    Black
};

//sets car definition class
struct Car {
    char make[32];
    char model[32];
    int year;
    int mileage;
    EnumColorDefinition color;
};