﻿using System;

namespace LocadoraVeiculos.Dominio
{
    public abstract class EntidadeBase<TKey>
    {
        public TKey Id { get; set; }

        public abstract string Validar();

        protected string QuebraDeLinha(string resultadoValidacao)
        {
            string quebraDeLinha = "";

            if (string.IsNullOrEmpty(resultadoValidacao) == false)
                quebraDeLinha = Environment.NewLine;

            return quebraDeLinha;
        }
    }
}
