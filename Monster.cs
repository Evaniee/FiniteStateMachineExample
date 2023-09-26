using System;

namespace FiniteStateMachineExample
{
    /// <summary>
    /// Possible states for a monster
    /// </summary>
    enum MonsterState
    {
        Idle = 0,
        Attack = 1,
        Melee = 2,
        Dodge = 3,
        Search = 4,
        Die = 5
    }

    class Monster
    {
        /// <summary>
        /// Monster's current state
        /// </summary>
        public MonsterState? State
        {
            get { return _state; }
            private set { }                 // Only allow change via methods 
        }
        private MonsterState? _state;       // Monster's current state

        /// <summary>
        /// A finite state machine that represents a monster
        /// </summary>
        public Monster()
        {
            _state = MonsterState.Idle;
        }

        /// <summary>
        /// Decide the monster's next move
        /// </summary>
        public void Iterate()
        {
            Console.WriteLine("\nState: {0}", _state);
            switch (_state)
            {
                case MonsterState.Idle:
                    IdleOptions();
                    break;

                case MonsterState.Attack:
                    AttackOptions();
                    break;

                case MonsterState.Melee:
                    MeleeOptions();
                    break;

                case MonsterState.Dodge:
                    DodgeOptions();
                    break;

                case MonsterState.Search:
                    SearchOptions();
                    break;

                case MonsterState.Die:
                    DieOptions();
                    break;
            }
        }

        #region Options
        /// <summary>
        /// Options for a monster in Idle state
        /// </summary>
        private void IdleOptions()
        {
            // Prompt
            Console.WriteLine("What does the monster do?: ");
            Console.WriteLine("\tA: See enemy");
            Console.WriteLine("\tB: Get shot");
            Console.Write("Selected: ");

            // Loop until valid input
            while (true)
            {
                // Determine next state
                switch (Console.ReadKey(true).Key)
                {
                    case ConsoleKey.A:
                        Console.WriteLine("A\nThe monster sees the enemy.");
                        _state = MonsterState.Attack;
                        return;
                    case ConsoleKey.B:
                        Console.WriteLine("B\nThe monster gets shot.");
                        _state = MonsterState.Die;
                        return;
                }
            }
        }

        /// <summary>
        /// Options for a monster in Attack state
        /// </summary>
        private void AttackOptions()
        {
            // Prompt
            Console.WriteLine("What does the monster do?: ");
            Console.WriteLine("\tA: Lose sight");
            Console.WriteLine("\tB: Enemy fires");
            Console.WriteLine("\tC: Close range");
            Console.WriteLine("\tD: Get shot");
            Console.Write("Selected: ");

            // Loop until valid input
            while (true)
            {
                // Determine next state
                switch (Console.ReadKey(true).Key)
                {
                    case ConsoleKey.A:
                        Console.WriteLine("A\nThe monster loses sight of the enemy.");
                        _state = MonsterState.Search;
                        return;
                    case ConsoleKey.B:
                        Console.WriteLine("B\nThe monster dodges the enemy's shot.");
                        _state = MonsterState.Dodge;
                        return;
                    case ConsoleKey.C:
                        Console.WriteLine("C\nThe monster closes range.");
                        _state = MonsterState.Melee;
                        return;
                    case ConsoleKey.D:
                        Console.WriteLine("D\nThe monster gets shot.");
                        _state = MonsterState.Die;
                        return;
                }
            }
        }

        /// <summary>
        /// Options for a monster in Melee state
        /// </summary>
        private void MeleeOptions()
        {
            // Prompt
            Console.WriteLine("What does the monster do?: ");
            Console.WriteLine("\tA: Get shot");
            Console.Write("Selected: ");

            // Loop until valid input
            while (true)
            {
                // Determine next state
                switch (Console.ReadKey(true).Key)
                {
                    case ConsoleKey.A:
                        Console.WriteLine("A\nThe monster gets shot.");
                        _state = MonsterState.Die;
                        return;
                }
            }
        }

        /// <summary>
        /// Options for a monster in Dodge state
        /// </summary>
        private void DodgeOptions()
        {
            // Prompt
            Console.WriteLine("What does the monster do?: ");
            Console.WriteLine("\tA: Close Range");
            Console.Write("Selected: ");

            // Loop until valid input
            while (true)
            {
                // Determine next state
                switch (Console.ReadKey(true).Key)
                {
                    case ConsoleKey.A:
                        Console.WriteLine("A\nThe monster closes range.");
                        _state = MonsterState.Melee;
                        return;
                }
            }
        }

        /// <summary>
        /// Options for a monster in Search state
        /// </summary>
        private void SearchOptions()
        {
            // Prompt
            Console.WriteLine("What does the monster do?: ");
            Console.WriteLine("\tA: See enemy");
            Console.WriteLine("\tB: Time out");
            Console.Write("Selected: ");

            // Loop until valid input
            while (true)
            {
                // Determine next state
                switch (Console.ReadKey(true).Key)
                {
                    case ConsoleKey.A:
                        Console.WriteLine("A\nThe monster sees the enemy.");
                        _state = MonsterState.Attack;
                        return;
                    case ConsoleKey.B:
                        Console.WriteLine("B\nThe monster gives up searching.");
                        _state = MonsterState.Idle;
                        return;
                }
            }
        }

        /// <summary>
        /// Options for a monster in Die state
        /// </summary>
        private void DieOptions()
        {
            // Prompt
            Console.WriteLine("What does the monster do?: ");
            Console.WriteLine("\tA: Time out");
            Console.Write("Selected: ");

            // Loop until valid input
            while (true)
            {
                // Determine next state
                switch (Console.ReadKey(true).Key)
                {
                    case ConsoleKey.A:
                        Console.WriteLine("A\nThe monster is dead.");
                        _state = null;
                        return;
                }
            }
        }
        #endregion
    }
}