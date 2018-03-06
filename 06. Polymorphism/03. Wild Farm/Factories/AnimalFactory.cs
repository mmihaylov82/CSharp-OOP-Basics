using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public static class AnimalFactory
{
    public static Animal ProduceAnimal(string[] animalArgs)
    {
        string animalType = animalArgs[0];
        string name = animalArgs[1];
        double weight = double.Parse(animalArgs[2]);

        double wingSize;
        string livingRegion;
        string breed;

        switch (animalType)
        {
            case nameof(Owl):
                wingSize = double.Parse(animalArgs[3]);
                return new Owl(name, weight, wingSize);
            case nameof(Hen):
                wingSize = double.Parse(animalArgs[3]);
                return new Hen(name, weight, wingSize);
            case nameof(Mouse):
                livingRegion = animalArgs[3];
                return new Mouse(name, weight, livingRegion);
            case nameof(Dog):
                livingRegion = animalArgs[3];
                return new Dog(name, weight, livingRegion);
            case nameof(Cat):
                livingRegion = animalArgs[3];
                breed = animalArgs[4];
                return new Cat(name, weight, livingRegion, breed);
            case nameof(Tiger):
                livingRegion = animalArgs[3];
                breed = animalArgs[4];
                return new Tiger(name, weight, livingRegion, breed);
            default:
                throw new ArgumentException("Unknown animal!");
        }
    }
}

