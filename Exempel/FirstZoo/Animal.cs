using System;

namespace FirstZoo
{
    // Basklassen för alla djur. Klassen ärver faktiskt från Object även om det inte 
    // uttryckligen står att den gör det ( : Object saknas efter Animal).
    //public class Animal
    public abstract class Animal
    {
        // Publik egenskap som det inte finns någon anledning till att överskugga
        // varför egenskapen inte är virtuell.
        public uint Age { get; set; }

        // Virtuell metod som klasser som ärver från Animal kan välja
        // att överskugga (override) för att skapa sin egen version av.
        //public virtual void MakeNoise()
        //{
        //    Console.WriteLine("Hur ska jag låta?");
        //}
        public abstract void MakeNoise();

        // Virtuell metod som klasser som ärver från Animal kan välja
        // att överskugga (override) för att skapa sin egen version av.
        //public virtual void Roam()
        //{
        //    Console.WriteLine("Hur ska jag ströva omkring?");
        //}
        public abstract void Roam();

        // Virtuell metod som klasser som ärver från Animal kan välja
        // att överskugga (override) för att skapa sin egen version av.
        public virtual void Sleep()
        {
            Console.WriteLine("Zzzzzzzz");
        }
    }
}
