using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms
{
    public class StaticVsDynamicDataStructures
    {
        /// <summary>
        /// STATICKÉ DATOVÉ STRUKTURY
        /// 
        /// - slouží hlavně k ukládání předem známého množstžví dat v operační paměti
        /// - tradiční statickou datovou strukture je DATOVÉ POLE
        ///     - jedná se o skupinu (množinu) dat stejného typu
        ///     - k položkám v poli se přistpuje pomocí indexu
        /// - výhodou je rychlý přístup ke všem položkám pomocí indexu
        /// - nevýhodou je nemožnost změny velikosti alokované operační paměti za běhu aplikace
        /// </summary>
        public void StaticDataStrcutures()
        {
        }

        /// <summary>
        /// DYNAMICKÉ DATOVÉ STRUKTURY
        /// 
        /// - velikost dynamické datové struktury se mění za běhu programu
        /// - to se děje za pomocí reference na jiné paměťové místo, kde je uložena další hodnota a další reference na další místo atd...
        /// - výhoda je očividně možnost měnit velikost za běhu programu
        /// - nevýhoda je, že nemáme okamžitý přístup ke všem hodnotám v datové struktuře, přístup máme jen k první a k další musíme jít na jiné místo v operační paměti
        /// - dynamické datové struktury dělíme na:
        ///     a) Lineární dynamická struktura
        ///         - tvořena lineárně uspořádánou množinou prvků
        ///         - krom posledního prvku mají všechny prvky následníka
        ///         - krom prvního prvku mají všechny prvky předchůdce
        ///         - nejtypičtějším zástupcem linerání datové struktury je LINEAR LINKED LIST (lineární spojový seznam)
        ///         - přidání nebo odebrání prvku má lineární časovou složitost
        ///         - vyhledávání má lineérní závislost
        ///         - tyto struktury se často označují jako zásobník (STACK), fronta (QUEUE) nebo spojový seznam (LINKED LIST)
        ///         
        ///         FRONTA - QUEUE
        ///         - FIFO -> nové hodnoty přidáváme vždy na konec a odebíráme vždy první prvek (jako ve frontě)
        ///         - s frontou není možné dělat jiné operace
        ///         
        ///         ZÁSOBNÍK - STACK
        ///         - LIFO -> nové hodnoty nakonec a odebíráme vždy poslední prvek - jako např. stack talířů
        ///         
        ///         SPOJOVÝ SEZNAM - LINKED LIST
        ///         - přidáváme a odebíráme prvky kdekoliv ve struktuře
        ///         1. jednosměrně zřetězený
        ///             - všechny prvky kromě posledního mají svého následníka 
        ///         2. obousměrně zřetězený
        ///             - každý prvek navíc obsahuje i reference na místo svého předchůdce (díky tomu můžeme vyhledat i předchůdce, nejen následníka)
        ///         3. kruhový
        ///             - může být pro jednosměrně zřetězený i obousměrně
        ///             - v principu se jedná o to, že následník posledního prvku je první prvek v případě jednosměrného a u obousměrného přidáme prvnímu prvku referenci i na ten poslední
        ///             
        ///     b) Nelineární dynamická struktura
        ///         - tvořena množinou prvků, kde každý prvek může být spojen s více prvky
        ///         - typickým představitelem byl byl binární strom (BINARY TREE)
        ///         - struktura má jeden začátek a více konců
        /// </summary>
        public void DynamicDataStrcutures() 
        {
            /// LINKED LIST
            LinkedList<int> listOfIntegers = new LinkedList<int>();
            listOfIntegers.Add(0);
            listOfIntegers.Add(1);
            listOfIntegers.Add(2);
            listOfIntegers.Add(3);
            listOfIntegers.Add(4);
            listOfIntegers.Remove(2);
            Console.WriteLine($"the value of the last item is: {listOfIntegers.Get(listOfIntegers.Count - 1)}");
            Console.ReadLine();
        }
    }    
}
