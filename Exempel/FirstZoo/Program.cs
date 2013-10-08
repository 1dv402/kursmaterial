
namespace FirstZoo
{
    class Program
    {
        static void Main(string[] args)
        {
            Dog dog = new Dog();
            //dog.MakeNoise();

            Cat cat = new Cat();
            //cat.MakeNoise();

            //Hippo hippo = new Hippo();
            //hippo.MakeNoise();

            SaySomething(dog);
            SaySomething(cat);
            //SaySomething(hippo);
        }

        //private static void SaySomething(Cat cat)
        //{
        //    cat.MakeNoise();
        //}

        //private static void SaySomething(Dog dog)
        //{
        //    dog.MakeNoise();
        //}

        //private static void SaySomething(Hippo hippo)
        //{
        //    hippo.MakeNoise();
        //}

        private static void SaySomething(Animal animal)
        {
            animal.MakeNoise();
        }
    }
}
