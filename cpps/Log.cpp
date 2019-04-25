#include "Log.h"
#include <SFML/Graphics.hpp>
#include <iostream>
#include "GlobalVariables.h"
using namespace std;

Log::Log(float posX, float posY)
{
	
		object.setSize(sf::Vector2f(LOG_SIZE_WIDTH, LOG_SIZE_HEIGHT));
		object.setOrigin(object.getSize().x / 2, object.getSize().y / 2);
		object.setPosition(posX - object.getSize().x, posY);
		object.setFillColor(sf::Color(153, 153, 255, 255));


	//	sf::Vector2f smallLog = sf::Vector2f(40.0f, 20.0f);
	//	sf::Vector2f largeLog = sf::Vector2f(60.0f, 20.0f);

		sf::FloatRect MgoBoundingBox = object.getGlobalBounds();

}
void Log::LogMoveRight(float posY, sf::Vector2u size)
{
	object.move(LOG_MOVEMENT_SPEED, 0.0f);
	if (object.getPosition().x > size.x)
	{
		object.setPosition(sf::Vector2f(0.0f - object.getSize().x, posY ));
	}
}


