
namespace SecondZoo
{
    public class Test
    {
        public void Run()
        {
            Dog myDog = new Dog();
            Cat myCat = new Cat();
            Man myMan = new Man();
            Car myCar = new Car();

            DoAction(myDog);
            DoAction(myCat);
            DoAction(myCar);
            DoAction(myMan);

            INoise[] myNoiseObjects = { new Dog(), new Cat(), new Car() };

            foreach (INoise item in myNoiseObjects)
            {
                item.MakeNoise();
            }
        }


        //private static void DoAction(Cat cat)
        //{
        //    cat.MakeNoise();
        //}

        //private static void DoAction(Dog dog)
        //{
        //    dog.MakeNoise();
        //}

        //private static void DoAction(Hippo hippo)
        //{
        //    hippo.MakeNoise();
        //}

        private void DoAction(Animal animal)
        {
            animal.Roam();
            animal.Sleep();
            animal.MakeNoise();
        }

        private void DoAction(INoise noise)
        {
            noise.MakeNoise();
        }

    }
}
