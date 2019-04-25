#include <SFML/Graphics.hpp>
#include <iostream>
#include <stdio.h>
#include <windows.h>
#include "Frog.h"
#include "Game.h"
#include "Car.h"
#include "Log.h"

using namespace std;

Game::Game()
{
	window = new sf::RenderWindow(sf::VideoMode(WINDOW_WIDTH, WINDOW_HEIGHT), WINDOW_TITLE);

	//sf::Texture texture; 
	//if (!texture.loadFromFile("background.png")) { // error: handle didn't load }
	
	//frog
	frog = new Frog(window->getSize(), Lane(17));

	//map
	Map pavement->MapPavement(window->getSize(), Lane(17), sf::Color::White);

	Map frogBase->MapPavement(window->getSize(), Lane(2), sf::Color::White);
	river = new Map(window->getSize(), Lane(7), sf::Color::Blue);
	river->MapRiver(window->getSize(), Lane(6));
	
	//Car instantiation
	car1 = new Car(20, Lane(16));
	car2 = new Car(250, Lane(16));
	car3 = new Car(390, Lane(16));

	car4 = new Car(10, Lane(15));
	car5 = new Car(480, Lane(15));

	car6 = new Car(0, Lane(14));
	car7 = new Car(160, Lane(14));
	car8 = new Car(400, Lane(14));

	car9 = new Car(100, Lane(13));
	car10 = new Car(300, Lane(13));

	car11 = new Car(0, Lane(12));
	car12 = new Car(300, Lane(12));


	// Log instantiation
	log1 = new Log(80, Lane(8));
	log2 = new Log(220, Lane(8));
	log3 = new Log(500, Lane(8));

	turtle1 = new Turtle(50, Lane(7));
	turtle2 = new Turtle(190, Lane(7));
	turtle3 = new Turtle(410, Lane(7));

	log4 = new Log(160, Lane(6));
	log5 = new Log(380, Lane(6));
	log6 = new Log(570, Lane(6));

	turtle4 = new Turtle(0, Lane(5));
	turtle5 = new Turtle(160, Lane(5));
	turtle6 = new Turtle(265, Lane(5));
	turtle7 = new Turtle(600, Lane(5));

	log7 = new Log(20, Lane(4));
	log8 = new Log(260, Lane(4));
	log9 = new Log(450, Lane(4));



}



