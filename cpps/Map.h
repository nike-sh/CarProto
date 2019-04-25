#pragma once
#include <SFML/Graphics.hpp>
#include <iostream>
#include "GlobalVariables.h"
#include "GameObject.h"

class Map : public GameObject
{
public:

	Map();
	void MapRiver(sf::Vector2u size, float posY);
	void MapPavement(sf::Vector2u size, float posY);
	void DrawFrogBase(sf::Vector2u size, float posx, float posy);
	bool FrogInBase();

private:


};