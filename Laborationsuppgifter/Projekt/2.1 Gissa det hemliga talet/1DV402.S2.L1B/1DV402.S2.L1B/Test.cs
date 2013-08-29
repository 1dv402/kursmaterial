using System;
using System.Reflection;
using System.IO;
using System.Threading;

namespace _1DV402.S2.L1B
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
                CheckMakeGuessIfItsPossibleToGuessMoreThanSevenTimes();
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
                CheckGuessesLeft();
            }
            catch (Exception ex)
            {
                _testGreen = false;
                ReportError("GuessesLeft: " + ex.Message);
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

            var guessedNumbers = GetFieldValue(sn, "_guessedNumbers") as int[];
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
            var guessedNumbers = GetFieldValue(sn, "_guessedNumbers") as int[];
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

            if (guessedNumbers != null && guessedNumbers != GetFieldValue(sn, "_guessedNumbers") as int[])
            {
                ReportError("Initialize(): _guessedNumber återanvänds inte utan tilldelas en referens till en helt ny array.");
            }

            if (sn.Count != 0)
            {
                ReportError("Initialize(): Count initieras inte till 0.");
            }
            if (!sn.CanMakeGuess)
            {
                ReportError("Initialize(): CanMakeGuess tilldelas inte värdet true.");
            }
            else
            {
                using (new NullOut())
                {
                    for (int i = 94; i <= 100; i++)
                    {
                        sn.MakeGuess(i);
                    }
                }
                sn.Initialize();

                if (sn.Count != 0)
                {
                    ReportError("Initialize(): Count initieras inte till 0.");
                }
                if (!sn.CanMakeGuess)
                {
                    ReportError("Initialize(): CanMakeGuess tilldelas inte värdet true.");
                }

                guessedNumbers = (int[])GetFieldValue(sn, "_guessedNumbers");
                foreach (var gn in guessedNumbers)
                {
                    if (gn != 0)
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

            bool result;
            using (new NullOut())
            {
                result = sn.MakeGuess(1);
            }
            if (result)
            {
                ReportError("MakeGuess(): MakeGuess returnerar inte false då det gissade talet är mindre än det hemliga talet.");
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

            bool result;
            using (new NullOut())
            {
                result = sn.MakeGuess(100);
            }
            if (result)
            {
                ReportError("MakeGuess(): MakeGuess returnerar inte false då det gissade talet är större än det hemliga talet.");
            }
        }

        private static void CheckMakeGuessRight()
        {
            var sn = new SecretNumber();
            bool result;
            using (new NullOut())
            {
                result = sn.MakeGuess((int)GetFieldValue(sn, "_number"));
            }
            if (!result)
            {
                ReportError("MakeGuess(): MakeGuess returnerar inte true då det gissade talet är lika med det hemliga talet.");
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
            } while (number > 50);
            using (new NullOut())
            {
                sn.MakeGuess(51);
            }
            var count = sn.Count;
            using (new NullOut())
            {
                sn.MakeGuess(51);
            }
            if (count != sn.Count)
            {
                ReportError("MakeGuess(): En gissning på ett tal samma som en tidigare gissnings tal räknas felaktigt som en ny gissning.");
            }
        }

        private static void CheckMakeGuessArgumentOfRangeExcceptionIfGuessLowerThan1()
        {
            var sn = new SecretNumber();
            try
            {
                using (new NullOut())
                {
                    sn.MakeGuess(0);
                }
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
                using (new NullOut())
                {
                    sn.MakeGuess(101);
                }
            }
            catch (ArgumentOutOfRangeException)
            {
                // Eat!
                return;
            }
            ReportError("MakeGuess(): ArgumentOutOfRangeException kastas inte vid gissning på ett tal större än 100.");
        }

        private static void CheckMakeGuessIfItsPossibleToGuessMoreThanSevenTimes()
        {
            var sn = new SecretNumber();
            int number;
            do
            {
                sn.Initialize();
                number = (int)GetFieldValue(sn, "_number");
            } while (number >= 94);

            using (new NullOut())
            {
                for (int i = 94; i <= 100; i++)
                {
                    sn.MakeGuess(i);
                }
            }

            try
            {
                using (new NullOut())
                {
                    sn.MakeGuess(number);
                }
            }
            catch (ApplicationException)
            {
                // Eat!
                return;
            }
            catch
            {
                // Eat!
            }
            ReportError("MakeGuess(): ApplicationsException kastas inte då fler gissningar än sju görs.");
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
            using (new NullOut())
            {
                for (int i = 94; i <= 100; i++)
                {
                    if (!(result = sn.CanMakeGuess))
                    {
                        break;
                    }
                    sn.MakeGuess(i);
                }
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
            using (new NullOut())
            {
                sn.MakeGuess((int)GetFieldValue(sn, "_number"));
            }
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
                using (new NullOut())
                {
                    sn.MakeGuess(i);
                }
                if (sn.Count != ++count)
                {
                    ReportError(String.Format("Count: Count är inte {0} trots att {0} gissning(ar) gjorts.", count));
                }
            }

            try
            {
                using (new NullOut())
                {
                    sn.MakeGuess(number);
                }
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

        private static void CheckGuessesLeft()
        {
            var sn = new SecretNumber();
            var number = (int)GetFieldValue(sn, "_number");
            while (number >= 94)
            {
                sn.Initialize();
                number = (int)GetFieldValue(sn, "_number");
            }

            if (sn.GuessesLeft != 7)
            {
                ReportError("Count: GuessesLeft är inte 7 trots att ingen gissning gjorts.");
            }

            int count = 0;
            for (int i = 94; i <= 100; i++)
            {
                using (new NullOut())
                {
                    sn.MakeGuess(i);
                }
                if (sn.Count != ++count)
                {
                    ReportError(String.Format("GuessesLeft: GuessesLeft är inte {0} trots att {1} gissning(ar) gjorts.", 7 - count, count));
                }
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

    internal class NullOut : IDisposable
    {
        private bool _disposed = false;
        private TextWriter _newOut;
        private TextWriter _oldOut;
        private MemoryStream _stream;

        public NullOut()
        {
            this._oldOut = Console.Out;
            this._stream = new MemoryStream(0);
            this._newOut = new StreamWriter(this._stream);
            Console.SetOut(this._newOut);
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!this._disposed)
            {
                if (disposing)
                {
                    Console.SetOut(this._oldOut);
                    this._newOut.Dispose();
                    this._stream.Dispose();
                }
                this._disposed = true;
            }
        }

        ~NullOut()
        {
            Dispose(false);
        }
    }
}
