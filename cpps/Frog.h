#pragma once

#include <SFML/Graphics.hpp>
#include "GameObject.h"
#include "GlobalVariables.h"

class Frog : public GameObject
{
public:
	Frog(sf::Vector2u size, float posY);
	void FrogMove(sf::Event event, sf::Vector2u size);
	void FrogLogMove();
	void FrogTurtleMove();
	void FrogReset(sf::Vector2u size);
	int ReadFrogLives();
	bool FrogLooseLife();


private:
	int frogLives = 3;
};