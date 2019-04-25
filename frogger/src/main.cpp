#include <SFML/Graphics.hpp>
#include <SFML/Audio.hpp>
#include <iostream>
#include "Frog.h"
#include "Cars.h"
#include "FrogHome.h"
#include "Logs.h"





using namespace std;
int main() {





	//This is the value used for scaling the textures.
	//(it's used because I've upscaled everything by 3, because without upscaling, everything looked way too small, and by running the game in fullscreen the textures looked blurry)
	int scale = 3;

	//Death counter which is used further in the main.cpp code
	int deathCount;
	deathCount = 0;

	int SavedFrogHomes = 0;


	//Creating the render window of the game
	sf::RenderWindow window(sf::VideoMode(224*scale, 240*scale), "Frogger");

	//I tested the game on several systems and the cars moved with different speed.
	//Since every PC has a different processor, some are fast and some are slow, I had to limit the frame rate, so a faster processor wont make the cars seem to move really fast
	window.setFramerateLimit(60);

	//creating the textures and sprites of the background/map, the water, retry? screen and win screen
	sf::Texture BackgroundTexture;
	sf::Sprite BackgroundSprite;
	sf::Texture DeathScreenTexture;
	sf::Sprite DeathScreenSprite;
	sf::Texture WinScreenTexture;
	sf::Sprite WinScreenSprite;
	sf::Texture water;

	//adjusting the water texture,scale,size and position
	sf::RectangleShape waterZone;
	water.loadFromFile("Assets/water.png");
	waterZone.setTexture(&water);
	waterZone.setScale(scale, scale);
	waterZone.setSize(sf::Vector2f(224, 80));
	waterZone.setPosition(0, 16 * scale);


	//adjusting the texture,sprite and scale of the map/background
	BackgroundTexture.loadFromFile("Assets/Background.png");
	BackgroundSprite.setTexture(BackgroundTexture);
	BackgroundSprite.setScale(scale, scale);

	//adjusting the texture,sprite and scale of the "Retry?" screen
	DeathScreenTexture.loadFromFile("Assets/DeathScreen.png");
	DeathScreenSprite.setTexture(DeathScreenTexture);
	DeathScreenSprite.setScale(scale, scale);

	//adjusting the texture,sprite and scale of win screen
	WinScreenTexture.loadFromFile("Assets/WinScreen.png");
	WinScreenSprite.setTexture(WinScreenTexture);
	WinScreenSprite.setScale(scale, scale);


	//Creating the frog object
	Frog frog;

	//Creating the car objects
	Cars cars;

	//Creating the frog home object
	FrogHome frogHome;

	//Creating the log object
	Logs log;



	while (window.isOpen())
	{
		sf::Event event;

		while (window.pollEvent(event))
		{
			
			switch (event.type)
			{
				
			case sf::Event::Closed:
				window.close();

				break;

			case sf::Event::KeyPressed:

				//movement of the frog
				frog.move(event);

				break;


			case sf::Event::KeyReleased:

				//when escape is pressed, the game closes.
				if (event.key.code == sf::Keyboard::Escape)
				{
					window.close();
				}

				break;

		

			default:
				break;

				
			}

		}
		frogHome.spawnBase();
		//next 15 lines are the condition for collision detection between the frog and the cars
		if ((frog.returnShape().getGlobalBounds().intersects(cars.returnShapeFor1().getGlobalBounds())) ||
			(frog.returnShape().getGlobalBounds().intersects(cars.returnShapeFor2().getGlobalBounds())) ||
			(frog.returnShape().getGlobalBounds().intersects(cars.returnShapeFor3().getGlobalBounds())) || 
			(frog.returnShape().getGlobalBounds().intersects(cars.returnShapeFor4().getGlobalBounds())) ||
			(frog.returnShape().getGlobalBounds().intersects(cars.returnShapeFor5().getGlobalBounds())) ||
			(frog.returnShape().getGlobalBounds().intersects(cars.returnShapeFor6().getGlobalBounds())) ||
			(frog.returnShape().getGlobalBounds().intersects(cars.returnShapeFor7().getGlobalBounds())) ||
			(frog.returnShape().getGlobalBounds().intersects(cars.returnShapeFor8().getGlobalBounds())) ||
			(frog.returnShape().getGlobalBounds().intersects(cars.returnShapeFor9().getGlobalBounds())) ||
			(frog.returnShape().getGlobalBounds().intersects(cars.returnShapeFor10().getGlobalBounds())) || 
			(frog.returnShape().getGlobalBounds().intersects(cars.returnShapeFor11().getGlobalBounds())) || 
			(frog.returnShape().getGlobalBounds().intersects(cars.returnShapeFor12().getGlobalBounds())) || 
			(frog.returnShape().getGlobalBounds().intersects(cars.returnShapeFor13().getGlobalBounds())) || 
			(frog.returnShape().getGlobalBounds().intersects(cars.returnShapeFor14().getGlobalBounds())) || 
			(frog.returnShape().getGlobalBounds().intersects(cars.returnShapeFor15().getGlobalBounds())))
		{
			//This triggers the frog.death() function in Frog.cpp
			frog.death();

			//adds 1 to the death counter. The death counter is used at line 99 and 121.
			deathCount += 1;
		}
		

		//collision between the water and the frog and other objects which are in the water
		if (frog.returnShape().getGlobalBounds().intersects(waterZone.getGlobalBounds()))
		{
			bool inWater = true;

			//player collision with the left moving logs
			//if the player is on the logs, it means the player is not in the water,thus doesnt die
			if (frog.returnShape().getGlobalBounds().intersects(log.returnShapeFor1().getGlobalBounds()) ||
				frog.returnShape().getGlobalBounds().intersects(log.returnShapeFor2().getGlobalBounds()) ||
				frog.returnShape().getGlobalBounds().intersects(log.returnShapeFor3().getGlobalBounds()) ||
				frog.returnShape().getGlobalBounds().intersects(log.returnShapeFor6().getGlobalBounds()) ||
				frog.returnShape().getGlobalBounds().intersects(log.returnShapeFor7().getGlobalBounds()) ||
				frog.returnShape().getGlobalBounds().intersects(log.returnShapeFor8().getGlobalBounds()))
			{
				inWater = false;

				//This function carries the player when on logs
				frog.getCarriedLeft();
			}

			//player collision with the right moving logs
			if (frog.returnShape().getGlobalBounds().intersects(log.returnShapeFor4().getGlobalBounds()) ||
				frog.returnShape().getGlobalBounds().intersects(log.returnShapeFor5().getGlobalBounds()) ||
				frog.returnShape().getGlobalBounds().intersects(log.returnShapeFor9().getGlobalBounds()) ||
				frog.returnShape().getGlobalBounds().intersects(log.returnShapeFor10().getGlobalBounds()))
			{
				inWater = false;

				//This function carries the player when on logs
				frog.getCarriedRight();
			}

			//if the frog gets a home base, the frog doesn't die from the water
			if (frog.returnShape().getGlobalBounds().intersects(frogHome.returnShape().getGlobalBounds()))
			{
				inWater = false;
			}

			//if the frog is not at a home base or a log - dies
			if (inWater == true)
			{
				frog.death();
				deathCount += 1;
			}
		}

		//This kills the player if he goes off the screen
		if (((frog.returnShape().getPosition().x > 210 * scale) && (frog.returnShape().getPosition().y > 96 * scale)) || ((frog.returnShape().getPosition().x < 16 * scale && (frog.returnShape().getPosition().y > 96 * scale))) || ((frog.returnShape().getPosition().x > 224 * scale) && (frog.returnShape().getPosition().y < 96 * scale)) || ((frog.returnShape().getPosition().x < 0 * scale && (frog.returnShape().getPosition().y < 96 * scale))) || (frog.returnShape().getPosition().y > 208  * scale))
		{
			frog.death();
			deathCount++;
		}

		//If the frog reaches and gets a Frog Home
		if (frog.returnShape().getGlobalBounds().intersects(frogHome.returnShape().getGlobalBounds()))
		{
			frog.gotFrogHome(); // This line gives the frog 1000 points score and respawns the player
			frogHome.gotFrogHome(); // This line draws the Frog Home saved object 
			SavedFrogHomes+= 1; //This line of code adds 1 to the SavedFrogHomes
		}

		//Next 4 if statements are the win condition. If the frog gets all the home bases a win screen is displayed, asking the player if he wants to play again
		if (SavedFrogHomes == 5) {
			window.clear();
			window.draw(WinScreenSprite);
			window.display();
			if (sf::Event::KeyReleased)
			{
				if (event.key.code == sf::Keyboard::N)
				{
					window.close();
				}

				else if (event.key.code == sf::Keyboard::Y)
				{
					//if the user decides to press Y, everything resets to default and a new game is launched
					SavedFrogHomes = 0;
					deathCount = 0;
					frog.reset();
					cars.reset();
					frogHome.FrogHomeReset();
				}
				else if((event.key.code != sf::Keyboard::N) && (event.key.code != sf::Keyboard::Y)){
					//Do nothing
				}
			}
		}

		// Next 4 if loops are the code for the "Retry?" screen after the player lost all his 3 lifes
		if (deathCount == 3) {
			window.clear();
			window.draw(DeathScreenSprite);
			window.display();

			if (sf::Event::KeyReleased)
			{
				if (event.key.code == sf::Keyboard::N)
				{
					window.close();
				}

				if (event.key.code == sf::Keyboard::Y)
				{
					//if the user decides to press Y, everything resets to default and a new game is launched
					deathCount = 0;
					SavedFrogHomes = 0;
					frog.reset();
					cars.reset();
					frogHome.FrogHomeReset();
				}
				else if ((event.key.code != sf::Keyboard::N) && (event.key.code != sf::Keyboard::Y)) {
					//Do nothing
				}
			}
		}

	
		//This is the actual game happening (considering the death count is lesser than 3)
		if (deathCount != 3 && SavedFrogHomes != 5)
		{
			

			//the cars movement
			cars.move();
			
			//the logs movenet
			log.move();

			//clears the window
			window.clear();

			//drawing the map/background 
			window.draw(BackgroundSprite);

			//drawing the wtaer
			window.draw(waterZone);

			//draws the logs that float in the water
			log.draw(window);

			//draws the frog home object
			frogHome.draw(window);
			
			//draws the frog object
			frog.draw(window);

			//drawing the frog home
			frogHome.draw(window);

			//draws the car object
			cars.draw(window);

			
			//displays all the sprites that were drawn
			window.display();

			
		}
	}


	return 0;
}
