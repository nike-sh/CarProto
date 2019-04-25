#include "Turtle.h"
#include <SFML/Graphics.hpp>
#include <iostream>
#include "GlobalVariables.h"


Turtle::Turtle(float posX, float posY)
{

	object.setSize(sf::Vector2f(TURTLE_SIZE_WIDTH, TURTLE_SIZE_HEIGHT));
	object.setOrigin(object.getSize().x / 2, object.getSize().y / 2);
	object.setPosition(posX - object.getSize().x, posY);
	object.setFillColor(sf::Color::Cyan);


	//	sf::Vector2f smallLog = sf::Vector2f(40.0f, 20.0f);
	//	sf::Vector2f largeLog = sf::Vector2f(60.0f, 20.0f);

	sf::FloatRect MgoBoundingBox = object.getGlobalBounds();

}
void Turtle::TurtleMoveLeft(float posY, sf::Vector2u size)
{
	object.move(-TURTLE_MOVEMENT_SPEED, 0.0f);
	if (object.getPosition().x < 0.0f)
	{
		object.setPosition(sf::Vector2f(640.0f + object.getSize().x, posY));
	}

}

