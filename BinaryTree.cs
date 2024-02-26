using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Algorithms
{
    public enum Order
    {
        PREORDER,
        INORDER,
        POSTORDER,
    }
    public class Node<T>
    {
        public T value;
        public Node<T> left;
        public Node<T> right;

        public Node(T _value)
        {
            value = _value;
            left = null;
            right = null;
        }

        public void Log()
        {
            System.Diagnostics.Debug.WriteLine(value);
        }
    }

    /// <summary>
    /// BINÁRNÍ STROM
    /// - skládá se z uzlů
    /// - každý uzel má nějakou hodnotu a může mít více než jednoho následníka
    /// - každý uzel může mít max 2 následníky
    /// - stupeň uzlu je dán počtem následníků
    /// - stupeň stromu je dán maximálním počtem uzlů -> d
    /// - uzel bez následníka se nazývá list
    /// - uzel, který není následníkem (první uzel) se nazývá kořen
    /// - každý uzel je kořen "podstromu"
    /// - výška (někdy také hloubka) je max úroveň vnoření
    /// - v praxi nejčastěji využívaná struktura
    /// 
    /// 
    /// REGULÉRNÍ BINÁRNÍ STROM
    /// - využívaný pro vyhledávání - HEAPSORT algoritmus
    /// - pro každý uzel platí, že hodnota v něm uložená je menší než hodnota uložené v jeho následníkovi
    /// - v každé hladině od první až do předposlední je dán maximální počet uzlů 2 na k-1 uzlů.
    /// - v poslední hladině jsou všechny uzly umístěny co možná nejvíce vlevo.
    /// - S takovým binárním stromem můžeme:
    ///     1. Vkládat hodnoty
    ///     2. Vyhledávat hodnoty
    ///     3. Vypouštět hodnoty
    /// - vyhledávání má logaritmickou složiton O(logN)
    /// - Do stromu se hodnoty ukládájí následovně
    /// - hodnota, která vstupuje se porovná s hodnotu v kořeni stromu, pokud je menší, zapíšeme "vlevo" v opačném případě v pravo
    /// - takto postupujeme dále a víme, že menší hodnota je vždy vlevo a větší v pravo
    /// - struktura pak vypadá následovně:
    /// 
    ///                     20
    ///             10              32
    ///          5      14     27       40
    ///        2   6  11           28
    ///  
    /// - vyhledávání je poté jednoduché a funguje na stejný princip, vyhledávaná hodnota se porovná s kořenem, pokud je menší, budeme hledat na levé straně, v opačném případě na pravé straně
    /// </summary>
    public class BinaryTree<T>
    {
        // Node's pro čísla
        Node<int> intNode;
 
        // Metoda funguje pouze pro čísla
        public int FindInBinaryTree(Node<int> _node, int x)
        {
            intNode = _node;
            Node<int> result = new Node<int>(0);

            while (intNode != null)
            {
                if (intNode.value.Equals(x))
                {
                    result = intNode;
                }
                else
                {
                    if (x < intNode.value)
                    {
                        intNode = intNode.left;
                    }
                    else
                    {
                        intNode = intNode.right;
                    }
                }
            }
            

            return result.value;
        }

        // Metoda funguje pouze pro čísla
        public void Add(int x)
        {
            Node<int> tempNode = intNode;
            Node<int> beforeEl = null;
            bool notFound = true;

            while (tempNode != null && notFound) {
                if (tempNode.value.Equals(x))
                {
                    notFound = false;
                    break;
                }

                beforeEl = tempNode;

                if (x < intNode.value)
                {
                    
                    tempNode = tempNode.left;
                }

                if(x > intNode.value)
                {
                    tempNode = tempNode.right;
                }
            }

            if (notFound)
            {
                Node<int> newNode = new Node<int>(x);
                if(beforeEl == null) intNode = newNode;
                if(x < beforeEl.value) beforeEl.left = newNode;
                if(x > beforeEl.value) beforeEl.right = newNode;
            }
        }

        // PROCHÁZENÍ DO HLOUBKY
        // U Binárního stromu
        //                      20
        //         10                       32
        //      5      14             27         40
        //    2      11                  28
        // Výpis bude následovný:
        // PREORDER -> 20,10,5,2,14,11,32,27,28,40
        // INORDER -> 2,5,10,11,14,20,27,28,32,40
        // POSTORDER -> 2,5,11,14,10,28,27,40,32,20
        public void PrintByOrder(Order order, Node<int> _node)
        {
            if (_node == null) return;

            if (order == Order.PREORDER)
            {
                _node.Log();
                PrintByOrder(Order.PREORDER, _node.left);
                PrintByOrder(Order.PREORDER, _node.right);
            }
            
            if (order == Order.INORDER)
            {
                PrintByOrder(Order.INORDER, _node.left);
                _node.Log();
                PrintByOrder(Order.INORDER, _node.right);
            }

            if (order == Order.POSTORDER)
            {
                PrintByOrder(Order.POSTORDER, _node.left);
                PrintByOrder(Order.POSTORDER, _node.right);
                _node.Log();
            }
        }
    }
}
