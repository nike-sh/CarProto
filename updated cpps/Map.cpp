#include "Frog.h"
#include <SFML/Graphics.hpp>
#include <iostream>
#include <windows.h>
#include "GlobalVariables.h"
#include "Map.h"

using namespace std;

 Map::Map()
 {
	
 }

 void Map::MapRiver(sf::Vector2u size, float posY)
 {
	 object.setSize(sf::Vector2f( size.x, size.y/4.0f));
	 object.setOrigin(object.getSize().x / 2.0f, object.getSize().y / 2.0f);
	 object.setPosition(size.x / 2.0f, posY);
	 object.setFillColor(sf::Color::Blue);

 }

 void Map::MapPavement(sf::Vector2u size, float posY)
 {
	 object.setSize(sf::Vector2f(size.x, size.y / 10.0f));
	 object.setOrigin(object.getSize().x / 2.0f, object.getSize().y / 2.0f);
	 object.setPosition(size.x / 2.0f, posY + 16);
	 object.setFillColor(sf::Color::Yellow);

 }

 void Map::DrawFrogBase(sf::Vector2u size, float posx, float posy)
 {
	 object.setSize(sf::Vector2f(size.x/8.0f, size.y / 20.0f));
	 object.setOrigin(object.getSize().x / 2.0f, object.getSize().y / 2.0f);
	 object.setPosition(size.x / 4*(posx) , posy );
	 object.setFillColor(sf::Color(34, 139, 34, 255));


 }

 bool Map::FrogInBase()
 {
	 object.setSize(sf::Vector2f(FROG_SIZE_WIDTH, FROG_SIZE_HEIGHT));
	 object.setOrigin(object.getSize().x / 2, object.getSize().y);
	 object.setPosition(sf::Vector2f(object.getPosition().x , object.getPosition().y+16 ));
	 object.setFillColor(sf::Color::Green);
	 return true;
 }






