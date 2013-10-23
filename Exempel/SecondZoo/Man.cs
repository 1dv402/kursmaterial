using System;
using System.Media;

namespace SecondZoo
{
    public class Man : INoise
    {
        public void MakeNoise()
        {
            SoundPlayer sp = new SoundPlayer(@"..\..\Sound\LongLaugh.wav");

            Console.Write("En man skrattar...");
            sp.PlaySync();
            Console.WriteLine("...för mycket");
        }
    }
}
