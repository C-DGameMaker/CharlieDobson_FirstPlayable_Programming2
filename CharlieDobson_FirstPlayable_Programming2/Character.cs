using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CharlieDobson_FirstPlayable_Programming2
{
    internal class Character
    {
        //pulling from both of these classes for health and position (DUH)
        public Health _health;
        public Position _position;
        public int _xMovement = 0;
        public int _yMovement = 0;

        public string _hudString;

        //Constructor constructor
        public Character(int maxHealth, int startingXPos, int startingYPos)
        {
            _health = new Health(maxHealth: maxHealth);
            _position = new Position(xPosition: startingXPos, yPosition: startingYPos);
        }

        //Basic hud before I changed it for Player
        public virtual string GetHUDString()
        {
            _hudString = $"~~~HEALTH~~~\n   {_health.CurrentHealth}/{_health.MaxHealth} \n\n~~~POSITION~~~\n   ({_position._xPos},{_position._yPos})";

            return _hudString;

        }

        //Lets the program move the characters
        public void ChangePosition(int newX, int newY)
        {
            _position._xPos += newX;
            _position._yPos += newY;
        }

        public virtual void Movement()
        {
            _position._xPos += _xMovement;
            _position._yPos += _yMovement;
        }



    }
}
