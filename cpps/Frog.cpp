#include "Frog.h"
#include <SFML/Graphics.hpp>
#include <iostream>
#include <windows.h>
#include "GlobalVariables.h"

using namespace std;

Frog::Frog(sf::Vector2u size, float posY)
{

	object.setSize(sf::Vector2f(FROG_SIZE_WIDTH, FROG_SIZE_HEIGHT));
	object.setOrigin(object.getSize().x / 2, object.getSize().y);
	object.setPosition(sf::Vector2f(size.x / 2.0f, size.y -48.0f));
	object.setFillColor(sf::Color::Green);
	object.setOutlineColor(sf::Color::Black);
	object.setOutlineThickness(1.0f);

}

void Frog::FrogMove(sf::Event event, sf::Vector2u size)
{
	if (event.key.code == sf::Keyboard::Up && object.getPosition().y > 128) {

		//y = y -32.0f;
		object.move(0, -FROG_MOVEMENT_AMOUNT);
		cout << " move UP " << endl;
	}
	else if (event.key.code == sf::Keyboard::Left && object.getPosition().x > 32) {

		//x = x - 32.0f;
		object.move(-FROG_MOVEMENT_AMOUNT, 0);
		cout << " move LEFT " << endl;
	}
	else if (event.key.code == sf::Keyboard::Down&& object.getPosition().y < size.y - 64) {

		// y = y + 32.0f;
		object.move(0, FROG_MOVEMENT_AMOUNT);
		cout << " move DOWN " << endl;
	}
	else if (event.key.code == sf::Keyboard::Right && object.getPosition().x < size.x - 32) {

		//x = x + 32.0f;
		object.move(FROG_MOVEMENT_AMOUNT, 0);
		cout << " move Right " << endl;
	}
	else if (event.key.code == sf::Keyboard::Space && object.getPosition().y > 32) {


		cout << " JUMP " << endl;
		// y = y - 64.0f;
		object.move(0, -FROG_MOVEMENT_AMOUNT * 2);
	}
}

void Frog::FrogReset(sf::Vector2u size)
{
	object.setPosition(sf::Vector2f(size.x / 2.0f, size.y - 48.0f));
	cout << "frog reset" << endl;
	
}

int Frog::ReadFrogLives()
{
	return frogLives;
}

bool Frog::FrogLooseLife()
{

	frogLives--;

	if (frogLives <= 0)
	{
		cout << "no lives left" << endl;
		return false;
	}
	return true;
}

void Frog::FrogLogMove()
{
	object.move(LOG_MOVEMENT_SPEED, 0.0f);

}

void Frog::FrogTurtleMove()
{
	object.move(-TURTLE_MOVEMENT_SPEED, 0.0f);

}

