#pragma once
#include <SFML/Graphics.hpp>
class Logs
{
public:
	Logs();
	~Logs();

	//draws the log textures, in order to be displayed(from the main.cpp)
	void draw(sf::RenderWindow& window);

	//This function holds the movement of the logs.
	void move();

	//This function resets the logs positions if the player chooses to retry the game after losing all 3 lifes.
	void reset();

	sf::RectangleShape returnShapeFor1();
	sf::RectangleShape returnShapeFor2();
	sf::RectangleShape returnShapeFor3();
	sf::RectangleShape returnShapeFor4();
	sf::RectangleShape returnShapeFor5();
	sf::RectangleShape returnShapeFor6();
	sf::RectangleShape returnShapeFor7();
	sf::RectangleShape returnShapeFor8();
	sf::RectangleShape returnShapeFor9();
	sf::RectangleShape returnShapeFor10();


private:

	//Initializing the different log shapes
	sf::RectangleShape logShape[11];

	//Initializing the different log textures
	sf::Texture logTexture[2];

	//This is the value used for scaling the textures.
	//(it's used because I've upscaled everything by 3, because without upscaling, everything looked way too small, and by running the game in fullscreen the textures looked blurry)
	int scale = 3;

};

