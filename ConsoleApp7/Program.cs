using System;
using System.Collections.Generic;
using System.Text.Json;
using static System.Reflection.Metadata.BlobBuilder;

class Ksiazka
{
    public string ID { get; set; }
    public string Tytul { get; set; }
    public string Autor { get; set; }
    public int RokWydania { get; set; }
    public string Gatunek { get; set; }
}

class Ksiegarnia
{
    static private List<Ksiazka> ksiazki = new List<Ksiazka>();

    public void DodajKsiazke(Ksiazka ksiazka)
    {
        ksiazki.Add(ksiazka);
    }

    public void WyswietlListe()
    {
        foreach (var ksiazka in ksiazki)
        {
            Console.WriteLine($"{ksiazka.ID}: {ksiazka.Tytul}");
        }
    }

    public void WyswietlKsiazke(string ID)
    {
        var ksiazka = ksiazki.Find(k => k.ID == ID);
        if (ksiazka != null)
        {
            Console.WriteLine($"Tytuł: {ksiazka.Tytul}");
            Console.WriteLine($"Autor: {ksiazka.Autor}");
            Console.WriteLine($"Rok wydania: {ksiazka.RokWydania}");
            Console.WriteLine($"Gatunek: {ksiazka.Gatunek}");
        }
        else
        {
            Console.WriteLine("Książka o podanym ID nie została znaleziona.");
        }
    }

    public void UsunKsiazke(string ID)
    {
        var ksiazka = ksiazki.Find(k => k.ID == ID);
        if (ksiazka != null)
        {
            ksiazki.Remove(ksiazka);
            Console.WriteLine("Książka została usunięta.");
        }
        else
        {
            Console.WriteLine("Książka o podanym ID nie została znaleziona.");
        }
    }

    public void zapiszKsiazke() {

        if (File.Exists("books.json"))

        {
            string json = File.ReadAllText("ksiazki.json");

            ksiazki = JsonSerializer.Deserialize<List<Ksiazka>>(json);

        }

    }

    static void SaveBooks()

    {
        string json = File.ReadAllText("ksiazki.json");

        ksiazki = JsonSerializer.Deserialize<List<Ksiazka>>(json);

    }

}


class Program
{
    static void Main(string[] args)
    {
        Ksiegarnia ksiegarnia = new Ksiegarnia();

        while (true)
        {
            Console.WriteLine("\nMENU:");
            Console.WriteLine("1. Dodaj książkę");
            Console.WriteLine("2. Wyświetl listę książek");
            Console.WriteLine("3. Wyświetl dane książki");
            Console.WriteLine("4. Usuń książkę");
            Console.WriteLine("5. Zapisz dane do pliku");
            Console.WriteLine("6. Wyjdź z programu");

            string wybor = Console.ReadLine();

            switch (wybor)
            {
                case "1":
                    Console.Write("Podaj ID książki: ");
                    string id = Console.ReadLine();
                    Console.Write("Podaj tytuł książki: ");
                    string tytul = Console.ReadLine();
                    Console.Write("Podaj autora książki: ");
                    string autor = Console.ReadLine();
                    Console.Write("Podaj rok wydania książki: ");
                    int rokWydania = Convert.ToInt32(Console.ReadLine());
                    Console.Write("Podaj gatunek książki: ");
                    string gatunek = Console.ReadLine();
                    Ksiazka nowaKsiazka = new Ksiazka { ID = id, Tytul = tytul, Autor = autor, RokWydania = rokWydania, Gatunek = gatunek };
                    ksiegarnia.DodajKsiazke(nowaKsiazka);
                    Console.WriteLine("Książka została dodana.");
                    break;
                case "2":
                    ksiegarnia.WyswietlListe();
                    break;
                case "3":
                    Console.Write("Podaj ID książki: ");
                    string idKsiazki = Console.ReadLine();
                    ksiegarnia.WyswietlKsiazke(idKsiazki);
                    break;
                case "4":
                    Console.Write("Podaj ID książki do usunięcia: ");
                    string idDoUsuniecia = Console.ReadLine();
                    ksiegarnia.UsunKsiazke(idDoUsuniecia);
                    break;
                case "5":
                    ksiegarnia.zapiszKsiazke();
                    break;
                case "6":
                    Console.WriteLine("Zamykanie programu...");
                    return;
                default:
                    Console.WriteLine("Niepoprawny wybór opcji. Spróbuj ponownie.");
                    break;
            }
        }
    }
}