void Game::Run()
{
	while (window->isOpen())
	{
		// handle events
		sf::Event event;

		while (window->pollEvent(event))
		{
			switch (event.type)
			{
			case sf::Event::KeyReleased:
				//frogger movement
				frog->FrogMove(event);

				break;

			default:
				break;
			}
		}

		// update  //

		//Cars// Lane 14
		car1->CarFast(1, Lane(16), window->getSize());
		CheckCollision(car1);
		car2->CarFast(1, Lane(16), window->getSize());
		CheckCollision(car2);
		car3->CarFast(1, Lane(16), window->getSize());
		CheckCollision(car3);
		//		 Lane 13
		car4->CarSlow(0, Lane(15), window->getSize());
		CheckCollision(car4);
		car5->CarSlow(0, Lane(15), window->getSize());
		CheckCollision(car5);
		//		 Lane 12
		car6->CarSlow(1, Lane(14), window->getSize());
		CheckCollision(car6);
		car7->CarSlow(1, Lane(14), window->getSize());
		CheckCollision(car7);
		car8->CarSlow(1, Lane(14), window->getSize());
		CheckCollision(car8);
		//		  Lane 11
		car9->CarFast(0, Lane(13), window->getSize());
		CheckCollision(car9);
		car10->CarFast(0, Lane(13), window->getSize());
		CheckCollision(car10);
		//         Lane 10
		car11->CarSlow(1, Lane(12), window->getSize());
		CheckCollision(car11);
		car12->CarSlow(1, Lane(12), window->getSize());
		CheckCollision(car12);


		//Logs     Lane 8
		log1->LogMoveRight(Lane(8), window->getSize());
		CheckCollision(log1);
		log2->LogMoveRight(Lane(8), window->getSize());
		CheckCollision(log2);
		log3->LogMoveRight(Lane(8), window->getSize());
		CheckCollision(log3);
		//		   Lane 7
		turtle1->TurtleMoveLeft(Lane(7), window->getSize());
		CheckCollision(turtle1);
		turtle2->TurtleMoveLeft(Lane(7), window->getSize());
		CheckCollision(turtle2);
		turtle3->TurtleMoveLeft(Lane(7), window->getSize());
		CheckCollision(turtle3);

		//		   Lane 6	
		log4->LogMoveRight(Lane(6), window->getSize());
		CheckCollision(log4);
		log5->LogMoveRight(Lane(6), window->getSize());
		CheckCollision(log5);
		log6->LogMoveRight(Lane(6), window->getSize());
		CheckCollision(log6);

		//		   Lane 5
		turtle4->TurtleMoveLeft(Lane(5), window->getSize());
		CheckCollision(turtle4);
		turtle5->TurtleMoveLeft(Lane(5), window->getSize());
		CheckCollision(turtle5);
		turtle6->TurtleMoveLeft(Lane(5), window->getSize());
		CheckCollision(turtle6);
		turtle7->TurtleMoveLeft(Lane(5), window->getSize());
		CheckCollision(turtle7);
		//		   Lane 4
		log7->LogMoveRight(Lane(4), window->getSize());
		CheckCollision(log7);
		log8->LogMoveRight(Lane(4), window->getSize());
		CheckCollision(log8);
		log9->LogMoveRight(Lane(4), window->getSize());
		CheckCollision(log9);

	//	CheckCollision(river, turtle1, log1);

		window->clear();

		// Draw Background
		pavement->Draw(*window);
		frogBase->Draw(*window);
		river->Draw(*window);

		//Draw Cars
		car1->Draw(*window);
		car2->Draw(*window);
		car3->Draw(*window);
		car4->Draw(*window);
		car5->Draw(*window);
		car6->Draw(*window);
		car7->Draw(*window);
		car8->Draw(*window);
		car9->Draw(*window);
		car10->Draw(*window);
		car11->Draw(*window);
		car12->Draw(*window);

		//Draw Logs
		log1->Draw(*window);
		log2->Draw(*window);
		log3->Draw(*window);
		log4->Draw(*window);
		log5->Draw(*window);
		log6->Draw(*window);
		log7->Draw(*window);
		log8->Draw(*window);
		log9->Draw(*window);

		//Draw Turtles
		turtle1->Draw(*window);
		turtle2->Draw(*window);
		turtle3->Draw(*window);
		turtle4->Draw(*window);
		turtle5->Draw(*window);
		turtle6->Draw(*window);
		turtle7->Draw(*window);

		//Draw Froggo

		frog->Draw(*window);

		window->display();
	}
}

float Game::Lane(int laneNumber)
{
	float lanePosY = laneNumber * window->getSize().y / 20.0f;
	return lanePosY;

}


void Game::CheckCollision(Car *car) {

	if (frog->GetShape().getGlobalBounds().intersects(car->GetShape().getGlobalBounds()))
	{
		frog->FrogReset(window->getSize());
		if (!frog->FrogLooseLife())
		{
			GameOver();
		}
	}
}
void Game::CheckCollision(Map *river, Turtle *turtle, Log *log)
{
	bool frogOnRiver = frog->GetShape().getGlobalBounds().intersects(river->GetShape().getGlobalBounds());
	bool frogOnLog = frog->GetShape().getGlobalBounds().intersects(log->GetShape().getGlobalBounds());
	bool frogOnTurtle = frog->GetShape().getGlobalBounds().intersects(turtle->GetShape().getGlobalBounds());

	if (frog->GetShape().getGlobalBounds().intersects(log->GetShape().getGlobalBounds()))
	{
		frog->FrogLogMove();
	}
	else if (frog->GetShape().getGlobalBounds().intersects(turtle->GetShape().getGlobalBounds()))
	{
		frog->FrogTurtleMove();
	}
	else if (frogOnRiver && !frogOnLog || frogOnRiver && !frogOnTurtle)
	{
		frog->FrogReset(window->getSize());
		if (!frog->FrogLooseLife())
		{
			GameOver();
		}
	}
	
}
void Game::CheckCollision(Log *log)
{
	if (frog->GetShape().getGlobalBounds().intersects(log->GetShape().getGlobalBounds()))
	{
		frog->FrogLogMove();
	}
}

void Game::CheckCollision(Turtle *turtle)
{
	if (frog->GetShape().getGlobalBounds().intersects(turtle->GetShape().getGlobalBounds()))
	{
		frog->FrogTurtleMove();
	}
}



void Game::GameOver()
{
	cout << "End ~Game" << endl;
	window->close();
}

