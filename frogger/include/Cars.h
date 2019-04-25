#pragma once
#include <SFML/Graphics.hpp>

class Cars
{
public:
	//In this constructor all 15 cars textures,shapes,positions,etc. are adjusted/loaded.
	Cars();

	~Cars();

	//draws the car textures, in order to be displayed(from the main.cpp)
	void draw(sf::RenderWindow& window);

	//This function holds the movement of the cars.
	void move();

	//This function resets the car positions if the player chooses to retry the game after losing all 3 lifes.
	void reset();

	//The next 15 functions are returning the specified car shapes, which are then used in the main.cpp to detect collision between the different cars and the frog
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
	sf::RectangleShape returnShapeFor11();
	sf::RectangleShape returnShapeFor12();
	sf::RectangleShape returnShapeFor13();
	sf::RectangleShape returnShapeFor14();
	sf::RectangleShape returnShapeFor15();

private:

	//Initializing the different car shapes
	sf::RectangleShape carShape[15];

	//Initializing the different car textures
	sf::Texture carTexture[5];

	//This is the value used for scaling the textures.
	//(it's used because I've upscaled everything by 3, because without upscaling, everything looked way too small, and by running the game in fullscreen the textures looked blurry)
	int scale = 3;
};

