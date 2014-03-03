using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Gissatalet_Labb1.Model
{
    public enum Outcome { Indefinite, Low, High, Correct, NoMoreGuesses, PreviousGuess }
    public class SecretNumber
    {
        //fält
        private int _number;
        private List<int> _previousGuesses;
        private const int MaxNumberOfGuesses = 7;

        //egenskaper
        public bool CanMakeGuess
        {
            get
            {
                return Count < MaxNumberOfGuesses && !_previousGuesses.Contains(_number);
            }
        }

        public int Count
        {
            get
            {
                return _previousGuesses.Count();
            }
        }

        public int? Number
        {
            get
            {
                if (CanMakeGuess == true)
                {
                    return null;
                }
                else
                {
                    return _number;
                }
            }
        }

        public Outcome Outcome
        {
            get;
            private set;
        }

        public IEnumerable<int> PreviousGuesses
        {
            get
            {

                return _previousGuesses.AsReadOnly();
            }
        }

        //metoder
        public void Initialize()
        {
            Outcome = Outcome.Indefinite;
            _previousGuesses.Clear();
            System.Random random = new Random();
            _number = random.Next(1, 101);
        }

        public Outcome MakeGuess(int guess)
        {

            // I denna funktion ska du skriva koden för att hantera "spelet"



            /* Skapar en funktion där man gissar efter det hemliga talet.
            Om talet är mindre än 1 och större än 100 så är det utanför intervallet*/

            if (CanMakeGuess)
            {
                if (_number < 1 || _number > 100)
                {
                    throw new ArgumentOutOfRangeException();
                }
                /* Jämför om numret du matar in är större än det hemliga talet så
                får du ett svar att det är lägre*/

                else if (PreviousGuesses.Contains(guess))
                {
                    Outcome = Model.Outcome.PreviousGuess;
                }
                else
                {
                    _previousGuesses.Add(guess);

                    if (guess > _number)
                    {
                        Outcome = Model.Outcome.High;
                    }

                     /* Tvärtom om man kollar på föregående jämförelse*/
                    else if (guess < _number)
                    {
                        Outcome = Model.Outcome.Low;
                    }
                    /* slutligen om det inmatade värdet är lika det hemliga så returneras true,
                    samt ett meddelande */
                    else
                    {
                        Outcome = Model.Outcome.Correct;
                    }
                }
            }
            else
            {
                Outcome = Model.Outcome.NoMoreGuesses;
            }
            return Outcome;
        }

        public SecretNumber()
        {
            _previousGuesses = new List<int>(MaxNumberOfGuesses);
            Initialize();
        }



    }
}