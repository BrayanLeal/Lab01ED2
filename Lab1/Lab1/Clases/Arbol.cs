﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Lab1.Clases
{
    class Arbol<T> where T : IComparable<T>
    {
        public Arbol(int grado)
        {
            Grado = grado;
            this.Raiz = new Nodo<T>();
        }

        public int Grado { get; set; }
        public Nodo<T> Raiz { get; set; }
        private static bool Vacio { get; set; }
        private static bool Lleno { get; set; }

        public void Insertar(List<T> valores)
        {

            while (this.Raiz.Values.Count < Grado && valores.Count != 0)
            {
                this.InsercionNodoActivo(this.Raiz, valores.First());
                valores.RemoveAt(0);
            }

            if (valores.Count > 0)
            {
                Nodo<T> nodoAux = this.Raiz;
                this.Raiz = new Nodo<T>();
                this.Raiz.Children.Add(nodoAux);
                this.SepararNodo(this.Raiz, nodoAux, 0);

                for (int i = 0; i <= valores.Count; i++)
                {
                    this.InsercionNodoActivo(this.Raiz, valores.First());
                    valores.RemoveAt(0);
                    Insertar(valores);
                }
            }


        }

        public void InsercionNodoActivo(Nodo<T> nodo, T valor)
        {
            //int puntero = nodo.Values.Count;
            int puntero = nodo.Values.TakeWhile(entry => valor.CompareTo(entry) >= 0).Count();



            //nodo hoja
            if (nodo.IsLeaf)
            {
                nodo.Values.Insert(puntero, valor);
                return;
            }

            //no es hoja
            Nodo<T> hijo = nodo.Children[puntero];
            if (hijo.Values.Count == Grado)
            {
                this.SepararNodo(nodo, hijo, puntero);
                if (valor.CompareTo(nodo.Values[puntero]) > 0)
                {
                    puntero++;
                }
            }

            this.InsercionNodoActivo(nodo.Children[puntero], valor);
        }

        public void SepararNodo(Nodo<T> padre, Nodo<T> hermano, int puntero)
        {
            var nuevoNodo = new Nodo<T>();

            padre.Values.Insert(puntero, hermano.Values[this.Grado - 2]);
            padre.Children.Insert(puntero + 1, nuevoNodo);

            nuevoNodo.Values.AddRange(hermano.Values.GetRange(this.Grado - 1, this.Grado - 2));

            hermano.Values.RemoveRange(Grado - 2, Grado - 1);

            if (!hermano.IsLeaf)
            {
                nuevoNodo.Children.AddRange(hermano.Children.GetRange(Grado - 1, Grado - 1));
                hermano.Children.RemoveRange(Grado - 1, Grado - 1);
            }

        }

        public Boolean ExisteElemento(T item)
        {
            bool existe = true;
            for (int i = 0; i < Grado; i++)
            {

            }
            return existe;
        }


    }
}
