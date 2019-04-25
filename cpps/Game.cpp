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

	//
	livesText.setCharacterSize(24);
	livesText.setFillColor(sf::Color::Green);


	//frog
	frog = new Frog(window->getSize(), Lane(17));

	//map
	pavement = new Map();
	pavement->MapPavement(window->getSize(), Lane(17));

	frogBaseHazard = new Map();
	frogBaseHazard->MapPavement(window->getSize(), Lane(2));

	river = new Map();
	river->MapRiver(window->getSize(), Lane(6));

	frogBase1 = new Map();
	frogBase1->DrawFrogBase(window->getSize(), 1, Lane(3));

	frogBase2 = new Map();
	frogBase2->DrawFrogBase(window->getSize(), 2, Lane(3));

	frogBase3 = new Map();
	frogBase3->DrawFrogBase(window->getSize(), 3, Lane(3));


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

		while (window->pollEvent(event))
		{
			switch (event.type)
			{
			case sf::Event::KeyReleased:
				//frogger movement
				frog->FrogMove(event, window->getSize());

				break;

			default:
				break;
			}
		}

		// update  //
		livesText.setString("Lives = " + frog->ReadFrogLives());
		livesText.setPosition(64, Lane(1));

		//Map 
		CheckMapCollision(frogBase1);
		CheckMapCollision(frogBase2);
		CheckMapCollision(frogBase3);


		//Cars// Lane 14
		car1->CarFast(1, Lane(16), window->getSize());
		CheckCarCollision(car1);
		car2->CarFast(1, Lane(16), window->getSize());
		CheckCarCollision(car2);
		car3->CarFast(1, Lane(16), window->getSize());
		CheckCarCollision(car3);
		//		 Lane 13
		car4->CarSlow(0, Lane(15), window->getSize());
		CheckCarCollision(car4);
		car5->CarSlow(0, Lane(15), window->getSize());
		CheckCarCollision(car5);
		//		 Lane 12
		car6->CarSlow(1, Lane(14), window->getSize());
		CheckCarCollision(car6);
		car7->CarSlow(1, Lane(14), window->getSize());
		CheckCarCollision(car7);
		car8->CarSlow(1, Lane(14), window->getSize());
		CheckCarCollision(car8);
		//		  Lane 11
		car9->CarFast(0, Lane(13), window->getSize());
		CheckCarCollision(car9);
		car10->CarFast(0, Lane(13), window->getSize());
		CheckCarCollision(car10);
		//         Lane 10
		car11->CarSlow(1, Lane(12), window->getSize());
		CheckCarCollision(car11);
		car12->CarSlow(1, Lane(12), window->getSize());
		CheckCarCollision(car12);


		//Logs     Lane 8
		log1->LogMoveRight(Lane(8), window->getSize());
		CheckLogCollision(log1, river);
		log2->LogMoveRight(Lane(8), window->getSize());
		CheckLogCollision(log2, river);
		log3->LogMoveRight(Lane(8), window->getSize());
		CheckLogCollision(log3, river);
		//		   Lane 7
		turtle1->TurtleMoveLeft(Lane(7), window->getSize());
		CheckTurtleCollision(turtle1);
		turtle2->TurtleMoveLeft(Lane(7), window->getSize());
		CheckTurtleCollision(turtle2);
		turtle3->TurtleMoveLeft(Lane(7), window->getSize());
		CheckTurtleCollision(turtle3);

		//		   Lane 6	
		log4->LogMoveRight(Lane(6), window->getSize());
		//CheckLogCollision(log4);
		log5->LogMoveRight(Lane(6), window->getSize());
		//CheckLogCollision(log5);
		log6->LogMoveRight(Lane(6), window->getSize());
		//CheckLogCollision(log6);

		//		   Lane 5
		turtle4->TurtleMoveLeft(Lane(5), window->getSize());
		CheckTurtleCollision(turtle4);
		turtle5->TurtleMoveLeft(Lane(5), window->getSize());
		CheckTurtleCollision(turtle5);
		turtle6->TurtleMoveLeft(Lane(5), window->getSize());
		CheckTurtleCollision(turtle6);
		turtle7->TurtleMoveLeft(Lane(5), window->getSize());
		CheckTurtleCollision(turtle7);
		//		   Lane 4
		log7->LogMoveRight(Lane(4), window->getSize());
		//CheckLogCollision(log7);
		log8->LogMoveRight(Lane(4), window->getSize());
		//CheckLogCollision(log8);
		log9->LogMoveRight(Lane(4), window->getSize());
		//CheckLogCollision(log9);


		window->clear();

		// Draw Background
		window->draw(livesText);

		pavement->Draw(*window);
		frogBaseHazard->Draw(*window);
		river->Draw(*window);
		frogBase1->Draw(*window);
		frogBase2->Draw(*window);
		frogBase3->Draw(*window);

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


void Game::CheckCarCollision(Car *car) {

	if (frog->GetShape().getGlobalBounds().intersects(car->GetShape().getGlobalBounds()))
	{
		frog->FrogReset(window->getSize());
		if (!frog->FrogLooseLife())
		{
			GameOver();
		}
	}
}

void Game::CheckLogCollision(Log *log, Map *river)
{
	bool frogTouchLog = frog->GetShape().getGlobalBounds().intersects(log->GetShape().getGlobalBounds());
	bool frogTouchRiver = frog->GetShape().getGlobalBounds().intersects(river->GetShape().getGlobalBounds());

	if (frogTouchLog && frogTouchRiver)
	{
		frog->FrogLogMove();
	
	}
}

void Game::CheckTurtleCollision(Turtle *turtle)
{
	if (frog->GetShape().getGlobalBounds().intersects(turtle->GetShape().getGlobalBounds()))
	{
		frog->FrogTurtleMove();
	}
}

void Game::CheckMapCollision(Map *map)
{
	if (frog->GetShape().getGlobalBounds().intersects(map->GetShape().getGlobalBounds()))
	{
		map->FrogInBase();
		frog->FrogReset(window->getSize());
		Score();
	}
}

void Game::GameOver()
{
	cout << "End ~Game" << endl;
	window->close();
}

int Game::Score()
{
	score++;
	cout << score << endl;

	return score;
}

