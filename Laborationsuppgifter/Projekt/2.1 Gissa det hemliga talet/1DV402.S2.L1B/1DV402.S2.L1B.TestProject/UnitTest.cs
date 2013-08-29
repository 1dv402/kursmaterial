using System;
using System.IO;
using System.Reflection;
using System.Threading;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using _1DV402.S2.L1B;

namespace _1DV402.S2.L1B.TestProject
{
    /// <summary>
    /// Summary description for UnitTest
    /// </summary>
    [TestClass]
    public class UnitTest
    {
        [TestMethod]
        public void CheckConstant()
        {
            Assert.IsTrue(SecretNumber.MaxNumberOfGuesses == 7, "Konstanten MaxNUmberOfGuesses är inte tilldelad värdet 7.");
        }

        [TestMethod]
        public void CheckConstructor()
        {
            var sn = new SecretNumber();
            var number = (int)GetFieldValue(sn, "_number");
            Assert.IsTrue(number >= 1 && number <= 100, "_number är inte ett tal i det slutna intervallet mellan 1 och 100.");

            var guessedNumbers = (int[])GetFieldValue(sn, "_guessedNumbers");
            Assert.IsNotNull(guessedNumbers, "_guessedNumbers har inte initierats.");
            Assert.IsTrue(guessedNumbers.Length == 7, "_guessedNumbers har inte sju element.");
        }

        [TestMethod]
        public void CheckInitialize()
        {
            var sn = new SecretNumber();
            int number;
            do
            {
                sn.Initialize();
                number = (int)GetFieldValue(sn, "_number");
                Assert.IsTrue(number >= 1 && number <= 100, "_number är inte ett tal i det slutna intervallet mellan 1 och 100.");
            } while (number >= 94);

            for (int i = 94; i <= 100; i++)
            {
                CallMakeGuess(sn, i);
            }
            sn.Initialize();

            Assert.IsTrue(sn.Count == 0, "Count initieras inte till 0.");
            Assert.IsTrue(sn.CanMakeGuess, "CanMakeGuess initieras inte till true.");

            var guessedNumbers = (int[])GetFieldValue(sn, "_guessedNumbers");
            foreach (var guess in guessedNumbers)
            {
                Assert.IsTrue(guess == 0, "_guessedNumbers verkar inte tömmas på gammal information.");
            }
        }

        [TestMethod]
        public void CheckMakeGuessLow()
        {
            var sn = new SecretNumber();
            int number, prevNumber, loopCount = 5;
            do
            {
                prevNumber = (int)GetFieldValue(sn, "_number");
                Thread.Sleep(100);
                sn.Initialize();
                number = (int)GetFieldValue(sn, "_number");
                Assert.IsTrue(number >= 1 && number <= 100, "Initialize(): _number är inte ett tal i det slutna intervallet mellan 1 och 100.");
                if (--loopCount == 0)
                {
                    Assert.IsTrue(prevNumber != number, "Initialize(): _number verkar inte slumpas.");
                    return;
                }
            } while (number < 2);
            Assert.IsFalse(CallMakeGuess(sn, 1), "MakeGuess returnerar inte false då det gissade talet är mindre än det hemliga talet.");
        }

        [TestMethod]
        public void CheckMakeGuessHigh()
        {
            var sn = new SecretNumber();
            int number, prevNumber, loopCount = 5;
            do
            {
                prevNumber = (int)GetFieldValue(sn, "_number");
                Thread.Sleep(100);
                sn.Initialize();
                number = (int)GetFieldValue(sn, "_number");
                Assert.IsTrue(number >= 1 && number <= 100, "Initialize(): _number är inte ett tal i det slutna intervallet mellan 1 och 100.");
                if (--loopCount == 0)
                {
                    Assert.IsTrue(prevNumber != number, "Initialize(): _number verkar inte slumpas.");
                    return;
                }
            } while (number > 99);
            Assert.IsFalse(CallMakeGuess(sn, 100), "MakeGuess returnerar inte false då det gissade talet är högre än det hemliga talet.");
        }

        [TestMethod]
        public void CheckMakeGuessRight()
        {
            var sn = new SecretNumber();
            Assert.IsTrue(CallMakeGuess(sn, (int)GetFieldValue(sn, "_number")), "MakeGuess returnerar inte true då det gissade talet är samma som det hemliga talet.");
        }

