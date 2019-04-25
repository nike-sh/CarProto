#include "Cars.h"



Cars::Cars()
{
	//Loading the 5 different car textures
	//
	//
	//
	carTexture[0].loadFromFile("Assets/Car1.png"); //this texture is for the cars driving on the 1st lane
	carTexture[1].loadFromFile("Assets/Car2.png"); //this texture is for the cars driving on the 2st lane
	carTexture[2].loadFromFile("Assets/Car3.png"); //this texture is for the cars driving on the 3st lane
	carTexture[3].loadFromFile("Assets/Car4.png"); //this texture is for the cars driving on the 3st lane
	carTexture[4].loadFromFile("Assets/Car5.png"); //this texture is for the cars driving on the 3st lane


	//CARS FOR THE FIRST LANE
	//
	//
	//
	//
	//

	//Setting the texture we loaded in the sprite object
	carShape[0].setTexture(&carTexture[0]);

	//Setting the position of the sprite object when the game starts
	carShape[0].setPosition(sf::Vector2f(130*scale, 176*scale));

	//Setting the size of the shape (16 by 16 pixels, the same as the texture)
	carShape[0].setSize(sf::Vector2f(16, 16));

	//setting the cars scale
	carShape[0].setScale(scale, scale);


	carShape[1].setTexture(&carTexture[0]);

	carShape[1].setPosition(sf::Vector2f(224 * scale, 176 * scale));

	carShape[1].setSize(sf::Vector2f(16, 16));

	carShape[1].setScale(scale, scale);


	carShape[2].setTexture(&carTexture[0]);

	carShape[2].setPosition(sf::Vector2f(318 * scale, 176 * scale));

	carShape[2].setSize(sf::Vector2f(16, 16));

	carShape[2].setScale(scale, scale);


	//CARS FOR THE SECOND LANE
	//
	//
	//
	//

	carShape[3].setTexture(&carTexture[1]);

	carShape[3].setPosition(sf::Vector2f(25 * scale, 160 * scale));

	carShape[3].setSize(sf::Vector2f(16, 16));

	carShape[3].setScale(scale, scale);


	carShape[4].setTexture(&carTexture[1]);

	carShape[4].setPosition(sf::Vector2f(-50 * scale, 160 * scale));

	carShape[4].setSize(sf::Vector2f(16, 16));

	carShape[4].setScale(scale, scale);


	carShape[5].setTexture(&carTexture[1]);

	carShape[5].setPosition(sf::Vector2f(-175 * scale, 160 * scale));

	carShape[5].setSize(sf::Vector2f(16, 16));

	carShape[5].setScale(scale, scale);

	
	//CARS FOR THE THIRD LANE
	//
	//
	//
	//

	carShape[6].setTexture(&carTexture[2]);

	carShape[6].setPosition(sf::Vector2f(183 * scale, 144 * scale));
	
	carShape[6].setSize(sf::Vector2f(16, 16));

	carShape[6].setScale(scale, scale);


	carShape[7].setTexture(&carTexture[2]);

	carShape[7].setPosition(sf::Vector2f(100 * scale, 144 * scale));

	carShape[7].setSize(sf::Vector2f(16, 16));

	carShape[7].setScale(scale, scale);


	carShape[8].setTexture(&carTexture[2]);

	carShape[8].setPosition(sf::Vector2f(275 * scale, 144 * scale));

	carShape[8].setSize(sf::Vector2f(16, 16));

	carShape[8].setScale(scale, scale);


	//CARS FOR THE FOURTH LANE
	//
	//
	//
	//

	carShape[9].setTexture(&carTexture[3]);

	carShape[9].setPosition(sf::Vector2f(55 * scale, 128* scale));

	carShape[9].setSize(sf::Vector2f(16, 16));

	carShape[9].setScale(scale, scale);


	carShape[10].setTexture(&carTexture[3]);

	carShape[10].setPosition(sf::Vector2f(-25 * scale, 128* scale));

	carShape[10].setSize(sf::Vector2f(16, 16));

	carShape[10].setScale(scale, scale);


	carShape[11].setTexture(&carTexture[3]);

	carShape[11].setPosition(sf::Vector2f(-100 * scale, 128* scale));

	carShape[11].setSize(sf::Vector2f(16, 16));

	carShape[11].setScale(scale, scale);

	
	//CARS FOR THE FIFTH LANE
	//
	//
	//
	//

	carShape[12].setTexture(&carTexture[4]);

	carShape[12].setPosition(sf::Vector2f(250 * scale, 112 * scale));

	carShape[12].setSize(sf::Vector2f(32, 16));

	carShape[12].setScale(scale, scale);


	carShape[13].setTexture(&carTexture[4]);

	carShape[13].setPosition(sf::Vector2f(350 * scale, 112 * scale));

	carShape[13].setSize(sf::Vector2f(32, 16));

	carShape[13].setScale(scale, scale);


	carShape[14].setTexture(&carTexture[4]);

	carShape[14].setPosition(sf::Vector2f(450 * scale, 112 * scale));

	carShape[14].setSize(sf::Vector2f(32, 16));

	carShape[14].setScale(scale, scale);

}


