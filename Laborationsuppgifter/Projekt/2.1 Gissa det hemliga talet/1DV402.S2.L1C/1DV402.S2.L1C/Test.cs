using System;
using System.Reflection;
using System.IO;
using System.Threading;

namespace _1DV402.S2.L1C
{
    internal static class Test
    {
        private static bool _testGreen = true;

        public static void Run()
        {
            try
            {
                CheckConstant();
            }
            catch (Exception ex)
            {
                _testGreen = false;
                ReportError("MaxNumberOfGuesses: " + ex.Message);
            }

            try
            {
                CheckConstructor();
            }
            catch (Exception ex)
            {
                _testGreen = false;
                ReportError("SecretNumber(): " + ex.Message);
            }

            try
            {
                CheckInitialize();
            }
            catch (Exception ex)
            {
                _testGreen = false;
                ReportError("Initialize(): " + ex.Message);
            }

            try
            {
                CheckMakeGuessLow();
            }
            catch (Exception ex)
            {
                _testGreen = false;
                ReportError("MakeGuess(): " + ex.Message);
            }

            try
            {
                CheckMakeGuessHigh();
            }
            catch (Exception ex)
            {
                _testGreen = false;
                ReportError("MakeGuess(): " + ex.Message);
            }

            try
            {
                CheckMakeGuessRight();
            }
            catch (Exception ex)
            {
                _testGreen = false;
                ReportError("MakeGuess(): " + ex.Message);
            }

            try
            {
                CheckMakeGuessOldGuess();
            }
            catch (Exception ex)
            {
                _testGreen = false;
                ReportError("MakeGuess(): " + ex.Message);
            }

            try
            {
                CheckMakeGuessNoMoreGuesses();
            }
            catch (Exception ex)
            {
                _testGreen = false;
                ReportError("MakeGuess(): " + ex.Message);
            }

            try
            {
                CheckMakeGuessArgumentOfRangeExcceptionIfGuessLowerThan1();
            }
            catch (Exception ex)
            {
                _testGreen = false;
                ReportError("MakeGuess(): " + ex.Message);
            }

            try
            {
                CheckMakeGuessArgumentOfRangeExcceptionIfGuessGreaterThan100();
            }
            catch (Exception ex)
            {
                _testGreen = false;
                ReportError("MakeGuess(): " + ex.Message);
            }

            try
            {
                CheckCanMakeGuess();
            }
            catch (Exception ex)
            {
                _testGreen = false;
                ReportError("CanMakeGuess: " + ex.Message);
            }

            try
            {
                CheckCount();
            }
            catch (Exception ex)
            {
                _testGreen = false;
                ReportError("Count: " + ex.Message);
            }

            try
            {
                CheckGuess();
            }
            catch (Exception ex)
            {
                _testGreen = false;
                ReportError("Count: " + ex.Message);
            }

            try
            {
                CheckGuessedNumberProperty();
            }
            catch (Exception ex)
            {
                _testGreen = false;
                ReportError("Count: " + ex.Message);
            }

            try
            {
                CheckNumberProperty();
            }
            catch (Exception ex)
            {
                _testGreen = false;
                ReportError("Count: " + ex.Message);
            }

            if (!_testGreen)
            {
                Environment.Exit(1);
            }
        }


        #region Test methods

        private static void CheckConstant()
        {
#pragma warning disable 0162
            if (SecretNumber.MaxNumberOfGuesses != 7)
            {
                ReportError("MaxNUmberOfGuesses: Konstanten MaxNUmberOfGuesses är inte tilldelad värdet 7.");
            }
#pragma warning restore 0162
        }

        private static void CheckConstructor()
        {
            var sn = new SecretNumber();
            var number = (int)GetFieldValue(sn, "_number");
            if (number < 1 || number > 100)
            {
                ReportError("SecretNumber(): _number är inte ett tal i det slutna intervallet mellan 1 och 100.");
            }

            var guessedNumbers = GetFieldValue(sn, "_guessedNumbers") as GuessedNumber[];
            if (guessedNumbers == null)
            {
                ReportError("SecretNumber(): _guessedNumbers har inte initierats.");
            }

            if (guessedNumbers != null && guessedNumbers.Length != 7)
            {
                ReportError("SecretNumber(): _guessedNumbers har inte sju element.");
            }
        }

