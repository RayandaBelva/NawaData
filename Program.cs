using System;
using System.Linq;

public class Program
{
    public static void Main()
    {
        while (true)
        {
            Thread.Sleep(3000);
            Console.WriteLine("Menu:");
            Console.WriteLine("1. Sort Character");
            Console.WriteLine("2. PSBB (Pembatasan Sosial Berskala Besar)");
            Console.WriteLine("0. Exit");

            Console.Write("Choose a problem : ");
            string choice = ReadNonNullInput();


            switch (choice)
            {
                case "1":
                    SolveProblem1();
                    break;
                case "2":
                    SolveProblem2();
                    break;
                case "0":
                    Console.WriteLine("Exiting program...");
                    return;
                default:
                    Console.WriteLine("Invalid choice. Please choose a number from the menu.");
                    break;
            }
        }
    }

    public static void SolveProblem1()
    {
        Console.Write("Input one line of words (S) : ");
        string input = ReadNonNullInput();

        string sortedVowels = SortCharacters(input, true);
        string sortedConsonants = SortCharacters(input, false);

        Console.WriteLine("Vowel Characters : ");
        Console.WriteLine(sortedVowels);
        Console.WriteLine("Consonant Characters : ");
        Console.WriteLine(sortedConsonants);
    }

    public static void SolveProblem2()
    {
        Console.Write("Input the number of families: ");
        int n = int.Parse(ReadNonNullInput());

        Console.Write("Input the number of members in the family (separated by a space): ");
        string[] familyMembersInput = ReadNonNullInput().Split(' ');

        if (familyMembersInput.Length != n)
        {
            Console.WriteLine("Input must be equal with count of family");
            return;
        }

        int[] familyMembers = Array.ConvertAll(familyMembersInput, int.Parse);

        int totalMembers = familyMembers.Sum();

        int busesNeeded = (int)Math.Ceiling((double)totalMembers / 4);
        Console.WriteLine("Minimum bus required is: " + busesNeeded);
    }

    public static string SortCharacters(string input, bool isVowel)
    {
        char[] chars = input.ToLower().ToCharArray();
        Array.Sort(chars);

        string sorted = new string(chars);

        if (isVowel)
        {
            sorted = new string(sorted.Where(c => "aiueoAIUEO".Contains(c)).ToArray());
        }
        else
        {
            sorted = new string(sorted.Where(c => !"aiueoAIUEO".Contains(c) && char.IsLetter(c)).ToArray());
        }

        return sorted;
    }

    public static string ReadNonNullInput()
    {
        string? input;
        do
        {
            input = Console.ReadLine();
            if (string.IsNullOrWhiteSpace(input))
            {
                Console.WriteLine("Input cannot be null or empty.");
            }
        } while (string.IsNullOrWhiteSpace(input));
        return input!;
    }
}
