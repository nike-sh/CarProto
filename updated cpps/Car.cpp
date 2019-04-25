#include "Car.h"
#include"GlobalVariables.h"

Car::Car(float posx, float posy)
{
	object.setSize(sf::Vector2f(CAR_SIZE_WIDTH, CAR_SIZE_HEIGHT));
	object.setOrigin(object.getSize().x / 2, object.getSize().y / 2);
	object.setPosition(posx - object.getSize().x, posy);
	object.setFillColor(sf::Color::Red);


}

void Car::CarFast(int Direction, float posY, sf::Vector2u size)
{
	if (Direction == 1)
	{
		object.move(highSpeed	, 0.0);
		if (object.getPosition().x > size.x)
		{
			object.setPosition(sf::Vector2f(0 - object.getSize().x, posY));
		}
	}
	else 
	{
		object.move(-highSpeed, 0.0);
		if (object.getPosition().x < 0)
		{
			object.setPosition(sf::Vector2f(640 + object.getSize().x, posY));
		}
	}
	
}

void Car::CarSlow(int Direction, float posY, sf::Vector2u size)
{
	
	if (Direction == 1)
	{
		object.move(lowSpeed, 0.0);
		if (object.getPosition().x > size.x)
		{
			object.setPosition(sf::Vector2f(0 - object.getSize().x, posY));
		}
	}
	else 
	{
		object.move(-lowSpeed, 0.0);
		if (object.getPosition().x < 0)
		{
			object.setPosition(sf::Vector2f(640 + object.getSize().x, posY));
		}
	}
}

