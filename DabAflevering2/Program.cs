using System;
using Dab_aflevering_2.Contracts;
using Dab_aflevering_2.DBContext;
using Dab_aflevering_2.Entities;
using Dab_aflevering_2.Repositories;
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