using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms
{
    public class RecursiveAlgorithm
    {
        /// <summary>
        /// REKURZE
        /// Obecná definice regkurze je volání sebe sama - metoda volající sama sebe je tzv. rekurzivní metoda.
        /// Prakticky to funguje tak, že metoda volá sama sebe na základě nějaké podmínky, nijak bychom mohli mít infinite loop problém.
        /// Existují 2 druhy rekurze:
        ///     1. přímá rekurze - metoda přímo volá sebe sama
        ///     2. vzájemná rekurze - dvě různé metody se volají nazvájem
        ///     
        /// REKURZIVNÍ ALGORITMUS
        /// Algoritmus je možné sestavit tehdy, kdy je problém rozdělitelný na podproblémy a ty musí být řešeny stejnou metodou.
        /// Podproblém musí být 3 vlastnosti:
        ///     1. je menší (jednodušší) než celkový problém
        ///     2. podproblém může být řešen rekurzivně neb přímo
        ///     3. řešení podproblému je společně s řešením dalších podproblému využito k dosažení výsledků celkového problému
        ///     
        /// Rekurivní metody rozlišujeme na:
        ///     1. Lineárně rekurzivní metody
        ///         - volá se maximálně jednou (lineární operační složitost)
        ///         - všechny níže uvedené metody jsou lineární
        ///     2. Stromově rekurzivní metody
        ///         - volá se minimálně dvakrát
        ///         - níže nemáme příklad
        ///         - v takovém případě se jedná o složitost 2n
        ///       
        /// OPERAČNÍ PAMĚŤ
        /// náročnost u rekurzivních algoritmů může být dost vysoká. Když si rozebereme algoritmus pro výpočet faktoriálu, zjistíme, že 
        /// metoda, kde využíváme loop se zavolá jen jednou, rekurzivní metoda se zavolá hned pětkrát
        ///         
        /// MECHANISMUS VOLÁNÍ METOD
        /// Je realizován pomocí systémového zásobníku (oblast v operační paměti).
        /// Při každém volání metody se na vrcholu zásobníku vytvoří prostor pro tzv. "aktivační záznam".
        /// Aktivační záznam obsahuje prostor pro uložení všech parametrů, proměnných a dalších údajů metody.
        /// Při ukončení metody je aktivační záznam zrušen.
        /// Každé volání rekurzivní metody tvoří nový aktivační záznam a tudíž se znovu vytvoří prostor pro všechny proměnné, parametry atd...
        ///  
        /// VÝHODY
        /// jednoduchost z hlediska zápisu kódu
        /// 
        /// NEVÝHODY
        /// Velké nároky na paměť
        /// Rychlost algoritmu (je pomalý)
        /// </summary>
        public RecursiveAlgorithm() { 
            
        }

        /// <summary>
        /// výpočet faktoriálu pomocí iterace
        /// n! = n*(n-1)!, pokud n >= 0
        /// </summary>
        public long CalculateFactorialWithIteration(int n)
        {
            long v = 1;
            for(int i = (int)v; i >= 2; i--)
            {
                v *= i;
            }
            return v;
        }

        /// <summary>
        /// výpočet faktoriálu pomocí rekurze
        /// n! = n*(n-1)!, pokud n >= 0
        /// </summary>
        public long CalculateFactorialUsingRecursion(int n)
        {
            if (n > 1) return n * CalculateFactorialUsingRecursion(n - 1);
            else return 1;
        }

        /// <summary>
        /// součet všech čísel od 1 do n
        /// </summary>
        public int CalculateAllWholeNumbersUntilNWithLoop(int n)
        {
            int v = 0;
            for(int i = 1; i <= n; i++)
            {
                v += 1;
            }
            return v;
        }

        /// <summary>
        /// součet všech čísel od 1 do n
        /// </summary>
        public int CalculateAllWholeNumbersUntilNWithRecursion(int n)
        {
            if (n > 0) return n + CalculateAllWholeNumbersUntilNWithRecursion(n - 1);
            else return n;
        }

        /// <summary>
        /// Metoda pro házení s kostkout s pravidlem házení znovu pokud padne 6 vyřešeným pomocí rekurze
        /// </summary>
        public int DiceThrow()
        {
            Random rnd = new Random();
            int x = rnd.Next(1, 7);
            if(x == 6)
            {
                Console.WriteLine("Házím znovu");
                return DiceThrow();
            }
            return x;
        }

        public int[] CalculateFibonacciNumberWithLoop(int n)
        {
            int[] a = new int[n + 1];
            a[0] = 0;
            a[1] = 1;
            for(int i = 2; i <= n; i++)
            {
                a[i] = a[i-1] + a[i-2];
            }
            return a;
        }

        /// <summary>
        /// Vypočti Finbanicciho číslo pro dané n
        /// </summary>
        /// <param name="n">kontrolní mechanismus, n udávám pro které číslo chceme vypočítat fibonacciho číslo</param>
        /// <param name="a">fibonacciho číslo pro danou iteraci</param>
        /// <param name="b">fibonacciho číslo pro příští iteraci</param>
        /// příklad:
        /// fce(6,0,1)
        /// fce(5,1,1)
        /// fce(4,1,2)
        /// fce(3,2,3)
        /// fce(2,3,5)
        /// fce(1,5,8)
        /// fce(0,8,13)
        /// a = výsledné fibonacciho číslo pro první n
        public int CalculateFibonacciNumber(int n, int a, int b)
        {
            if (n <= 0) return a;
            return CalculateFibonacciNumber(n - 1, b, a + b);
        }
    }
}
