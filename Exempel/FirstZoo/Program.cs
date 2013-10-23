
namespace FirstZoo
{
    class Program
    {
        static void Main(string[] args)
        {
            Dog dog = new Dog();
            //dog.Roam();
            //dog.Sleep();
            //dog.MakeNoise();

            Cat cat = new Cat();
            //cat.Roam();
            //cat.Sleep();
            //cat.MakeNoise();

            Hippo hippo = new Hippo();
            //hippo.Roam();
            //hippo.Sleep();
            //hippo.MakeNoise();

            DoAction(dog);
            DoAction(cat);
            DoAction(hippo);
        }

        // Tre överlagrade metoder kan ersättas med en
        // metod som har en referens till ett djur av typen Animal.

        //private static void DoAction(Cat cat)
        //{
        //    cat.Roam();
        //    cat.Sleep();
        //    cat.MakeNoise();
        //}

        //private static void DoAction(Dog dog)
        //{
        //    dog.Roam();
        //    dog.Sleep();
        //    dog.MakeNoise();
        //}

        //private static void DoAction(Hippo hippo)
        //{
        //    hippo.Roam();
        //    hippo.Sleep();
        //    hippo.MakeNoise();
        //}

        private static void DoAction(Animal animal)
        {
            animal.Roam();
            animal.Sleep();
            animal.MakeNoise();
        }
    }
}
