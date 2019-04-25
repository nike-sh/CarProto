#include "FrogHome.h"



FrogHome::FrogHome()
{

	//loading the texture from the file, loading the texture into the shape, setting the size, scale and position.
	FrogHomeTexture.loadFromFile("Assets/FrogHome.png");
	FrogHomeShape.setTexture(&FrogHomeTexture);
	FrogHomeShape.setSize(sf::Vector2f(16, 16));
	FrogHomeShape.setScale(scale, scale);
	FrogHomeShape.setPosition(500 * scale, 16 * scale);
	

	SavedFrogHomeTexture.loadFromFile("Assets/FrogHomeSaved.png");

	//For the first saved frog home 
	SavedFrogHomeShape[0].setTexture(&SavedFrogHomeTexture);
	SavedFrogHomeShape[0].setSize(sf::Vector2f(16, 16));
	SavedFrogHomeShape[0].setScale(scale, scale);
	SavedFrogHomeShape[0].setPosition(500 * scale, 16 * scale);

	//For the second saved frog home 
	SavedFrogHomeShape[1].setTexture(&SavedFrogHomeTexture);
	SavedFrogHomeShape[1].setSize(sf::Vector2f(16, 16));
	SavedFrogHomeShape[1].setScale(scale, scale);
	SavedFrogHomeShape[1].setPosition(500 * scale, 16 * scale);

	//For the third saved frog home 
	SavedFrogHomeShape[2].setTexture(&SavedFrogHomeTexture);
	SavedFrogHomeShape[2].setSize(sf::Vector2f(16, 16));
	SavedFrogHomeShape[2].setScale(scale, scale);
	SavedFrogHomeShape[2].setPosition(500 * scale, 16 * scale);

	//For the fourth saved frog home 
	SavedFrogHomeShape[3].setTexture(&SavedFrogHomeTexture);
	SavedFrogHomeShape[3].setSize(sf::Vector2f(16, 16));
	SavedFrogHomeShape[3].setScale(scale, scale);
	SavedFrogHomeShape[3].setPosition(500 * scale, 16 * scale);

	//For the fifth saved frog home 
	SavedFrogHomeShape[4].setTexture(&SavedFrogHomeTexture);
	SavedFrogHomeShape[4].setSize(sf::Vector2f(16, 16));
	SavedFrogHomeShape[4].setScale(scale, scale);
	SavedFrogHomeShape[4].setPosition(500 * scale, 16 * scale);

	//boolean  indicating wether or not a frog base has been reached
	FrogBaseReached[0] = false;
	FrogBaseReached[1] = false;
	FrogBaseReached[2] = false;
	FrogBaseReached[3] = false;
	FrogBaseReached[4] = false;

	//how many frog bases have been reached
	//(this is used later in an if statement. If more than 3 bases have been  reached, the next 2 bases will spawn faster
	spawnPointsTakenCount = 0;
}


FrogHome::~FrogHome()
{
}

