#pragma once
#include <SFML/Graphics.hpp>
#include <iostream>
#include <random>
#include <Frog.h>


class FrogHome 
{
public:
	//Initializes the frog homes at the (the ones that spawn at the end of the level)
	FrogHome();
	~FrogHome();

	//draws the frog home (including the saved frog home) in order to be displayed from main.cpp
	void draw(sf::RenderWindow& window);

	// the function that spawns them
	void spawnBase();

	//function when the frog reaches the frog home
	void gotFrogHome();

	//return the frog home shape and the saves frog homes
	sf::RectangleShape returnShape();

	//the function resets everything, if the player wants to retry/play a new game
	void FrogHomeReset();

private:
	//creating the shape for the frog home
	sf::RectangleShape FrogHomeShape;

	//creating the shape for the reached/saved frog home
	sf::RectangleShape SavedFrogHomeShape[5];

	//creating the texture for the frog home
	sf::Texture FrogHomeTexture;

	//creating the texture for the Saved frog home
	sf::Texture SavedFrogHomeTexture;

	//This is a timer which after it passes certain amount of time, the frog home respawns at a different location
	sf::Clock FrogHomeTimer;

	//Indicator for the Frog home spawn positioning
	int FrogHomePos;

	//The value of the indicator
	int FrogHomePosValue;

	//scale used for everything which needed scaling
	int scale = 3;

	//if the player gets a frog home, these two integers save the location of the frog home in order to initialize the Frog Home Saved shape
	int SavedFrogHomePosX;
	int SavedFrogHomePosY;


	//returns true if the particular frog base has been reached, and false if it still hasnt
	bool FrogBaseReached[5];

	//Counter for how many spawn points are taken. if there are 4 spawn points taken, the 5th one is going to spawn sooner than usual (because I figured out you have to wait a lot otherwise)
	int spawnPointsTakenCount;

	

};

