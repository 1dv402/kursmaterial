
namespace FirstZoo
{
    // Ärver direkt från klassen Animal.
    class Hippo : Animal
    {
        // Överkuggar inga medlemmar i basklassen.
        public override void MakeNoise()
        {
            throw new System.NotImplementedException();
        }

        public override void Roam()
        {
            throw new System.NotImplementedException();
        }
    }
}
