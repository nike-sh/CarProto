#pragma once

#include <SFML/Graphics.hpp>
#include <iostream>
#include "GameObject.h"
#include "GlobalVariables.h"

class Turtle : public GameObject
{
public:

	Turtle(float posx, float posy);
	void TurtleMoveLeft(float posY, sf::Vector2u size);

private:


};

