using System;

class App
{
    public static void Main(string[] args)
    {
        //UWAGA!!! Nie usuwaj poniższego wiersza!!!
        //Console.WriteLine("Otrzymałeś punktów: " + (Test.Exercises_1() + Test.Excersise_2() + Test.Excersise_3()));


        //Cw1
        var gt = new Guitar();
        Console.WriteLine(gt.Play());

        var drum = new Drum();
        Console.WriteLine(drum.Play());

        Console.WriteLine(new Musician<Keyboard>().ToString());
        //c2
        int[] arr = { 2, 3, 4, 6 };
        var tuple = Exercise2.GetTuple2<int>(arr);
        Console.WriteLine(tuple.Item1);
        Console.WriteLine(tuple.Item2);
    }
}

//Ćwiczenie 1
//Zmodyfikuj klasę Musician, aby można było tworzyć muzyków dla T  pochodnych po Instrument.
//Zdefiniuj klasę  Guitar pochodną po Instrument, w metodzie Play zwróć łańcuch "GUITAR";
//Zdefiniuj klasę Drum pochodną po Instrument, w metodzie Play zwróć łańcuch "DRUM";
interface IPlay
{
    string Play();
}

class Musician<T> : IPlay where T : Instrument, new()
{
    public T Instrument { get; init; }
    public Musician()

    {
        Instrument = new T();
    }
    public string Play()
    {
        return (Instrument as Instrument)?.Play();
    }

    public override string ToString()
    {
        return $"MUSICIAN with {(Instrument as Instrument)?.Play()}";
    }
}

abstract class Instrument : IPlay
{
    public abstract string Play();
}

class Keyboard : Instrument
{
    public override string Play()
    {
        return "KEYBOARD";
    }
}

class Guitar : Instrument
{
    public override string Play()
    {
        return "GUITAR";
    }
}

class Drum : Instrument
{
    public override string Play()
    {
        return "DRUM";
    }
}

//Cwiczenie 2
public class Exercise2
{
    //Zmień poniższą metodę, aby zwracała krotkę z polami typu string, int i bool oraz wartościami "Karol", 12 i true
    public static object getTuple1()
    {
        return ValueTuple.Create("Adam", 12, true);
    }

    //Zdefiniuj poniższą metodę, aby zwracała krotkę o dwóch polach
    //firstAndLast: z tablicą dwuelementową z pierwszym i ostatnim elementem tablicy input
    //isSame: z wartością logiczną określająca równość obu elementów
    //dla pustej tablicy należy zwrócić krotkę z pustą tablica i wartościa false
    //Przykład
    //dla wejścia
    //int[] arr = {2, 3, 4, 6}
    //metoda powinna zwrócić krotkę
    //var tuple = GetTuple2<int>(arr);
    //tuple.firstAndLast    ==> {2, 6}
    //tuple.isSame          ==> false
    public static ValueTuple<T[], bool> GetTuple2<T>(T[] input)
    {
        T[] firstAndLast = new T[2];
        firstAndLast[0] = input[0];
        firstAndLast[1] = input[^1];
        var isSame = firstAndLast[0].Equals(firstAndLast[1]);
        return (firstAndLast, isSame);
    }
}

//Cwiczenie 3
public class Exercise3
{
    //Zdefiniuj poniższa metodę, która zlicza liczbę wystąpień elementów tablicy arr
    //Przykład
    //dla danej tablicy
    //string[] arr = {"adam", "ola", "adam" ,"ewa" ,"karol", "ala" ,"adam", "ola"};
    //wywołanie metody
    //countElements(arr, "adam", "ewa", "ola");
    //powinno zwrócić tablicę krotek
    //{("adam", 3), ("ewa", 1), ("ola", 2)}
    //co oznacza, że "adam" występuje 3 raz, "ewa" 1 raz a "ola" 2
    //W obu tablicach moga pojawić się wartości null, które też muszą być zliczane
    public static (T, int)[] countElements<T>(T[] arr, params T[] elements)
    {
        var arraum = new (T, int)[elements.Length];
        for (int i = 0; i < arr.Length; i++)
        {

        }
    }
}