        private static void CheckInitialize()
        {
            var sn = new SecretNumber();
            var guessedNumbers = GetFieldValue(sn, "_guessedNumbers") as GuessedNumber[];
            int number;
            do
            {
                sn.Initialize();
                number = (int)GetFieldValue(sn, "_number");
                if (number < 1 || number > 100)
                {
                    ReportError("Initialize(): _number är inte ett tal i det slutna intervallet mellan 1 och 100.");
                }
            } while (number >= 94);

            if (guessedNumbers != null && guessedNumbers != GetFieldValue(sn, "_guessedNumbers") as GuessedNumber[])
            {
                ReportError("Initialize(): _guessedNumber återanvänds inte utan tilldelas en referens till en helt ny array.");
            }

            if (sn.Count != 0)
            {
                ReportError("Initialize(): Count initieras inte till 0.");
            }
            if (!sn.CanMakeGuess)
            {
                ReportError("Initialize(): CanMakeGuess är false trots att det ska gå att gissa.");
            }
            else
            {
                for (int i = 94; i <= 100; i++)
                {
                    sn.MakeGuess(i);
                }
                sn.Initialize();

                if (sn.Count != 0)
                {
                    ReportError("Initialize(): Count initieras inte till 0.");
                }
                if (!sn.CanMakeGuess)
                {
                    ReportError("Initialize(): CanMakeGuess är false trots att det ska gå att gissa.");
                }

                guessedNumbers = (GuessedNumber[])GetFieldValue(sn, "_guessedNumbers");
                foreach (var gn in guessedNumbers)
                {
                    if (gn.Number != null && gn.Outcome != Outcome.Indefinite)
                    {
                        ReportError("Initialize(): _guessedNumbers töms inte på gamla gissningar.");
                        break;
                    }
                }
            }
        }

        private static void CheckMakeGuessLow()
        {
            var sn = new SecretNumber();
            int number, prevNumber, loopCount = 5;
            do
            {
                prevNumber = (int)GetFieldValue(sn, "_number");
                Thread.Sleep(100);
                sn.Initialize();
                number = (int)GetFieldValue(sn, "_number");
                if (number < 1 || number > 100)
                {
                    ReportError("Initialize(): _number är inte ett tal i det slutna intervallet mellan 1 och 100.");
                }
                if (prevNumber == number)
                {
                    if (--loopCount == 0)
                    {
                        ReportError("Initialize(): _number verkar inte slumpas");
                        return;
                    }
                }
            } while (number < 2);

            if (sn.MakeGuess(1) != Outcome.Low)
            {
                ReportError("MakeGuess(): MakeGuess returnerar inte Outcome.Low då det gissade talet är mindre än det hemliga talet.");
            }
            if (sn.Outcome != Outcome.Low)
            {
                ReportError("Outcome: Egenskapen Outcome är inte Outcome.Low efter en gissning på ett för litet tal gjorts.");
            }
        }

        private static void CheckMakeGuessHigh()
        {
            var sn = new SecretNumber();
            int number, prevNumber, loopCount = 5;
            do
            {
                prevNumber = (int)GetFieldValue(sn, "_number");
                Thread.Sleep(100);
                sn.Initialize();
                number = (int)GetFieldValue(sn, "_number");
                if (number < 1 || number > 100)
                {
                    ReportError("Initialize(): _number är inte ett tal i det slutna intervallet mellan 1 och 100.");
                }
                if (prevNumber == number)
                {
                    if (--loopCount == 0)
                    {
                        ReportError("Initialize(): _number verkar inte slumpas");
                        return;
                    }
                }
            } while (number > 99);

            if (sn.MakeGuess(100) != Outcome.High)
            {
                ReportError("MakeGuess(): MakeGuess returnerar inte Outcome.High då det gissade talet är större än det hemliga talet.");
            }
            if (sn.Outcome != Outcome.High)
            {
                ReportError("Outcome: Egenskapen Outcome är inte Outcome.High efter en gissning på ett för stort tal gjorts.");
            }
        }