        [TestMethod]
        public void CheckMakeGuessOldGuess()
        {
            var sn = new SecretNumber();
            var guess = Math.Max((int)GetFieldValue(sn, "_number") ^ 3, 1);
            CallMakeGuess(sn, guess);
            var count = sn.Count;
            Assert.IsFalse(CallMakeGuess(sn, guess), "MakeGuess returnerar inte false då det gissade talet är samma som en tidigare gissning.");
            Assert.IsTrue(count == sn.Count, "En gissning på ett tal samma som en tidigare gissnings tal räknas felaktigt som en ny gissning.");
        }

        [TestMethod]
        public void CheckCanMakeGuessProperty()
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
                Assert.IsTrue(sn.CanMakeGuess, "Egenskapen CanMakeGuess är inte true trots att alla gissningar inte gjorts.");
                CallMakeGuess(sn, i);
            }
            Assert.IsFalse(sn.CanMakeGuess, "Egenskapen CanMakeGuess är inte false trots att sju gissningar gjorts.");

            sn.Initialize();
            CallMakeGuess(sn, (int)GetFieldValue(sn, "_number"));
            Assert.IsFalse(sn.CanMakeGuess, "Egenskapen CanMakeGuess är inte false trots att en gissning på rätt tal gjorts.");
        }

        [TestMethod]
        public void CheckMakeGuessArgumentOfRangeExcceptionIfGuessLowerThan1()
        {
            var sn = new SecretNumber();
            try
            {
                using (new NullOut())
                {
                    sn.MakeGuess(0);
                    throw new ApplicationException();
                }
            }
            catch (ArgumentOutOfRangeException)
            {
                // Eat!
                return;
            }
            catch
            {
                Assert.Fail("ArgumentOutOfRangeException kastas inte vid gissning på ett tal mindre än 1.");
            }
        }

        [TestMethod]
        public void CheckMakeGuessArgumentOfRangeExcceptionIfGuessGreaterThan100()
        {
            var sn = new SecretNumber();
            try
            {
                using (new NullOut())
                {
                    sn.MakeGuess(101);
                    throw new ApplicationException();
                }
            }
            catch (ArgumentOutOfRangeException)
            {
                // Eat!
                return;
            }
            catch
            {
                Assert.Fail("ArgumentOutOfRangeException kastas inte vid gissning på ett tal större än 100.");
            }
        }

        [TestMethod]
        public void CheckCountProperty()
        {
            var sn = new SecretNumber();
            var number = (int)GetFieldValue(sn, "_number");
            while (number >= 94)
            {
                sn.Initialize();
                number = (int)GetFieldValue(sn, "_number");
            }

            Assert.IsTrue(sn.Count == 0, "Egenskapen Count är inte 0 trots att ingen gissning gjorts.");

            int count = 0;
            for (int i = 94; i <= 100; i++)
            {
                CallMakeGuess(sn, i);
                Assert.IsTrue(sn.Count == ++count, String.Format("Egenskapen Count är inte {0} trots att {0} gissning(ar) gjorts.", count));
            }

            try
            {
                CallMakeGuess(sn, number);
                Assert.IsTrue(sn.Count == 7, "Egenskapen Count slutar inte att räknas upp efter att sju gissningar gjorts och ytterligare gissningar görs.");
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
            Assert.Fail("ApplicationsException kastas inte då fler gissningar än sju görs.");
        }

        [TestMethod]
        public void CheckGuessesLeftProperty()
        {
            var sn = new SecretNumber();
            var number = (int)GetFieldValue(sn, "_number");
            while (number >= 94)
            {
                sn.Initialize();
                number = (int)GetFieldValue(sn, "_number");
            }

            Assert.IsTrue(sn.GuessesLeft == 7, "GuessesLeft är inte 7 trots att ingen gissning gjorts.");

            int count = 0;
            for (int i = 94; i <= 100; i++)
            {
                CallMakeGuess(sn, i);
                Assert.IsTrue(sn.Count == ++count, String.Format("GuessesLeft: GuessesLeft är inte {0} trots att {1} gissning(ar) gjorts.", 7 - count, count));
            }
        }

        private static bool CallMakeGuess(SecretNumber sn, int guess)
        {
            using (new NullOut())
            {
                return sn.MakeGuess(guess);
            }
        }

        private static object GetFieldValue(object o, string name)
        {
            var field = o.GetType().GetField(name, BindingFlags.NonPublic | BindingFlags.Instance);
            if (field == null)
            {
                throw new ApplicationException(String.Format("FEL! Det privata fältet {0} saknas.", name));
            }
            return field.GetValue(o);
        }
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