Cars::~Cars()
{
}

void Cars::draw(sf::RenderWindow& window)
{
	//draws the cars to the render window.
	//after which, they are displayed from the main.cpp
	for (int i = 0; i < 15; i++)
	{
		window.draw(carShape[i]);
	}

}

//The sf::rectangeShape Cars are returning the shapes of the Cars. 
//It's later used in the main.cpp in order to detect collision between car(number)Shape and the Frog
sf::RectangleShape Cars::returnShapeFor1() {
	return carShape[0];
}

sf::RectangleShape Cars::returnShapeFor2() {
	return carShape[1];
}

sf::RectangleShape Cars::returnShapeFor3() {
	return carShape[2];
}

sf::RectangleShape Cars::returnShapeFor4() {
	return carShape[3];
}

sf::RectangleShape Cars::returnShapeFor5() {
	return carShape[4];
}

sf::RectangleShape Cars::returnShapeFor6() {
	return carShape[5];
}

sf::RectangleShape Cars::returnShapeFor7() {
	return carShape[6];
}

sf::RectangleShape Cars::returnShapeFor8() {
	return carShape[7];
}

sf::RectangleShape Cars::returnShapeFor9() {
	return carShape[8];
}

sf::RectangleShape Cars::returnShapeFor10() {
	return carShape[9];
}

sf::RectangleShape Cars::returnShapeFor11() {
	return carShape[10];
}

sf::RectangleShape Cars::returnShapeFor12() {
	return carShape[11];
}

sf::RectangleShape Cars::returnShapeFor13() {
	return carShape[12];
}

sf::RectangleShape Cars::returnShapeFor14() {
	return carShape[13];
}

sf::RectangleShape Cars::returnShapeFor15() {
	return carShape[14];
}


