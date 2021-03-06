﻿using System;

namespace Task2
{
    /// <summary>
    /// Describes actions performed by the hero in game
    /// Sets game settings(hero and map colors)
    /// </summary>
    public class Game
    {
        private readonly Map map;
        private readonly Hero hero;

        public Game(string fileName)
        {
            Console.CursorVisible = false;
            Console.ForegroundColor = ConsoleColor.DarkGreen;
            map = new Map(fileName);
            Console.ForegroundColor = ConsoleColor.Red;
            hero = new Hero(map.HeroStartPointLeft, map.HeroStartPointTop);
            hero.PrintHeroOnMap();
        }

        public void OnLeft()
            => MoveHero(-1, 0);

        public void OnRight()
            => MoveHero(1, 0);

        public void OnTop()
            => MoveHero(0, -1);

        public void OnDown()
            => MoveHero(0, 1);

        private void MoveHero(int deltaLeft, int deltaTop)
        {
            if (!IsCorrectPosition(hero.LeftPosition + deltaLeft, hero.TopPosition + deltaTop))
            {
                hero.PrintHeroOnMap();
                return;
            }
            hero.ChangeHeroCoordinates(deltaLeft, deltaTop);
            hero.PrintHeroOnMap();
        }

        private bool IsCorrectPosition(int left, int top)
        {
            if (top < 0 || left < 0)
            {
                return false;
            }
            if (top >= map.IsBorder.GetLength(0) || left >= map.IsBorder.GetLength(1))
            {
                return false;
            }
            return !map.IsBorder[top, left];
        }
    }
}
