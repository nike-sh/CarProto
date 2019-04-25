#pragma once
#include "Game.h"
#include <SFML/Graphics.hpp>
#include "Frog.h"
#include "Log.h"
#include "Car.h"
#include "Turtle.h"
#include "Map.h"

class Game
{
public:

	Game();
	void Run();
	float Lane(int laneNumber);
	void CheckCarCollision(Car *car);
	void CheckLogCollision(Log *log, Map *river);
	void CheckTurtleCollision(Turtle *turtle);
	void CheckMapCollision(Map *map);
	void GameOver();
	int Score();
	sf::Text livesText;


	sf::Event event;


private:

	int score;
	sf::RenderWindow *window;
	Frog *frog;
	Map *pavement;
	Map *frogBaseHazard;
	Map *river;
	Map *frogBase1;
	Map *frogBase2;
	Map *frogBase3;
		
	Car *car1;
	Car *car2;
	Car *car3;
	Car *car4;
	Car *car5;
	Car *car6;
	Car *car7;
	Car *car8;
	Car *car9;
	Car *car10;
	Car *car11;
	Car *car12;

	Log *log1;
	Log *log2;
	Log *log3;
	Log *log4;
	Log *log5;
	Log *log6;
	Log *log7;
	Log *log8;
	Log *log9;

	Turtle *turtle1;
	Turtle *turtle2;
	Turtle *turtle3;
	Turtle *turtle4;
	Turtle *turtle5;
	Turtle *turtle6;
	Turtle *turtle7;

};