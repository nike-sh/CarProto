#pragma once

#include <SFML/Graphics.hpp>

class GameObject
{
public:
	GameObject();

	void Draw(sf::RenderWindow &window);

	sf::RectangleShape GetShape();

protected:
	sf::RectangleShape object;

};