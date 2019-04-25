#pragma once
#include <SFML/Graphics.hpp>
#include <SFML/Audio.hpp>
#include <iostream>







class Frog
{

public:

	//In this constructor the textures, sprites, shapes, positions, origins, texture rectangles and scaling for the Frog and the Frog Lifes are loaded/adjusted.
	Frog();

	~Frog();

	//draws the Frog textures, in order to be displayed(from the main.cpp)
	void draw(sf::RenderWindow& window);

	//This function holds the movement of the Frog.
	void move(sf::Event event);

	//This function returns the shape of the frog, which is later used in the main.cpp to detect collision between the frog and the cars
	sf::RectangleShape returnShape();

	//Carries the frog while on a log
	void getCarriedLeft();
	void getCarriedRight();

	//This function is triggered by the collision detection from the main.cpp
	//it acts as the life system, resets the player position when he dies and asks if the player wants to retry when he is out of lifes.
	void death();

	//if the player chooses to retry (from the void death function), everything (player position, lifes, player steps, score, etc) resets to default
	void reset();

	//This function is triggered if the player succeeds to catch a frog home
	void gotFrogHome();

	




private:

	//creates the frog's shape
	sf::RectangleShape frogShape;

	//creates the score board texture
	sf::Texture ScoreTexture;

	//creates the frog's texture
	sf::Texture frogTexture;

	//creates the frogs lifes on the top left corner of the window
	sf::Texture froglifesTexture;

	//creates the texture of the "Retry? Y N" screen
	sf::Texture deathScreenTexture;

	//creates the sprite for the the texture of the "Retry? Y N" screen
	sf::Sprite deathScreenSprite;

	//creates the sprite for frogs life texture
	sf::Sprite froglifesSprite;

	//creates the sprite for the score board
	sf::Sprite ScoreSprite;

	//creates the frogs frogs life texture rectangle
	sf::IntRect froglifesRect;

	//creates the score board texture rectangle
	sf::IntRect ScoreRect;

	//creates the clock which counts the cooldown for the player movement
	sf::Clock movementClock;

	//creating the sound buffers which are then loaded into the actual sound object (when the player dies, when the player gets a frog home and when the player wins the game)
	sf::SoundBuffer playerDiesSoundBuff;
	sf::SoundBuffer playerReachesHomeSoundBuff;
	
	//creating the sounds
	sf::Sound playerDiesSound;
	sf::Sound playerReachesHomeSound;

	//scale used for everything which needed scaling
	int scale = 3;

	//counter for the lifes 
	int lifes;

	//counter for the score
	int scoreCounter;


};

