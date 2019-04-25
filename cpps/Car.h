#pragma once
#include <SFML/Graphics.hpp>
#include <iostream>
#include "GlobalVariables.h"
#include "GameObject.h"

class Car : public GameObject
{
public:

	Car(float posx, float posy);
	void CarFast(int Direction, float posY, sf::Vector2u size);
	void CarSlow(int Direction, float posY, sf::Vector2u size);
	float highSpeed = 0.05f;
	float lowSpeed = 0.025f;


private:

};