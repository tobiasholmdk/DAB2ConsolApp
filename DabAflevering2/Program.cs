using System;
using DabAflevering2.Contracts;
using DabAflevering2.DBContext;
using DabAflevering2.Entities;
using DabAflevering2.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace DabAflevering2
{
    class Program
    {
        static void Main(string[] args)
        {
            var a = new DummyData(); 
            a.InsertDummyData();
            while (true)
            {

            }
            
        }
        
    }
}