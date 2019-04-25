#include "Logs.h"



Logs::Logs()
{
	logTexture[0].loadFromFile("Assets/log.png");
	logTexture[1].loadFromFile("Assets/bigLog.png");
	//LOGS FOR THE FIRST LANE
	//
	//
	//
	//
	//

	//Setting the texture we loaded in the sprite object
	logShape[0].setTexture(&logTexture[0]);

	//Setting the position of the sprite object when the game starts
	logShape[0].setPosition(sf::Vector2f(160 * scale, 82 * scale));

	//Setting the size of the shape (16 by 16 pixels, the same as the texture)
	logShape[0].setSize(sf::Vector2f(42, 12));

	//setting the logs scale
	logShape[0] .setScale(scale, scale);



	logShape[1].setTexture(&logTexture[0]);

	logShape[1].setPosition(sf::Vector2f(244 * scale, 82 * scale));

	logShape[1].setSize(sf::Vector2f(42, 12));

	logShape[1].setScale(scale, scale);
	

	logShape[2].setTexture(&logTexture[0]);

	logShape[2].setPosition(sf::Vector2f(328 * scale, 82 * scale));

	logShape[2].setSize(sf::Vector2f(42, 12));

	logShape[2].setScale(scale, scale);


	//THE BIG LOGS FOR THE SECOND LANE
	//
	//
	//
	//
	//
	logShape[3].setTexture(&logTexture[1]);

	logShape[3].setPosition(sf::Vector2f(126 * scale, 66 * scale));

	logShape[3].setSize(sf::Vector2f(63, 12));

	logShape[3].setScale(scale, scale);


	logShape[4].setTexture(&logTexture[1]);

	logShape[4].setPosition(sf::Vector2f(-126 * scale, 66 * scale));

	logShape[4].setSize(sf::Vector2f(63, 12));

	logShape[4].setScale(scale, scale);

	//THE LOGS FOR THE THIRD LANE
	//
	//
	//
	//
	//
	logShape[5].setTexture(&logTexture[0]);

	logShape[5].setPosition(sf::Vector2f(118 * scale, 50 * scale));

	logShape[5].setSize(sf::Vector2f(42, 12));

	logShape[5].setScale(scale, scale);


	logShape[6].setTexture(&logTexture[0]);

	logShape[6].setPosition(sf::Vector2f(202 * scale, 50 * scale));

	logShape[6].setSize(sf::Vector2f(42, 12));

	logShape[6].setScale(scale, scale);


	logShape[7].setTexture(&logTexture[0]);

	logShape[7].setPosition(sf::Vector2f(286 * scale, 50 * scale));

	logShape[7].setSize(sf::Vector2f(42, 12));

	logShape[7].setScale(scale, scale);

	//THE LOGS FOR THE FOURTH LANE
//
//
//
//
//
	logShape[8].setTexture(&logTexture[1]);

	logShape[8].setPosition(sf::Vector2f(63 * scale, 34 * scale));

	logShape[8].setSize(sf::Vector2f(63, 12));

	logShape[8].setScale(scale, scale);


	logShape[9].setTexture(&logTexture[1]);

	logShape[9].setPosition(sf::Vector2f(168 * scale, 34 * scale));

	logShape[9].setSize(sf::Vector2f(63, 12));

	logShape[9].setScale(scale, scale);

}


Logs::~Logs()
{
}



void Logs::draw(sf::RenderWindow& window)
{
	
	window.draw(logShape[0]);
	window.draw(logShape[1]);
	window.draw(logShape[2]);
	window.draw(logShape[3]);
	window.draw(logShape[4]);
	window.draw(logShape[5]);
	window.draw(logShape[6]);
	window.draw(logShape[7]);
	window.draw(logShape[8]);
	window.draw(logShape[9]);

}

sf::RectangleShape Logs::returnShapeFor1() {
	return logShape[0];

}

sf::RectangleShape Logs::returnShapeFor2() {
	return logShape[1];

}

sf::RectangleShape Logs::returnShapeFor3() {
	return logShape[2];

}

sf::RectangleShape Logs::returnShapeFor4() {
	return logShape[3];

}

sf::RectangleShape Logs::returnShapeFor5() {
	return logShape[4];

}

sf::RectangleShape Logs::returnShapeFor6() {
	return logShape[5];

}

sf::RectangleShape Logs::returnShapeFor7() {
	return logShape[6];

}

sf::RectangleShape Logs::returnShapeFor8() {
	return logShape[7];

}


sf::RectangleShape Logs::returnShapeFor9() {
	return logShape[8];

}


sf::RectangleShape Logs::returnShapeFor10() {
	return logShape[9];

}

void Logs::move()
{
	//LOGS FOR THE FIRST LANE
	//
	//
	//
	logShape[0].move(-1.5, 0);
	if (logShape[0].getPosition().x < -42 * scale)
	{
		logShape[0].setPosition(244 * scale, 82 * scale);
	}

	logShape[1].move(-1.5, 0);
	if (logShape[1].getPosition().x < -42 * scale)
	{
		logShape[1].setPosition(244 * scale, 82 * scale);
	}

	logShape[2].move(-1.5, 0);
	if (logShape[2].getPosition().x < -42 * scale)
	{
		logShape[2].setPosition(244 * scale, 82 * scale);
	}

	//LOGS FOR THE SECOND LANE
	//
	//
	//
	logShape[3].move(1.5, 0);
	if (logShape[3].getPosition().x > 307 * scale)
	{
		logShape[3].setPosition(-63 * scale, 66 * scale);
	}

	logShape[4].move(1.5, 0);
	if (logShape[4].getPosition().x > 307 * scale)
	{
		logShape[4].setPosition(-63 * scale, 66 * scale);
	}

	//LOGS FOR THE THIRD LANE
	//
	//
	//
	logShape[5].move(-1.5, 0);
	if (logShape[5].getPosition().x < -42 * scale)
	{
		logShape[5].setPosition(244 * scale, 50 * scale);
	}
	logShape[6].move(-1.5, 0);
	if (logShape[6].getPosition().x < -42 * scale)
	{
		logShape[6].setPosition(244 * scale, 50 * scale);
	}
	logShape[7].move(-1.5, 0);
	if (logShape[7].getPosition().x < -42 * scale)
	{
		logShape[7].setPosition(244 * scale, 50 * scale);
	}

	//LOGS FOR THE FOURTH LANE
	//
	//
	logShape[8].move(1.5, 0);
	if (logShape[8].getPosition().x > 307 * scale)
	{
		logShape[8].setPosition(-63 * scale, 34 * scale);
	}

	logShape[9].move(1.5, 0);
	if (logShape[9].getPosition().x > 307 * scale)
	{
		logShape[9].setPosition(-63 * scale, 34 * scale);
	}
}