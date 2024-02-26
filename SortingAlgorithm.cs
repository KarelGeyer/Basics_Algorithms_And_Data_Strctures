using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms
{
    public class SortingAlgorithm
    {
        /// <summary>
        /// ŘADÍCÍ ALGORITMY
        /// 
        /// VLASTNOSTI
        ///     1. Krátký program řadící co nejrychleji
        ///     2. Minimální požadavky na paměť
        ///         - paměťová složitost se označuje jako P(n) a je lineárního řádu
        ///         - některé algoritmy požadují dodatečné pracovní prostory pro ukládání mezivýsledků či konečný výsledek (např. výsledné seřazené pole)
        ///     3. Stabilita
        ///         - stabilní řadící algoritmus po seřazení zachová pořadí prvků
        ///             - to znamená, že pole studentů seřazená dle abecedy, které seřadíme např. dle čísel kruhů, ponechá studenty ze stejných kruhů abecedně seřazené
        ///         - nestabilní algoritmus může zpřeházet prvky, bývá ale rychlejší
        ///      4. Přirozenost
        ///         - přirozený algoritmus má dobu seřazení částěně uspořádané posloupnosti menší, než dobu posloupnosti neuspořádané
        ///             1,2,3,4,5,6,7 - uspořádaná posloupnost
        ///             1,3,6,7,5,4,2 - neuspořádaná posloupnost
        ///             1,4,3,2,5,6,7 - částečně uspořádané posloupnost
        ///      5. Rychlost (operační složitost)
        ///         - dána počtem operací nutných k provedení algoritmu
        ///         - operační složitost určuje závislost doby řazení na počtu řazených prvků
        ///         - dělíme ji dle složitosti:
        ///             1. Kvadratická složitost => O(N2 (rozuměj na druhou)), kdy N je počet řazených prvků
        ///             2. Logaritmická složitost => O(N*logN), je příznivější než kvadratická
        ///             3. Lineární složistos => O(N)
        ///         
        /// 
        /// TYPY ŘAZENÍ
        ///     1. Vnitřní řazení
        ///         - všechna data se vejdou do operační paměti
        ///         - rychlost algoritmu je závislá na počtu porovnání a záměn
        ///     2. Vnější řazení
        ///         - nestačí vnitřní pamět a je potřeba využít i paměti vnější
        ///         - rychlost je tedy dále omezena i počtem přístupů do vnitřní paměti
        ///         
        /// ALGORITMY S KVADRATICKOU SLOŽITOSTÍ
        ///     - např. SelectSort, BubbleSort, ShakerSort, InserSort 
        ///     
        /// ALGORITMY S LOGARITMICKOU SLOŽITOSTÍ
        ///     - např. QuickSort, HeapSort, MergeSort
        ///     - již použitelné pro řezení většího množství dat
        ///     
        /// ALGORITMY S LINEÁRNÍ SLOŽITOSTÍ
        ///     - RadixSort
        /// </summary>

        #region Algoritmy s kvadratickou složitostí
        /// <summary>
        /// SELECTSORT
        /// 
        /// Postup:
        ///     1. nalezení prvku s maximální hodnotou a jeho pořadí v poli
        ///     2. záměna maximálního prvku s posledním prvkem pole při vzestupném řazení nebo s prvním při sestupném řazení
        ///     3. zkrácení pole o jeden prvek
        ///     
        /// Má velice slabé využití kvůli své vysoké náročnosti
        /// </summary>
        public void SelectSort(int[] a)
        {
            int k = 0; 
            int max = 0; 
            int j = a.Length - 1;

            while(j >= 1)
            {
                max = a[j];
                k = j;

                for(int i = 0; i <= j; i++)
                {
                    if (a[i] > max)
                    {
                        max = a[i];
                        k = i;
                    }
                }
            }
        }

        /// <summary>
        /// BUBBLESORT
        /// 
        /// Postup:
        ///     - postupně procházíme pole a porovnáváme dva sousední prvky
        ///     - pokud prvky nejsou ve správném pořadí, prohodíme je
        ///     - při průchodu zleva doprava tak "probublá" prvek s nejnižší hodnotou na pravý konec pole
        ///     - aby došlo k seřazení, je potřeba provést n-1 průchodů
        ///     
        /// - Neexistuje ani nejlepší, ani nejhorší případ, je potřeba tolik průchodů, kolik je prvků - 1 bze ohledu na data, jejich pořadí či míru seřazení
        /// - Po prvním průchodu najdeme vždy největší prvek pole na konci pole
        /// - Algoritmus se nechová přirozeně
        /// - Velice pomalý algoritmus
        /// </summary>
        public void BubleSort(int[] a)
        {
            int pom, n = a.Length - 1;
            int j = 1;
            while (j <= n)
            {
                for (int i = 0; i <= n - j; i++)
                {
                if (a[i] > a[i + 1])
                    {
                        pom = a[i];
                        a[i] = a[i + 1];
                        a[i + 1] = pom;
                    }
                }
                j = j + 1;
            }
        }

        /// <summary>
        /// SHAKERSORT
        /// 
        /// Postup:
        ///     - podobný jako BubbleSort, je ale schopný zapamatovat si místo poslední provedené záměny
        ///     - dále se liší tím, že pole procházíme střídavě zleva doprava a zprava doleva
        ///     - při programovaná je riziko nekonečných cyklů
        ///     - algoritmus rozpozná seřazené pole a chodá se tedy přirozeně
        /// </summary>
        public void ShakerSort(int[] a)
        {
            int temp;
            int r = a.Length - 1;
            int k = a.Length - 1;
            int j = 1;

            for (int i = r; i >= j; i--)
            {
                if (a[i - 1] > a[i])
                {
                    temp = a[i];
                    a[i] = a[i - 1];
                    a[i - 1] = temp;
                    k = i;
                }
            }

            j = k + 1;

            for(int i = j; i <= r; i++)
            {
                if (a[i - 1] > a[i])
                {
                    temp = a[i];
                    a[i] = a[i - 1];
                    a[i - 1] = temp;
                    k = i;
                }
            }

            r = k - 1;
        }

        /// <summary>
        /// INSERTSORT
        /// 
        /// - Z pole postupně vybíráme prvky, které zařazujeme na správná místa
        /// - Zleva tak vytváříme uspořádané pole, do prava ukládáme neseřazené hodnoty
        /// - Vlastně Z pravého úsku bereme čísla jedno po druhém a do levého je třídíme dle velikost na pozice kam patří
        /// 
        /// Postup:
        ///     1. Prvek uložíme do pomocné proměnné
        ///     2. Hledáme pozici, kam prvek zařadit
        ///         2.1. i-tý prvek porovnáváme postupně s prvky ležícími vlevo od pozice i
        ///         2.2. pokud je při porovnávání hodnota prvku větší nebo rovna hodnotě levého souseda, vkládáný prvek je na správném místě
        ///     3. Uvolníme místo pro tento prvek - posuneme prvky o jedno místo doprava
        ///     
        /// Nejhorší případ:
        ///     - pokud je zdrojová posloupnost uspořádána v opačném pořadí
        /// Nejlepší případ:
        ///     - pokud je zdrojová posloupnost již uspořádaná
        /// </summary>
        public void InsertSort(int[] a)
        {
            int temp, i, j;
            int n = a.Length - 1;
            i = 1;
            while (i <= n)
            {
                temp = a[i]; // uložení zatřiďované hodnoty do pomocné proměnné
                j = i - 1;
                while (j != -1 && temp < a[j])
                {
                    a[j + 1] = a[j]; // posun prvků doprava
                    j--;
                }
                a[j + 1] = temp; // vložení prvku na správné místo
                i++; // index dalšího prvku, který se bude zatřiďovat
            };
        }
        #endregion

        #region Algoritmy s logaritmickou složitostí
        /// <summary>
        /// QUICKSORT
        /// 
        /// - užívá principu rozděluj a panuj
        /// - pole rozdělíme na dvě části a hodnotu dělícího prvku nazveme x
        /// - do jedné části pole umístíme pouze prvky menší než x a do druhé větší nebo rovno x
        /// - následně opakujeme postup samostatně pro obě poloviny
        /// - tyto dvě poloviny pak řešíme úplně stejně, postupně je rozděleujeme na menší povoliny, které samostatně třídíme
        /// - takto pokračujeme dokud nenajdeme úseky o délce jednoho prvku a takové úseky jsou již samy o sobě seřazené
        /// </summary>
        public void QuickSort(int[] a, int l, int r)
        {
            int i, j, x, k, pom;
            k = (l + r) / 2;
            x = a[k];
            i = l;
            j = r;
            do
            {
                while (x > a[i]) i++; //posun indexu v levé části pole
                while (x < a[j]) j--; //posun indexu v pravé části pole
                if (i <= j)
                {
                    pom = a[i];
                    a[i] = a[j];
                    a[j] = pom;
                    i++;
                    j--;
                }
            } while (i < j);
            if (l < j) QuickSort(a, l, j);
            if (i < r) QuickSort(a, i, r);
        }

        /// <summary>
        /// MERGESORT
        /// 
        /// - opět rozdělíme řazené pole na dvě poloviny
        /// - každou polovinu seřadíme zvlášť
        /// - obě poloviny následně sloučíme do jednoho pole
        /// - oba slučované úseky se pomocí 2 pracovních indexů procházejí a prvky se porovnávají
        /// - menší z nich se přesune do cílové posloupnosti
        /// </summary>
        public void MergeSort(int[] a)
        {
            int i, j; //indexy prvku ve zdrojovych polich
            int k, l; //indexy prvku v cilovych polich
            int pocet; //pocet prvku p-tice
            int q, r; //pocty prvku, ktere zbyva sloucit v p-tici
            int m; //kolik prvku zbyva celkem
            int h; //smer ukladani v cilovem poli
            int pom;
            bool nahoru;

            int[] pom_pole = new int[2 * a.Length]; //pomocne pole

            for (i = 0; i < a.Length; i++) pom_pole[i] = a[i]; // kopirovani pole do 
                                                               // pomocneho pole
            nahoru = true;
            pocet = 1;
            do
            {
                h = 1;
                m = a.Length;
                if (nahoru == true)
                {
                    i = 0;
                    j = a.Length - 1; //pocatecni hodnoty indexu ve zdrojovem poli
                    k = a.Length; l = 2 * a.Length - 1; // pocatecni hodnoty indexu v 
                                                        // cilovem poli
                }
                else
                {
                    k = 0; l = a.Length - 1; // pocatecni hodnoty indexu ve 
                                             // zdrojovem poli
                    i = a.Length; j = 2 * a.Length - 1; // pocatecni hodnoty indexu v 
                } // cilovem poli

                do
                {
                    if (m >= pocet) q = pocet;
                    else q = m;
                    m = m - q;
                    if (m >= pocet) r = pocet;
                    else r = m;
                    m = m - r;
                    while ((q != 0) && (r != 0))
                    {
                        if (pom_pole[i] < pom_pole[j])
                        {
                            pom_pole[k] = pom_pole[i];
                            k += h;
                            i++;
                            q--;
                        }
                        else
                        {
                            pom_pole[k] = pom_pole[j];
                            k += h;
                            j--;
                            r--;
                        }
                    }
                    while (r != 0)
                    {
                        pom_pole[k] = pom_pole[j];
                        k += h;
                        j--;
                        r--;
                    }

                    while (q != 0)
                    {
                        pom_pole[k] = pom_pole[i];
                        k += h;
                        i++;
                        q--;
                    }

                    h = -h; //zmena smeru ukladani v cilovem poli
                    pom = k;
                    k = l;
                    l = pom;
                } while (m != 0);

                nahoru = !nahoru;
                pocet *= 2;
            } while (pocet < a.Length);
            // kopirovani z pomocneho pole
            if (nahoru == false)
                for (i = 0; i < a.Length; i++)
                {
                    a[i] = pom_pole[i + a.Length];
                }
            else
                for (i = 0; i < a.Length; i++)
                {
                    a[i] = pom_pole[i];
                }
        }
        #endregion

        #region Algoritmy s logaritmickou složitostí
        /// <summary>
        /// RADIXSORT
        /// 
        /// - neboli tzv. "Přihrádkové řazení"
        /// - algoritmus není univerzální, má tedy následující omezení:
        ///     1. dá se použít pouze pro řazení celých čísel
        ///     2. můžeme řadit pouze předem známé a ne příliš velké rozmezí
        ///     3. zvýšené nároky na operační paměť - jsou potřeba dvě pole, vstupní a výstupní
        ///     
        /// D a H jsou takové konstanty, že všechna tříděna čísla jsou z intervalu <D,H>
        /// Připravíme si tak H + 1 přihrádek (tedy pole o velikosti H+1)
        /// Postupně procházíme hodnoty vstupního pole a pro každou z nich přičteme jedničku vždy do té přihrádky, jejíž označení (index) se shoduje s řazenou hodnotou
        /// Dolní a horní hranici intervalu = min a max hodnoty vstupního pole
        /// Příklad postupu
        /// 
        /// pole A = [1,4,1,5,5,4,2,3,1,3]
        /// pole B = [0,0,0,0,0,0] (max hodnota je 5, délka je tedy H+1 = 6)
        /// 
        /// při průchodu zjišťujeme hodnotu prvku a ukládáme ji k indexu podle B
        /// příklad 1
        /// v poli A najedeme hodnotu 1 na první pozici
        /// v poli B zvýšíme první místo o 1 -> [0,1,0,0,0,0]
        /// následně najdeme 4 na druhé pozici
        /// v poli B zvýšíme 4 místo o 1 -> [0,1,0,0,1,0]
        /// následně najdeme další 1 na třetím pozici
        /// v poli B zvýšímě 1 místo o 1 -> [0,2,0,0,1,0]
        /// 
        /// takto budeme postupovat až dokonce a získáme následující pole -> [0,3,1,2,2,2]
        ///                                                                  [0,1,2,3,4,5]
        /// z výsledku je zřejmé, že hodnota na určité pozici ukazuje, kolikrát máme vypsat pozici pole, po vypsání všech pozic pole budeme mít vypasnou seřazenou posloupnost                                                                 
        /// </summary>
        public int D = 1;
        public int H = 10;
        public void RadixSort(int[] a)
        {
            int[] b = new int[a.Length];
            int[] c = new int[H + 1]; // You need to define 'H' as the maximum value in the input array 'a'.

            for (int i = 0; i < a.Length; i++)
            {
                int t = a[i];
                c[t] = c[t] + 1;
            }

            int k = 0; // index in the output array

            for (int i = 0; i < c.Length; i++)
            {
                if (c[i] != 0)
                {
                    for (int p = 1; p <= c[i]; p++)
                    {
                        b[k] = i;
                        k++;
                    }
                }
            }

            Array.Copy(b, 0, a, 0, a.Length);
        }
        #endregion
    }
}