        private static void CheckMakeGuessRight()
        {
            var sn = new SecretNumber();
            if (sn.MakeGuess((int)GetFieldValue(sn, "_number")) != Outcome.Right)
            {
                ReportError("MakeGuess(): MakeGuess returnerar inte Outcome.Right då det gissade talet är lika med det hemliga talet.");
            }
            if (sn.Outcome != Outcome.Right)
            {
                ReportError("Outcome: Egenskapen Outcome är inte Outcome.Right efter en gissning på rätt tal gjorts.");
            }
        }

        private static void CheckMakeGuessOldGuess()
        {
            var sn = new SecretNumber();
            int number;
            do
            {
                sn.Initialize();
                number = (int)GetFieldValue(sn, "_number");
                if (number < 1 || number > 100)
                {
                    ReportError("Initialize(): _number är inte ett tal i det slutna intervallet mellan 1 och 100.");
                }
            } while (number > 99);
            sn.MakeGuess(100);
            if (sn.MakeGuess(100) != Outcome.OldGuess)
            {
                ReportError("MakeGuess returnerar inte Outcome.OldGuess då det gissade talet är samma som en tidigare gissning.");
            }
            if (sn.Outcome != Outcome.OldGuess)
            {
                ReportError("Outcome: Egenskapen Outcome är inte Outcome.OldGuess då det gissade talet är samma som en tidigare gissning.");
            }
        }

        private static void CheckMakeGuessNoMoreGuesses()
        {
            var sn = new SecretNumber();
            var number = (int)GetFieldValue(sn, "_number");
            while (number >= 94)
            {
                sn.Initialize();
                number = (int)GetFieldValue(sn, "_number");
            }
            for (int i = 94; i <= 100; i++)
            {
                sn.MakeGuess(i);
            }
            if (sn.MakeGuess(number) != Outcome.NoMoreGuesses)
            {
                ReportError("MakeGuess returnerar inte Outcome.NoMoreGuesses då fler gissningar än sju görs.");
            }
            if (sn.Outcome != Outcome.NoMoreGuesses)
            {
                ReportError("Outcome: Egenskapen Outcome är inte Outcome.NoMoreGuesses då fler gissningar än sju gjorts.");
            }
        }

        private static void CheckMakeGuessArgumentOfRangeExcceptionIfGuessLowerThan1()
        {
            var sn = new SecretNumber();
            try
            {
                sn.MakeGuess(0);
                ReportError("MakeGuess(): ArgumentOutOfRangeException kastas inte vid gissning på ett tal mindre än 1.");
            }
            catch (ArgumentOutOfRangeException)
            {
                // Eat!
            }
        }

        private static void CheckMakeGuessArgumentOfRangeExcceptionIfGuessGreaterThan100()
        {
            var sn = new SecretNumber();
            try
            {
                sn.MakeGuess(101);
            }
            catch (ArgumentOutOfRangeException)
            {
                // Eat!
                return;
            }
            ReportError("MakeGuess(): ArgumentOutOfRangeException kastas inte vid gissning på ett tal större än 100.");
        }

        private static void CheckCanMakeGuess()
        {
            var sn = new SecretNumber();
            int number;
            do
            {
                sn.Initialize();
                number = (int)GetFieldValue(sn, "_number");
            } while (number >= 94);

            bool result = false;
            for (int i = 94; i <= 100; i++)
            {
                if (!(result = sn.CanMakeGuess))
                {
                    break;
                }
                sn.MakeGuess(i);
            }

            if (!result)
            {
                ReportError("CanMakeGuess: CanMakeGuess är false fast en gissning ska kunna göras.");
            }
            if (sn.CanMakeGuess)
            {
                ReportError("CanMakeGuess: CanMakeGuess är true fast en gissning inte ska kunna göras.");
            }

            sn.Initialize();
            sn.MakeGuess((int)GetFieldValue(sn, "_number"));
            if (sn.CanMakeGuess)
            {
                ReportError("CanMakeGuess: CanMakeGuess är true trots att rätt tal redan gissats.");
            }
        }

