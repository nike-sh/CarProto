#include "GameObject.h"


GameObject::GameObject()
{
	sf::FloatRect MgoBoundingBox = object.getGlobalBounds();

}


void GameObject::Draw(sf::RenderWindow &window)
{
	window.draw(object);
}

sf::RectangleShape GameObject::GetShape()
{
	return object;
}
