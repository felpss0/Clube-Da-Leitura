﻿namespace ClubeDaLeitura2.ConsoleApp.Compartilhado
{
    public class GeradorDeId
    {
        public static int IdAmigo = 0;
        public static int IdCaixa = 0;
        public static int IdRevista = 0;
        public static int IdEmprestimo = 0;


        public static int GerarIdAmigo()
        {
            IdAmigo++;

            return IdAmigo;
        }

        public static int GerarIdCaixa()
        {
            IdCaixa++;

            return IdCaixa;
        }

        public static int GerarIdRevista()
        {
            IdRevista++;

            return IdRevista;
        }

        public static int GerarIdEmprestimo()
        {
            IdEmprestimo++;

            return IdEmprestimo;
        }
    }
}