        private static void CheckCount()
        {
            var sn = new SecretNumber();
            var number = (int)GetFieldValue(sn, "_number");
            while (number >= 94)
            {
                sn.Initialize();
                number = (int)GetFieldValue(sn, "_number");
            }

            if (sn.Count != 0)
            {
                ReportError("Count: Count är inte 0 trots att ingen gissning gjorts.");
            }

            int count = 0;
            for (int i = 94; i <= 100; i++)
            {
                sn.MakeGuess(i);
                if (sn.Count != ++count)
                {
                    ReportError(String.Format("Count: Count är inte {0} trots att {0} gissning(ar) gjorts.", count));
                }
            }

            try
            {
                sn.MakeGuess(number);
            }
            catch
            {
                // Eat!
            }

            if (sn.Count != 7)
            {
                ReportError("Count: Count slutar inte att räknas upp efter att sju gissningar gjorts och ytterligare gissningar görs.");
            }
        }

        private static void CheckGuess()
        {
            var sn = new SecretNumber();
            var number = (int)GetFieldValue(sn, "_number");
            while (number >= 100 || number <= 1)
            {
                sn.Initialize();
                number = (int)GetFieldValue(sn, "_number");
            }
            if (sn.Guess != null)
            {

                ReportError("Egenskapen Guess är inte null trots att ingen gissning gjorts.");
            }
            sn.MakeGuess(number - 1);
            if (sn.Guess != number - 1)
            {
                ReportError("Egenskapen Guess har inte värdet av den senaste gissningen då en gissning på ett för lågt tal gjorts.");
            }
            sn.MakeGuess(number + 1);
            if (sn.Guess != number + 1)
            {
                ReportError("Egenskapen Guess har inte värdet av den senaste gissningen då en gissning på ett för högt tal gjorts.");
            }
            sn.MakeGuess(number);
            if (sn.Guess != number)
            {
                ReportError("Egenskapen Guess har inte värdet av den senaste gissningen då en gissning på rätt tal gjorts.");
            }
        }

        private static void CheckGuessedNumberProperty()
        {
            var sn = new SecretNumber();
            var guessedNumbersField = (GuessedNumber[])GetFieldValue(sn, "_guessedNumbers");
            if (guessedNumbersField == sn.GuessedNumbers)
            {
                ReportError("Privacy leak!!! En kopia av den privata arrayen returneras inte av egenskapen GuessedNumbers.");
            }
        }

        public static void CheckNumberProperty()
        {
            var sn = new SecretNumber();
            if (sn.Number != null)
            {
                ReportError("Egenskapen Number returnerar inte null trots att det finns gissningar kvar.");
            }
            var number = (int)GetFieldValue(sn, "_number");
            while (number >= 94)
            {
                sn.Initialize();
                number = (int)GetFieldValue(sn, "_number");
            }
            for (int i = 94; i <= 100; i++)
            {
                sn.MakeGuess(i);
            }
            if (sn.Number != number)
            {
                ReportError("Egenskapen Number har inte samma värde som fältet _number trots att det inte finns några gissningar kvar.");
            }
        }


        #endregion

        #region Helpers

        private static object GetFieldValue(object sn, string name)
        {
            var field = sn.GetType().GetField(name, BindingFlags.NonPublic | BindingFlags.Instance);
            if (field == null)
            {
                throw new ApplicationException(String.Format("FEL! Det privata fältet {0} saknas.", name));
            }
            return field.GetValue(sn);
        }

        private static void ReportError(string error)
        {
            _testGreen = false;
            Console.BackgroundColor = ConsoleColor.Red;
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine(error);
            Console.ResetColor();
        }

        #endregion
    }
}
