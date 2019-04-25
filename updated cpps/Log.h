#pragma once

#include <SFML/Graphics.hpp>
#include <iostream>
#include "GameObject.h"
#include "GlobalVariables.h"

class Log : public GameObject
{
public:

	Log(float posx, float posy);
	void LogMoveRight( float posY, sf::Vector2u size);

private:


};



