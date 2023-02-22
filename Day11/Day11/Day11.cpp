// Day11.cpp : This file contains the 'main' function. Program execution begins and ends there.
//

#include <iostream>
#include <vector>
using namespace std;//not good professional code

enum Superpower
{
    Money, Speed, Strength, MindControl
};
typedef double Batman;
int main()
{
    Superpower myPower = Superpower::Speed;
    switch (myPower
)
    {
    case Money:
        break;
    case Speed:
        break;
    case Strength:
        break;
    case MindControl:
        break;
    default:
        break;
    }
    Batman bruce = 5.3;
    //std -- namespace
    //:: -- scope resolution operator
    //<< -- insertion operator. inserting into the cout stream
    //cout -- console output stream
    std::cout << "Hello World!\n" << 5 << "\n";

    cout << sizeof(char) << " (bytes)\n";

    char best[] = "Batman"; // \0 -- null terminator
    char meh[] = { 'A','q','u','a','m','a','n', '\0'};

    cout << best << "\n" << meh << "\n";

    for (size_t i = 0; i < 6; i++)
    {

    }

    srand(time(NULL));
    int rando = rand();//0-RAND_MAX 32767 (short)

    rando = rand() % 101; //0-100


}