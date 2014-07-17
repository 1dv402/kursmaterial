using System;
using System.Diagnostics;

namespace SecondZoo
{
    /// <summary>
    /// Uppräkningsbar typ med värden beskrivande typer av objekt som kan föra oljud.
    /// </summary>
    enum NoiseObjectType { Indefinite, Cat, Dog, Car };

    /// <summary>
    /// Representrerar programmet som visar en meny med olika alternativ 
    /// till ljud användaren kan välja och få uppspelade.
    /// </summary>
    class Program
    {
        /// <summary>
        /// Programmets startpunkt.
        /// </summary>
        static void Main()
        {
            bool exit = false;
            NoiseObjectType type = NoiseObjectType.Indefinite;

            do
            {
                switch (GetMenuChoice())
                {
                    case 0:
                        exit = true;
                        continue;

                    case 1:
                        type = NoiseObjectType.Cat;
                        break;

                    case 2:
                        type = NoiseObjectType.Dog;
                        break;

                    case 3:
                        type = NoiseObjectType.Car;
                        break;

                    case 4:
                        Console.Clear();
                        Test test = new Test();
                        test.Run();
                        continue;

#if DEBUG
                    default:
                        Debug.Assert(false, "Hantering av menyalternativet saknas.");
                        continue;
#endif
                }

                Console.Clear();
                INoise noise = CreateNoiseObject(type);
                noise.MakeNoise();
                ContinueOnKeyPressed();
            } while (!exit);
        }

        /// <summary>
        /// Meddelar användaren att trycka på vilken tangent som helst
        /// för att forsätta exekveringen av programmet.
        /// </summary>
        private static void ContinueOnKeyPressed()
        {
            Console.ForegroundColor = ConsoleColor.White;
            Console.BackgroundColor = ConsoleColor.DarkBlue;
            Console.Write("\n   Tryck tangent för att fortsätta   ");
            Console.ResetColor();
            Console.CursorVisible = false;
            Console.ReadKey(true);
            Console.Clear();
            Console.CursorVisible = true;
        }

        /// <summary>
        /// Skapar ett objekt som implementerar interfacet INoise och som
        /// därmed kan för lite oljud.
        /// </summary>
        /// <param name="type">Värdet som bestämmer vilken type av objekt som ska skapas.</param>
        /// <returns>En referens till det nyligen skapade objektet.</returns>
        private static INoise CreateNoiseObject(NoiseObjectType type)
        {
            switch (type)
            {
                case NoiseObjectType.Car:
                    return new Car();

                case NoiseObjectType.Cat:
                    return new Cat();

                case NoiseObjectType.Dog:
                    return new Dog();

                default:
                    throw new NotImplementedException();
            }
        }

        /// <summary>
        /// Presneterar en meny och väntar på att användaren ska välja ett tal mellan 0 och 4.
        /// </summary>
        /// <returns>Ett värde som ger vilket alternativ som valts.</returns>
        private static int GetMenuChoice()
        {
            int index;

            do
            {
                Console.Clear();
                Console.BackgroundColor = ConsoleColor.DarkCyan;
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine(" ╔═══════════════════════════════════╗ ");
                Console.WriteLine(" ║          Objekt med ljud          ║ ");
                Console.WriteLine(" ╚═══════════════════════════════════╝ ");
                Console.BackgroundColor = ConsoleColor.Black;
                Console.WriteLine("\n - Arkiv -----------------------------------\n");
                Console.WriteLine(" 0. Avsluta.");
                Console.WriteLine("\n - Ljudliga objekt -------------------------\n");
                Console.WriteLine(" 1. Katt.");
                Console.WriteLine(" 2. Hund.");
                Console.WriteLine(" 3. Bil.");
                Console.WriteLine("\n - Test ------------------------------------\n");
                Console.WriteLine(" 4. Kör test.");
                Console.WriteLine("\n ═══════════════════════════════════════════\n");
                Console.Write(" Ange menyval [0-4]: ");
                Console.ResetColor();

                // Läser in en sträng som försöker tolkas till ett heltal; validerar sedan att
                // det inmatade heltalet är i det slutna intervallet mellan 0 och 4.
                if (int.TryParse(Console.ReadLine(), out index) && index >= 0 && index <= 4)
                {
                    return index;
                }

                Console.BackgroundColor = ConsoleColor.Red;
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine("\n FEL! Ange ett nummer mellan 0 och 4.\n");
                ContinueOnKeyPressed();
            } while (true);
        }
    }
}
