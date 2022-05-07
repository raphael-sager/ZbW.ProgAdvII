// See https://aka.ms/new-console-template for more information


using Covariance;

FirstSample();
//WithStandardGenerics();
//WithHomemadeGeneric();
//WithArrays();



void FirstSample() {
    Console.WriteLine("Hello, World!");

    BagOfFruits fruits = new BagOfApples();
    fruits.Add(new Apple());
    fruits.Add(new Banana());

    Console.WriteLine(fruits.Get(0));
    Console.WriteLine(fruits.Get(1));
}


void WithStandardGenerics() {
    var bagOfApples = new List<Apple>() {
        new(), new()
    };

    IEnumerable<Fruit> bagOfFruit;

    bagOfFruit = bagOfApples;

    foreach (Fruit fruit in bagOfFruit)
        Console.WriteLine(fruit);

    bagOfApples.Add(new Apple());

    Console.WriteLine("---");

    foreach (Fruit fruit in bagOfFruit)
        Console.WriteLine(fruit);

    //bagOfApples.Add(new Banana());
    //bagOfFruit.Add(new Banana ());

    Console.WriteLine("---");

    foreach (Fruit fruit in bagOfFruit)
        Console.WriteLine(fruit);
}

void WithHomemadeGeneric() {
    var bagOfApples = new Bag<Apple>();

    bagOfApples.Add(new Apple());
    bagOfApples.Add(new Apple());
    bagOfApples.Add(new Apple());

    IBag<Fruit> bagOfFruit = bagOfApples;

    Console.WriteLine(bagOfFruit.Get(0));
    Console.WriteLine(bagOfFruit.Get(1));

    //bagOfApples.Add(new Banana());
    //bagOfFruit.Add(new Banana());
}

void WithArrays() {
    var arrayOfApples = new Apple[] {
        new Apple(),
        new Apple(),
        new Apple()
    };

    Fruit[] arrayOfFruit = arrayOfApples;

    foreach (Fruit fruit in arrayOfFruit)
        Console.WriteLine(fruit);

    arrayOfFruit[1] = new Banana();

    foreach (Apple apple in arrayOfApples)
        Console.WriteLine(apple);
}