void Cars::move()
{
	//CARS FOR THE FIRST LANE
	//
	//
	//
	//
	
	
	carShape[0].move(-1.5 , 0); //Moving the car with 0.125 speed on the X axis. It's -0.125 because it's going left. Next number is 0, because we don't want movement on the Y axis
	if (carShape[0].getPosition().x < -16 * scale) //This code is for when the car leaves the render window, it respawns at the opposite end of the render window which the car tried to leave
	{
		carShape[0].setPosition(224 * scale, 176 * scale); //This the respawning part
	}


	carShape[1].move(-1.5, 0);
	if (carShape[1].getPosition().x < -16 * scale)
	{
		carShape[1].setPosition(224 * scale, 176 * scale);
	}


	carShape[2].move(-1.5, 0);
	if (carShape[2].getPosition().x < -16 * scale)
	{
		carShape[2].setPosition(224 * scale, 176 * scale);
	}


	//CARS FOR THE SECOND LANE
	//
	//
	//
	//

	carShape[3].move(1, 0);
	if (carShape[3].getPosition().x > 240 * scale)
	{
		carShape[3].setPosition(-16 * scale, 160 * scale);
	}

	carShape[4].move(1, 0);
	if (carShape[4].getPosition().x > 240 * scale)
	{
		carShape[4].setPosition(-16 * scale, 160 * scale);
	}

	carShape[5].move(1, 0);
	if (carShape[5].getPosition().x > 240 * scale)
	{
		carShape[5].setPosition(-16 * scale, 160 * scale);
	}



	//CARS FOR THE THIRD LANE
	//
	//
	//

	carShape[6].move(-2, 0);
	if (carShape[6].getPosition().x < -16 * scale)
	{
		carShape[6].setPosition(224 * scale, 144 * scale);
	}

	carShape[7].move(-2, 0);
	if (carShape[7].getPosition().x < -16 * scale)
	{
		carShape[7].setPosition(224 * scale, 144 * scale);
	}

	carShape[8].move(-2, 0);
	if (carShape[8].getPosition().x < -16 * scale)
	{
		carShape[8].setPosition(224 * scale, 144 * scale);
	}

	//CARS FOR THE FOURTH LANE
	//
	//
	//

	carShape[9].move(1.5, 0);
	if (carShape[9].getPosition().x > 240 * scale)
	{
		carShape[9].setPosition(-16 * scale, 128 * scale);
	}

	carShape[10].move(1.5, 0);
	if (carShape[10].getPosition().x > 240 * scale)
	{
		carShape[10].setPosition(-16 * scale, 128 * scale);
	}

	carShape[11].move(1.5, 0);
	if (carShape[11].getPosition().x > 240 * scale)
	{
		carShape[11].setPosition(-16 * scale, 128 * scale);
	}



	//CARS FOR THE FIFTH LANE
	//
	//
	//
	carShape[12].move(-1, 0);
	if (carShape[12].getPosition().x < -40 * scale)
	{
		carShape[12].setPosition(224 * scale, 112 * scale);
	}

	carShape[13].move(-1, 0);
	if (carShape[13].getPosition().x < -40 * scale)
	{
		carShape[13].setPosition(224 * scale, 112 * scale);
	}

	carShape[14].move(-1, 0);
	if (carShape[14].getPosition().x < -40 * scale)
	{
		carShape[14].setPosition(224 * scale, 112 * scale);
	}
}


void Cars::reset(){

	
	//Resets all the cars position to the default position (the position specified at the begining of Cars.cpp


    //CARS FOR THE FIRST LANE
	//
	//
	//

	
	carShape[0].setPosition(sf::Vector2f(130 * scale, 176 * scale));
	carShape[1].setPosition(sf::Vector2f(224 * scale, 176 * scale));
	carShape[2].setPosition(sf::Vector2f(318 * scale, 176 * scale));

	//CARS FOR THE SECOND LANE
	//
	//
	//
	carShape[3].setPosition(sf::Vector2f(25 * scale, 159.75 * scale));
	carShape[4].setPosition(sf::Vector2f(-50 * scale, 159.75 * scale));
	carShape[5].setPosition(sf::Vector2f(-175 * scale, 159.75 * scale));

	//CARS FOR THE THIRD LANE
	//
	//
	//
	carShape[6].setPosition(sf::Vector2f(183 * scale, 144 * scale));
	carShape[7].setPosition(sf::Vector2f(100 * scale, 144 * scale));
	carShape[8].setPosition(sf::Vector2f(275 * scale, 144 * scale));

	//CARS FOR THE FOURTH LANE
	//
	//
	//
	carShape[9].setPosition(sf::Vector2f(55 * scale, 128 * scale));
	carShape[10].setPosition(sf::Vector2f(-25 * scale, 128 * scale));
	carShape[11].setPosition(sf::Vector2f(-100 * scale, 128 * scale));
	
	//CARS FOR THE FIFTH LANE
	//
	//
	//
	carShape[12].setPosition(sf::Vector2f(244 * scale, 112 * scale));
	carShape[13].setPosition(sf::Vector2f(320 * scale, 112 * scale));
	carShape[14].setPosition(sf::Vector2f(400 * scale, 112 * scale));
}
