using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CharlieDobson_FirstPlayable_Programming2
{
    internal class WeakEnemy : Enemy
    {
        public WeakEnemy(int _maxHealth, int _startingXPos, int _startingYPos) : base(_maxHealth, _startingXPos, _startingYPos)
        {
            _health = new Health(_maxHealth/2);
            _position = new Position(_startingXPos, _startingYPos);
        }

        public override string GetHUDString()
        {
            _hudString = $"~~~FASTENEMY~~~\n~~~HEALTH~~~\n   {_health.CurrentHealth}/{_health.MaxHealth}\n";

            return _hudString;

        }

        public override void DrawCharacter(int xMarg, int yMarg)
        {
            base.DrawCharacter(xMarg, yMarg);
            Console.BackgroundColor = ConsoleColor.DarkRed;
            Console.Write("0");
        }

        public override void Attack()
        {
            int _attackPower = GameManager.Instance._random.Next(1, 21);
            _attackPower /= 2;

            GameManager.Instance._gamePlayer._health.TakeDamage(_attackPower);
        }
        public override void Movement()
        {
            _xMovement = 0;
            _yMovement = 0;
            Random _random = new Random();
            int _movement = _random.Next(1, 5);

            if (_movement == 1)
            {
                _xMovement++;
            }
            else if (_movement == 2)
            {
                _xMovement--;
            }
            else if (_movement == 3)
            {
                _yMovement++;
            }
            else if (_movement == 4)
            {
                _yMovement--;
            }
            else
            {
                return;
            }

            base.Movement();
        }
    }
}