void FrogHome::spawnBase() {
	if (FrogHomeTimer.getElapsedTime().asSeconds() > 7.5f)
	{
		//next 5 lines of code are used for generating a random number between 1 and 5. The position of the FrogHome depends on the number the algorithm chooses
		

		if (spawnPointsTakenCount > 3)
		{
			std::random_device rd;
			std::mt19937 gen(rd());
			std::uniform_int_distribution<> dis(4, 8);
			FrogHomePosValue = dis(gen);
			FrogHomePos = FrogHomePosValue;
		}
		else if (spawnPointsTakenCount <= 3)
		{
			std::random_device rd;
			std::mt19937 gen(rd());
			std::uniform_int_distribution<> dis(1, 8);
			FrogHomePosValue = dis(gen);
			FrogHomePos = FrogHomePosValue;
		}

		FrogHomeTimer.restart();
		
		//This sets the frog base/home position of the screen. I've added 3 of these, because I dont want the base always spawning on the screen.
		if (FrogHomePos == 1)
		{
			FrogHomeShape.setPosition(500 * scale, 16 * scale);
		}
		if (FrogHomePos == 2)
		{
			FrogHomeShape.setPosition(500 * scale, 16 * scale);
		}
		if (FrogHomePos == 3)
		{
			FrogHomeShape.setPosition(500 * scale, 16 * scale);
		}
		else if (FrogHomePos == 4)
		{
			if (FrogBaseReached[0] == false) 
			{
				FrogHomeShape.setPosition(8 * scale, 16 * scale);
			}
			else if(FrogBaseReached[0] == true)
			{
				FrogHomeShape.setPosition(500 * scale, 16 * scale);
			}
		}
		else if (FrogHomePos == 5)
		{
			if (FrogBaseReached[1] == false)
			{
				FrogHomeShape.setPosition(56 * scale, 16 * scale);
			}
			else if (FrogBaseReached[1] == true)
			{
				FrogHomeShape.setPosition(500 * scale, 16 * scale);
			}
		}
		else if (FrogHomePos == 6)
		{
			if (FrogBaseReached[2] == false)
			{
				FrogHomeShape.setPosition(104 * scale, 16 * scale);
			}
			else if (FrogBaseReached[2] == true)
			{
				FrogHomeShape.setPosition(500 * scale, 16 * scale);
			}
		}
		else if (FrogHomePos == 7)
		{
			if (FrogBaseReached[3] == false)
			{
				FrogHomeShape.setPosition(152 * scale, 16 * scale);
			}
			else if (FrogBaseReached[3] == true)
			{
				FrogHomeShape.setPosition(500 * scale, 16 * scale);
			}
		}
		else if (FrogHomePos == 8)
		{
			if (FrogBaseReached[4] == false)
			{
				FrogHomeShape.setPosition(200 * scale, 16 * scale);
			}
			else if (FrogBaseReached[4] == true)
			{
				FrogHomeShape.setPosition(500 * scale, 16 * scale);
			}
		}
	}
	
	

}




void FrogHome::draw(sf::RenderWindow& window) {
	//draws the shapes, which are displayed after that(from the main.cpp)
	window.draw(FrogHomeShape);
	for (int i = 0; i < 5; i++) {
		window.draw(SavedFrogHomeShape[i]);
	}

}


sf::RectangleShape FrogHome::returnShape() {
	//Returns the frog shape, which is used in the main.cpp for detecting collision between the frog and the different cars
	return FrogHomeShape;
}


void FrogHome::gotFrogHome() {

	//if the frog reaches a home base, the saved home/base texture appears at its position
	SavedFrogHomePosX = FrogHomeShape.getGlobalBounds().left;
	SavedFrogHomePosY = FrogHomeShape.getGlobalBounds().top;

	std::cout << "X is:" << SavedFrogHomePosX << "\n";
	std::cout << "Y is:" << SavedFrogHomePosY << "\n";
	

	if (SavedFrogHomePosX == 600)
	{
		SavedFrogHomeShape[4].setPosition(SavedFrogHomePosX, SavedFrogHomePosY);
		FrogBaseReached[4] = true;
		spawnPointsTakenCount++;

	} 
	else if (SavedFrogHomePosX == 456)
	{
		SavedFrogHomeShape[3].setPosition(SavedFrogHomePosX, SavedFrogHomePosY);
		FrogBaseReached[3] = true;
		spawnPointsTakenCount++;
	}
	else if (SavedFrogHomePosX == 312)
	{
		SavedFrogHomeShape[2].setPosition(SavedFrogHomePosX, SavedFrogHomePosY);
		FrogBaseReached[2] = true;
		spawnPointsTakenCount++;
	}
	else if (SavedFrogHomePosX == 168)
	{
		SavedFrogHomeShape[1].setPosition(SavedFrogHomePosX, SavedFrogHomePosY);
		FrogBaseReached[1] = true;
		spawnPointsTakenCount++;
	}
	else if (SavedFrogHomePosX = 24)
	{
		SavedFrogHomeShape[0].setPosition(SavedFrogHomePosX, SavedFrogHomePosY);
		FrogBaseReached[0] = true;
		spawnPointsTakenCount++;
	}
	std::cout << spawnPointsTakenCount << "frogs are saved! \n";

}

void FrogHome::FrogHomeReset() {

	//the function resets everything, if the player wants to retry/play a new game

	for (int i = 0; i < 5; i++)
	{
		SavedFrogHomeShape[i].setPosition(500 * scale, 16);
	}

	FrogBaseReached[0] = false;
	FrogBaseReached[1] = false;
	FrogBaseReached[2] = false;
	FrogBaseReached[3] = false;
	FrogBaseReached[4] = false;

	spawnPointsTakenCount = 0;

}
	